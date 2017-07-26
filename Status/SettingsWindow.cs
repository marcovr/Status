using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Status
{
    public partial class SettingsWindow : Form
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void Btn_close_click(object sender, EventArgs e)
        {
            UI.window.player.settings.volume = Properties.Settings.Default.playervolume;
            Close();
        }

        private void Btn_save_click(object sender, EventArgs e)
        {
            //Save
            Properties.Settings.Default.battery1 = checkbox_battery1.Checked;
            Properties.Settings.Default.battery2 = checkbox_battery2.Checked;
            Properties.Settings.Default.playersource = radioButton1.Checked ? 0 : 1;
            Properties.Settings.Default.playersource1 = textBox1.Text;
            Properties.Settings.Default.playersource2 = textBox2.Text;
            Properties.Settings.Default.playervolume = volumeBar.Value;

            Properties.Settings.Default.Save();

            UI.window.UpdateSettings();

            Close();
        }

        private void Window_loading(object sender, EventArgs e)
        {
            Screen myScreen = Screen.FromControl(this);
            Rectangle area = myScreen.WorkingArea;
            Left = area.Width - 230;
            Top = 120;
            
            checkbox_battery1.Checked = Properties.Settings.Default.battery1;
            checkbox_battery2.Checked = Properties.Settings.Default.battery2;
            if (Properties.Settings.Default.playersource == 0)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
            textBox1.Text = Properties.Settings.Default.playersource1;
            textBox2.Text = Properties.Settings.Default.playersource2;
            volumeBar.Value = Properties.Settings.Default.playervolume;
        }

        private void Volume_changing(object sender, EventArgs e)
        {
            UI.window.player.settings.volume = volumeBar.Value;
            volumeTooltip.SetToolTip(volumeBar, volumeBar.Value.ToString());
        }

        private void VolumeBar_mouse_enter(object sender, EventArgs e)
        {
            volumeTooltip.SetToolTip(volumeBar, volumeBar.Value.ToString());
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(UI.border, 1, 1, Width - 2, Height - 2);
            base.OnPaint(e);
        }
    }
}
