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
    public partial class mainWindow : BaseForm
    {
        private PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private PowerStatus power = SystemInformation.PowerStatus;
        private ComputerInfo PC = new ComputerInfo();
        private Timer fastTimer, slowTimer;
        private DriveInfo[] drives;
        public List<DriveItem> driveItems = new List<DriveItem>();
        private Hotkey mediakey, playlistkey;
        
        public mainWindow()
        {
            InitializeComponent();
            UI.window = this;
            Top = 100;

            UpdateSettings();

            playerinfo.Visible = false;
            mediaFrame.Height = 50;

            UpdateFast(null, null);
            UpdateSlow(null, null);

            slowTimer = new Timer() { Interval = 5000 };
            slowTimer.Tick += UpdateSlow;
            slowTimer.Start();

            fastTimer = new Timer() { Interval = 1000 };
            fastTimer.Tick += UpdateFast;
            fastTimer.Start();

            mediakey = new Hotkey(Hotkey.Modifiers.None, Keys.MediaPlayPause);
            mediakey.Fired += Mediakey_Fired;
            mediakey.Register();

            playlistkey = new Hotkey(Hotkey.Modifiers.None, Keys.SelectMedia);
            playlistkey.Fired += Playlistkey_Fired;
            playlistkey.Register();
        }

        private void UpdateFast(object sender, EventArgs e)
        {
            cpuItem.Value = (int)cpuCounter.NextValue();
            ramItem.Value = GetUsedRAM();
            Left = Screen.FromControl(this).WorkingArea.Width - 210;
        }

        private void UpdateSlow(object sender, EventArgs e)
        {
            batteryItem.Value = (int)Math.Round(power.BatteryLifePercent * 100);
            if (batteryFrame.Visible = Properties.Settings.Default.battery1)
            {
                if (power.PowerLineStatus == PowerLineStatus.Online)
                {
                    batteryItem.Image = Properties.Resources.Line;
                    batteryFrame.Visible = Properties.Settings.Default.battery2;
                }
                else
                {
                    batteryItem.Image = Properties.Resources.Battery;
                }
            }

            drives = DriveInfo.GetDrives();
            if (drives.Length != driveItems.Count)
            {
                driveFrame.Controls.Clear();
                driveItems.Clear();

                for (int i = 0; i < drives.Length; i++)
                {
                    DriveItem driveI = new DriveItem(drives[i])
                    {
                        Location = new Point(4, 17 + i * 22)
                    };
                    driveItems.Add(driveI);
                    UI.window.driveFrame.Controls.Add(driveI);
                }

                driveFrame.Height = 27 + drives.Length * 22;
            }
            else
            {
                for (int i = 0; i < drives.Length; i++)
                {
                    driveItems[i].Update(drives[i]);
                }
            }

            UpdateHeight();
        }

        private int GetUsedRAM()
        {
            return (int)Math.Round(100 - (double)PC.AvailablePhysicalMemory / (double)PC.TotalPhysicalMemory * 100);
        }

        private void Btn_stop_click(object sender, EventArgs e)
        {
            if (!IsMediaStopped())
            {
                Stop();
            }
        }

        private void Btn_play_click(object sender, EventArgs e)
        {
            PlayOrPause();
        }

        private void Btn_close_click(object sender, EventArgs e)
        {
            Application.Exit();
            //Environment.Exit(0);
        }

        private void Btn_settings_click(object sender, EventArgs e)
        {
            new SettingsWindow().Show();
        }

        private void Playerinfo_Click(object sender, EventArgs e)
        {
            new PlaylistWindow().Show();
        }

        private void Mediakey_Fired()
        {
            if (!IsMediaStopped())
            {
                Stop();
            }
            else
            {
                PlayOrPause();
            }
        }

        private void Playlistkey_Fired()
        {
            new PlaylistWindow().Show();
        }

        private bool IsMediaStopped()
        {
            return btn_stop.BackColor != UI.blue;
        }

        private void Stop()
        {
            player.Ctlcontrols.stop();
            btn_play.Text = "Play";
            btn_play.BackColor = UI.blue;
            btn_stop.BackColor = UI.grey;
            playerinfo.Text = "...";
            playerinfo.Visible = false;
            mediaFrame.Height = 50;
            UpdateHeight();
        }

        private void PlayOrPause()
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

        private void Player_statechanged(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
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

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            fastTimer.Dispose();
            slowTimer.Dispose();
            cpuCounter.Dispose();
            player.Dispose();
            Hotkey.Dispose();
        }

        private void UpdateHeight()
        {
            int baseHeight = 93 + (batteryFrame.Visible ? 55 : 0);
            contentPanel.Height = baseHeight + driveFrame.Height + mediaFrame.Height;
            Height = contentPanel.Height + 20;
        }
    }
}
