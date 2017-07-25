using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Status
{
    public partial class PlaylistItem : UserControl
    {
        public PlaylistItem()
        {
            InitializeComponent();
        }

        private const string ytdl = @"D:\Documents\Visual Studio 2015\Projects\YTDownloader\bin\Debug\YTDownloader.exe"; 

        public void setCurrent()
        {
            //titlelabel.ForeColor = UI.blue;
            //wholabel.ForeColor = UI.blue;
            //timelabel.ForeColor = UI.blue;
            BackColor = UI.blue;
        }

        public void setData(string title, string who, string time, string picurl)
        {
            titlelabel.Text = title;
            wholabel.Text = who;
            timelabel.Text = time;
            album.LoadAsync(picurl);
        }

        private void album_Click(object sender, EventArgs e)
        {
            Clipboard.SetText($"{wholabel.Text} {titlelabel.Text}");
            System.Diagnostics.Process.Start(ytdl, $"{wholabel.Text} | {titlelabel.Text}");
        }
    }
}
