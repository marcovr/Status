using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.VisualBasic.Devices;
using System.Management;
using WMPLib;

namespace Status
{
    public partial class mainWindow : Form
    {
        private const int WM_MOUSEACTIVATE = 0x0021;
        private const int MA_NOACTIVATEANDEAT = 0x0004;
        PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        PerformanceCounter diskCounter = new PerformanceCounter("PhysicalDisk", "% Idle Time", "_Total");
        PowerStatus power = SystemInformation.PowerStatus;
        ComputerInfo PC = new ComputerInfo();
        Timer timer, driveTimer;
        public DriveInfo[] drives;
        public List<DriveBox> driveBoxes;
        public int driveCount;
        public int allDrives = 0;
        public int showbatteryFrame = 1;
        public int showdiskFrame = 1;

        private Hotkey hotkey;
        
        public mainWindow()
        {
            InitializeComponent();
            UI.window = this;
            Screen myScreen = Screen.FromControl(this);
            Rectangle area = myScreen.WorkingArea;
            Left = area.Width - 210;
            Top = 100;
            batteryBar.invertedCritical = true;

            updateSettings();

            playerinfo.Visible = false;
            mediaFrame.Height = 50;

            updateFast(null, new EventArgs());
            updateSlow(null, new EventArgs());

            driveTimer = new Timer() { Interval = 5000 };
            driveTimer.Tick += updateSlow;
            driveTimer.Start();

            timer = new Timer() { Interval = 1000 };
            timer.Tick += updateFast;
            timer.Start();

            hotkey = new Hotkey(Hotkey.Modifiers.NOMOD, Keys.MediaPlayPause, this);
            hotkey.Register();
        }

        private void updateFast(object sender, EventArgs e)
        {
            cpuBar.Value = (int)cpuCounter.NextValue();
            float percent = 100 - (float)PC.AvailablePhysicalMemory / (float)PC.TotalPhysicalMemory * 100;
            ramBar.Value = (int)percent;
            Screen myScreen = Screen.FromControl(this);
            Rectangle area = myScreen.WorkingArea;
            Left = area.Width - 210;

            if (showdiskFrame == 1)
            {
                int temp = 100 - (int)diskCounter.NextValue();
                if (temp >= 0 && temp <= 100)
                {
                    diskBar.Value = temp;
                }
            }
        }

        private void updateSlow(object sender, EventArgs e)
        {
            batteryBar.Value = (int)(power.BatteryLifePercent * 100);
            if (Properties.Settings.Default.battery1)
            {
                if (power.PowerLineStatus == PowerLineStatus.Online)
                {
                    BatteryImg.Image = Properties.Resources.Line;
                    if (Properties.Settings.Default.battery2)
                    {
                        batteryFrame.Visible = true;
                        showbatteryFrame = 1;
                        setHeight();
                    }
                    else
                    {
                        batteryFrame.Visible = false;
                        showbatteryFrame = 0;
                        setHeight();
                    }
                }
                else
                {
                    BatteryImg.Image = Properties.Resources.Battery;
                    if (Properties.Settings.Default.battery1)
                    {
                        batteryFrame.Visible = true;
                        showbatteryFrame = 1;
                    }
                    else
                    {
                        batteryFrame.Visible = false;
                        showbatteryFrame = 0;
                    }
                }
            }
            else
            {
                showbatteryFrame = 0;
                batteryFrame.Visible = false;
            }

            drives = DriveInfo.GetDrives();
            if (drives.Length != allDrives)
            {
                allDrives = drives.Length;
                driveCount = 0;
                driveFrame.Controls.Clear();
                driveBoxes = new List<DriveBox>();

                for (int n = 0; n < allDrives; n++)
                {
                    if (drives[n].IsReady)
                    {
                        driveBoxes.Add(new DriveBox(n));
                        driveCount++;
                    }
                }
                driveFrame.Height = 27 + driveCount * 22;
                setHeight();
            }
            else
            {
                foreach (DriveBox drivebox in driveBoxes)
                {
                    int newvalue = Win32.getFreeSpace(drivebox.driveIndex);
                    if (drivebox.progressbar.Value != newvalue)
                    {
                        drivebox.progressbar.Value = newvalue;
                    }

                    string newtext = drives[drivebox.driveIndex].Name;
                    if (drivebox.label.Text != newtext)
                    {
                        drivebox.label.Text = newtext;
                        drivebox.picturebox.Image = Win32.getImage(newtext);
                    }
                }
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Hotkey.Constants.WM_HOTKEY_MSG_ID)
            {
                if (btn_stop.BackColor == UI.blue)
                {
                    stop();
                }
                else
                {
                    playOrPause();
                }
            }
            base.WndProc(ref m);
        }

