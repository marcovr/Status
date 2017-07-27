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
    public partial class PlaylistWindow : BaseForm
    {
        private const string SWR3_XML = "http://mobile.swr3.de/common/nocache/swr3live.xml";
        private Timer timer;

        public PlaylistWindow()
        {
            InitializeComponent();
            playlist.Padding = new Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
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
                    playlist.Controls.Add(item, 0, i - 1);
                    item.Anchor = AnchorStyles.Left | AnchorStyles.Right;
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
    }
}
