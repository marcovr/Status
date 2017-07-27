using Status.Properties;
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
    public partial class SettingsWindow : BaseForm
    {
        private Settings Settings = Properties.Settings.Default;

        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void Btn_close_click(object sender, EventArgs e)
        {
            UI.window.player.settings.volume = Settings.playervolume;
            Close();
        }

        private void Btn_save_click(object sender, EventArgs e)
        {
            //Save
            Settings.battery1 = checkbox_battery1.Checked;
            Settings.battery2 = checkbox_battery2.Checked;
            Settings.playersource = radioButton1.Checked ? 1 : 2;
            Settings.playersource1 = textBox1.Text;
            Settings.playersource2 = textBox2.Text;
            Settings.playervolume = volumeBar.Value;

            Settings.Save();

            UI.window.UpdateSettings();

            Close();
        }

        private void Window_loading(object sender, EventArgs e)
        {
            Screen myScreen = Screen.FromControl(this);
            Rectangle area = myScreen.WorkingArea;
            Left = area.Width - 230;
            Top = 120;
            
            checkbox_battery1.Checked = Settings.battery1;
            checkbox_battery2.Checked = Settings.battery2;
            radioButton1.Checked = Settings.playersource == 1;
            radioButton2.Checked = Settings.playersource == 2;
            textBox1.Text = Settings.playersource1;
            textBox2.Text = Settings.playersource2;
            volumeBar.Value = Settings.playervolume;
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
    }
}
