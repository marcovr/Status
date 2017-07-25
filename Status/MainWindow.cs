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
        private PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        //private PerformanceCounter diskCounter = new PerformanceCounter("PhysicalDisk", "% Idle Time", "_Total");
        private PowerStatus power = SystemInformation.PowerStatus;
        private ComputerInfo PC = new ComputerInfo();
        private Timer timer, driveTimer;
        private DriveInfo[] drives;
        public List<DriveBox> driveBoxes = new List<DriveBox>();
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

            UpdateSettings();

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
            ramBar.Value = GetUsedRAM();
            Left = Screen.FromControl(this).WorkingArea.Width - 210;

            /*if (Properties.Settings.Default.disk)
            {
                int temp = 100 - (int)Math.Round(diskCounter.NextValue());
                if (temp >= 0 && temp <= 100)
                {
                    diskBar.Value = temp;
                }
            }*/
        }

        private void updateSlow(object sender, EventArgs e)
        {
            batteryBar.Value = (int)Math.Round(power.BatteryLifePercent * 100);
            if (batteryFrame.Visible = Properties.Settings.Default.battery1)
            {
                if (power.PowerLineStatus == PowerLineStatus.Online)
                {
                    BatteryImg.Image = Properties.Resources.Line;
                    batteryFrame.Visible = Properties.Settings.Default.battery2;
                }
                else
                {
                    BatteryImg.Image = Properties.Resources.Battery;
                }
            }

            drives = DriveInfo.GetDrives();
            if (drives.Length != driveBoxes.Count)
            {
                driveFrame.Controls.Clear();
                driveBoxes.Clear();

                foreach(DriveInfo drive in drives)
                {
                    driveBoxes.Add(new DriveBox(drive));
                }

                driveFrame.Height = 27 + drives.Length * 22;
            }
            else
            {
                for (int i = 0; i < driveBoxes.Count; i++)
                {
                    driveBoxes[i].Update(drives[i]);
                }
            }

            UpdateHeight();
        }

        private int GetUsedRAM()
        {
            return (int)Math.Round(100 - (double)PC.AvailablePhysicalMemory / (double)PC.TotalPhysicalMemory * 100);
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
            UpdateHeight();
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
                    UpdateHeight();

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

        public void UpdateSettings()
        {
            diskFrame.Visible = Properties.Settings.Default.disk;

            if (batteryFrame.Visible = Properties.Settings.Default.battery1)
            {
                if (power.PowerLineStatus == PowerLineStatus.Online)
                {
                    batteryFrame.Visible = Properties.Settings.Default.battery2;
                }
            }

            player.settings.volume = Properties.Settings.Default.playervolume;

            UpdateHeight();
        }

        private void mouse_move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rectangle ScreenArea = Screen.FromControl(this).WorkingArea;
                Top = Math.Min(Cursor.Position.Y, ScreenArea.Height - Height);
            }
        }

        private void player_statechanged(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            switch (player.playState) {
                case WMPPlayState.wmppsPlaying:
                    btn_play.Text = "Pause";
                    btn_play.BackColor = UI.blue;
                    playerinfo.Text = player.currentMedia.name;
                    break;
                case WMPPlayState.wmppsReconnecting:
                case WMPPlayState.wmppsTransitioning:
                case WMPPlayState.wmppsBuffering:
                    playerinfo.Text = "loading...";
                    break;
                case WMPPlayState.wmppsPaused:
                    playerinfo.Text = "paused";
                    break;
                default:
                    playerinfo.Text = player.playState.ToString();
                    break;
            }
            //playerinfo.Text = player.playState.ToString();
        }

        private void mainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Dispose();
            driveTimer.Dispose();
            hotkey.Unregiser();
            System.Threading.Thread.Sleep(20);
        }

        private void UpdateHeight()
        {
            int baseHeight = 93 + (batteryFrame.Visible ? 55 : 0) + (diskFrame.Visible ? 55 : 0);
            contentPanel.Height = baseHeight + driveFrame.Height + mediaFrame.Height;
            Height = contentPanel.Height + 20;
        }
    }
}
