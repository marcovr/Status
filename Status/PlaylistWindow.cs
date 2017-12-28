using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace Status
{
    public partial class PlaylistWindow : BaseForm
    {
        private const string SWR3_JSON = "https://www.swr3.de/ext/cf=42/actions/feed/index.json";
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
                string XML;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(SWR3_JSON);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader s = new StreamReader(response.GetResponseStream()))
                {
                    string content = s.ReadToEnd();
                    dynamic data = JsonConvert.DeserializeObject(content);
                    string xmlcontent = data.update["#nowplaying"];
                    XML = "<root>" + xmlcontent + "</root>";
                }

                dom.LoadXml(XML);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                return;
            }
            XmlNode swr3 = dom.LastChild;

            if (playlist.Controls.Count == 0)
            {
                for (int i = 0; i < swr3.ChildNodes.Count; i++)
                {
                    XmlNode node = swr3.ChildNodes[i];
                    PlaylistItem item = new PlaylistItem()
                    {
                        Title = node.LastChild.InnerText.Trim(),
                        Who = node.ChildNodes[1].InnerText.Trim(),
                        Time = node.FirstChild.InnerText.Trim(),
                    };
                    playlist.Controls.Add(item, 0, i);
                    item.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                }
                if (playlist.Controls.Count >= 1)
                {
                    ((PlaylistItem)playlist.Controls[0]).SetCurrent();
                }
            }
            else
            {
                for (int i = 0; i < swr3.ChildNodes.Count; i++)
                {
                    XmlNode node = swr3.ChildNodes[i];
                    PlaylistItem item = (PlaylistItem)playlist.Controls[i];
                    item.Title = node.LastChild.InnerText.Trim();
                    item.Who = node.ChildNodes[1].InnerText.Trim();
                    item.Time = node.FirstChild.InnerText.Trim();
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
