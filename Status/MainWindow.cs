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
using Status.Properties;

namespace Status
{
    public partial class mainWindow : BaseForm
    {
        private PerformanceCounter cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        private PowerStatus power = SystemInformation.PowerStatus;
        private ComputerInfo PC = new ComputerInfo();
        private Settings Settings = Properties.Settings.Default;
        private Timer fastTimer, slowTimer;
        private DriveInfo[] drives;
        public List<DriveItem> driveItems = new List<DriveItem>();
        private Hotkey mediakey, playlistkey;
        private int retrycount = 0;
        
        public mainWindow()
        {
            InitializeComponent();
            UI.window = this;
            Top = 100;

            playerinfo.Visible = false;
            mediaFrame.Height = 50;
            UpdateSettings();

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
            if (batteryFrame.Visible = Settings.battery1)
            {
                if (power.PowerLineStatus == PowerLineStatus.Online)
                {
                    batteryItem.Image = Resources.Line;
                    batteryFrame.Visible = Settings.battery2;
                }
                else
                {
                    batteryItem.Image = Resources.Battery;
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
            if (StopButtonEnabled())
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
            PlaylistWindow playlist = new PlaylistWindow();
            playlist.Show();
            playlist.Activate();
        }

        private void Mediakey_Fired()
        {
            if (StopButtonEnabled())
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
            PlaylistWindow playlist = new PlaylistWindow();
            playlist.Show();
            playlist.Activate();
        }

        private bool StopButtonEnabled()
        {
            return btn_stop.BackColor == UI.blue;
        }

        private bool MediaButtonEnabled()
        {
            return btn_play.BackColor == UI.blue;
        }

        private void Stop()
        {
            retrycount = 0;
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
            if (!MediaButtonEnabled())
            {
                return;
            }
            retrycount = 0;
            if (player.playState == WMPPlayState.wmppsPlaying)
            {
                player.Ctlcontrols.pause();
                btn_play.Text = "Play";
            }
            else
            {
                if (player.playState == WMPPlayState.wmppsPaused)
                {
                    player.Ctlcontrols.play();
                }
                else
                {
                    StartPlay();
                }
            }
        }

        private void StartPlay()
        {
            player.Ctlcontrols.stop();
            player.URL = (string)Settings["playersource" + Settings.playersource];
            btn_stop.BackColor = UI.blue;
            btn_play.BackColor = UI.grey;
            playerinfo.Visible = true;
            mediaFrame.Height = 75;
            UpdateHeight();
        }

        public void UpdateSettings()
        {
            player.settings.volume = Settings.playervolume;
            UpdateSlow(null, null);
            UpdateFast(null, null);
        }

        private async void Player_statechanged(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            //Debug.Print(player.playState.ToString());
            switch (player.playState) {
                case WMPPlayState.wmppsReady:
                    retrycount++;
                    await Task.Delay(2000);
                    if (retrycount > 0)
                    {
                        if (retrycount <= 5)
                        {
                            StartPlay();
                        }
                        else
                        {
                            Stop();
                        }
                    }
                    break;
                case WMPPlayState.wmppsPlaying:
                    retrycount = 0;
                    btn_play.Text = "Pause";
                    btn_play.BackColor = UI.blue;
                    playerinfo.Text = player.currentMedia.name;
                    break;
                case WMPPlayState.wmppsReconnecting:
                case WMPPlayState.wmppsTransitioning:
                case WMPPlayState.wmppsBuffering:
                    btn_play.BackColor = UI.grey;
                    playerinfo.Text = "loading...";
                    break;
                case WMPPlayState.wmppsPaused:
                    retrycount = 0;
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
