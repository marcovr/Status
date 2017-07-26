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

        public void SetCurrent()
        {
            //titlelabel.ForeColor = UI.blue;
            //wholabel.ForeColor = UI.blue;
            //timelabel.ForeColor = UI.blue;
            BackColor = UI.blue;
        }

        public string Title
        {
            get
            {
                return titlelabel.Text;
            }
            set
            {
                titlelabel.Text = value;
            }
        }

        public string Who
        {
            get
            {
                return wholabel.Text;
            }
            set
            {
                wholabel.Text = value;
            }
        }

        public string Time
        {
            get
            {
                return timelabel.Text;
            }
            set
            {
                timelabel.Text = value;
            }
        }

        public string ImageURL
        {
            get
            {
                return album.ImageLocation;
            }
            set
            {
                album.LoadAsync(value);
            }
        }

        private void Album_Click(object sender, EventArgs e)
        {
            Clipboard.SetText($"{wholabel.Text} {titlelabel.Text}");
            System.Diagnostics.Process.Start(ytdl, $"{wholabel.Text} | {titlelabel.Text}");
        }
    }
}
