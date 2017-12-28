using System.Drawing;
using System.Windows.Forms;

namespace Status
{
    public partial class StatusItem : UserControl
    {
        public StatusItem()
        {
            InitializeComponent();
        }

        public Image Image
        {
            get
            {
                return pictureBox.Image;
            }
            set
            {
                pictureBox.Image = value;
            }
        }

        public int Value
        {
            get
            {
                return progressBar.Value;
            }
            set
            {
                progressBar.Value = value;
            }
        }

        public bool InvertedCritical
        {
            get
            {
                return progressBar.InvertedCritical;
            }
            set
            {
                progressBar.InvertedCritical = value;
            }
        }

        public string Label
        {
            get
            {
                return label.Text;
            }
            set
            {
                label.Text = value;
            }
        }
    }
}
