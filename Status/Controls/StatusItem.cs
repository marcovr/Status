using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
