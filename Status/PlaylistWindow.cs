using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Status
{
    public partial class PlaylistWindow : Form
    {
        private const string SWR3_XML = "http://mobile.swr3.de/common/nocache/swr3live.xml";
        private Timer timer;

        public PlaylistWindow()
        {
            InitializeComponent();
        }

        private void Window_loading(object sender, EventArgs e)
        {
            Left = Screen.FromControl(this).WorkingArea.Width - Width - 220;
            Top = 100;

            timer = new Timer() { Interval = 10000 };
            timer.Tick += Update;
            timer.Start();

            Update(null, null);
        }

        private void Update(object sender, EventArgs e)
        {
            XmlDocument dom = new XmlDocument();
            try
            {
                dom.Load(SWR3_XML);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }
            XmlNode swr3 = dom.LastChild;

            if (playlist.Controls.Count == 0)
            {
                for (int i = 1; i < swr3.ChildNodes.Count; i++)
                {
                    XmlNode node = swr3.ChildNodes[i];
                    PlaylistItem item = new PlaylistItem()
                    {
                        Title = node.ChildNodes[1].InnerText,
                        Who = node.FirstChild.InnerText,
                        Time = node.ChildNodes[2].InnerText,
                        ImageURL = node.ChildNodes[3].InnerText
                    };
                    playlist.Controls.Add(item);
                }
                if (playlist.Controls.Count >= 2)
                {
                    ((PlaylistItem)playlist.Controls[1]).SetCurrent();
                }
            }
            else
            {
                for (int i = 1; i < swr3.ChildNodes.Count - 1; i++)
                {
                    XmlNode node = swr3.ChildNodes[i];
                    PlaylistItem item = (PlaylistItem)playlist.Controls[i - 1];
                    item.Title = node.ChildNodes[1].InnerText;
                    item.Who = node.FirstChild.InnerText;
                    item.Time = node.ChildNodes[2].InnerText;
                    item.ImageURL = node.ChildNodes[3].InnerText;
                }
            }
        }

        private void Btn_close_click(object sender, EventArgs e)
        {
            timer.Dispose();
            Close();
        }


        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;
        private const int WM_NCHITTEST_MSG_ID = 0x84;
        private const int HTCAPTION = 2;
        private const int HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCHITTEST_MSG_ID)
            {  // Trap Hittest
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                pos = PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)HTCAPTION;  // drag
                    return;
                }
                /*if (pos.X >= ClientSize.Width - cGrip && pos.Y >= ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)HTBOTTOMRIGHT; // resize
                    return;
                }*/
            }
            base.WndProc(ref m);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(UI.border, 1, 1, Width - 2, Height - 2);
            base.OnPaint(e);
        }
    }
}
