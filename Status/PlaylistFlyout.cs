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
    public partial class PlaylistFlyout : Form
    {
        public PlaylistFlyout()
        {
            InitializeComponent();
        }

        Timer timer;

        private void window_loading(object sender, EventArgs e)
        {
            Screen myScreen = Screen.FromControl(this);
            Rectangle area = myScreen.WorkingArea;
            Left = area.Width - Width - 220;
            Top = 100;

            timer = new Timer() { Interval = 10000 };
            timer.Tick += update;
            timer.Start();

            update(null, null);
        }

        private void update(object sender, EventArgs e)
        {
            XmlDocument dom = new XmlDocument();
            try
            {
                dom.Load("http://mobile.swr3.de/common/nocache/swr3live.xml");
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
                    PlaylistItem p = new PlaylistItem();
                    if (i == 2)
                    {
                        p.setCurrent();
                    }
                    p.setData(node.ChildNodes[1].InnerText, node.FirstChild.InnerText, node.ChildNodes[2].InnerText, node.ChildNodes[3].InnerText);
                    playlist.Controls.Add(p);
                }
            }
            else
            {
                for (int i = 1; i < swr3.ChildNodes.Count - 1; i++)
                {
                    XmlNode node = swr3.ChildNodes[i];
                    PlaylistItem p = playlist.Controls[i - 1] as PlaylistItem;
                    p.setData(node.ChildNodes[1].InnerText, node.FirstChild.InnerText, node.ChildNodes[2].InnerText, node.ChildNodes[3].InnerText);
                }
            }
        }

        private void btn_close_click(object sender, EventArgs e)
        {
            timer.Dispose();
            this.Close();
        }


        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }
    }
}