        private void btn_stop_click(object sender, EventArgs e)
        {
            if (btn_stop.BackColor == UI.blue)
            {
                stop();
            }
        }

        private void btn_play_click(object sender, EventArgs e)
        {
            playOrPause();
        }

        private void btn_close_click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void btn_settings_click(object sender, EventArgs e)
        {
            Settings SettingsWindow = new Settings();
            SettingsWindow.Show();
        }

        private void playerinfo_Click(object sender, EventArgs e)
        {
            PlaylistFlyout f = new PlaylistFlyout();
            f.Show();
        }

        private void stop()
        {
            player.Ctlcontrols.stop();
            btn_play.Text = "Play";
            btn_play.BackColor = UI.blue;
            btn_stop.BackColor = UI.grey;
            playerinfo.Visible = false;
            mediaFrame.Height = 50;
            setHeight();
        }

        private void playOrPause()
        {
            if (btn_play.BackColor == UI.blue)
            {
                if (player.playState == WMPPlayState.wmppsPlaying)
                {
                    player.Ctlcontrols.pause();
                    btn_play.Text = "Play";
                }
                else
                {
                    btn_stop.BackColor = UI.blue;
                    btn_play.BackColor = UI.grey;
                    playerinfo.Text = "...";
                    playerinfo.Visible = true;
                    mediaFrame.Height = 75;
                    setHeight();

                    if (player.playState == WMPPlayState.wmppsPaused)
                    {
                        player.Ctlcontrols.play();
                    }
                    else
                    {
                        player.Ctlcontrols.stop();
                        if (Properties.Settings.Default.playersource == 0)
                        {
                            player.URL = Properties.Settings.Default.playersource1;
                        }
                        else
                        {
                            player.URL = Properties.Settings.Default.playersource2;
                        }
                    }
                }
            }
        }

        public void updateSettings()
        {
            if (Properties.Settings.Default.disk)
            {
                showdiskFrame = 1;
                diskFrame.Visible = true;
            }
            else
            {
                showdiskFrame = 0;
                diskFrame.Visible = false;
            }

            if (Properties.Settings.Default.battery1)
            {
                if (power.PowerLineStatus == PowerLineStatus.Online)
                {
                    if (Properties.Settings.Default.battery2)
                    {
                        batteryFrame.Visible = true;
                        showbatteryFrame = 1;
                    }
                    else
                    {
                        batteryFrame.Visible = false;
                        showbatteryFrame = 0;
                    }
                }
                else
                {
                    if (Properties.Settings.Default.battery1)
                    {
                        batteryFrame.Visible = true;
                        showbatteryFrame = 1;
                    }
                    else
                    {
                        batteryFrame.Visible = false;
                        showbatteryFrame = 0;
                    }
                }
            }
            else
            {
                showbatteryFrame = 0;
                batteryFrame.Visible = false;
            }

            player.settings.volume = Properties.Settings.Default.playervolume;

            setHeight();
        }

        private void mouse_move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Screen myScreen = Screen.FromControl(this);
                Rectangle area = myScreen.WorkingArea;
                if (Cursor.Position.Y <= area.Height - this.Height)
                {
                    this.Top = Cursor.Position.Y;
                }
                else
                {
                    this.Top = area.Height - this.Height;
                }
            }
        }

        private void player_statechanged(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (player.playState == WMPPlayState.wmppsPlaying)
            {
                btn_play.Text = "Pause";
                btn_play.BackColor = UI.blue;
                playerinfo.Text = player.currentMedia.name;
            }
            else if (player.playState == WMPPlayState.wmppsTransitioning || player.playState == WMPPlayState.wmppsBuffering)
            {
                playerinfo.Text = "loading...";
            }
            else if (player.playState == WMPPlayState.wmppsPaused)
            {
                playerinfo.Text = "paused";
            }
            else if (player.playState == WMPPlayState.wmppsReady)
            {
                //btn_stop_click("d", EventArgs.Empty);
            }
        }

        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Dispose();
            driveTimer.Dispose();
            System.Threading.Thread.Sleep(20);
        }

        private void setHeight()
        {
            if (playerinfo.Visible)
            {
                contentPanel.Height = 195 + 55 * showbatteryFrame + 55 * showdiskFrame + driveCount * 22;
                this.Height = 215 + 55 * showbatteryFrame + 55 * showdiskFrame + driveCount * 22;
            }
            else
            {
                contentPanel.Height = 170 + 55 * showbatteryFrame + 55 * showdiskFrame + driveCount * 22;
                this.Height = 190 + 55 * showbatteryFrame + 55 * showdiskFrame + driveCount * 22;
            }
        }
    }
}
