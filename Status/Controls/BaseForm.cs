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
    public partial class BaseForm : Form
    {
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;
        private const int WM_NCHITTEST_MSG_ID = 0x84;
        private const int HTCAPTION = 2;
        private const int HTBOTTOMRIGHT = 17;
        private bool draggable = true;
        private bool resizable = true;

        public bool Draggable
        {
            get { return draggable; }
            set { draggable = value; }
        }

        public bool Resizable
        {
            get { return resizable; }
            set { resizable = value; }
        }

        public BaseForm()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCHITTEST_MSG_ID && (draggable || resizable))
            {  // Trap Hittest
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                pos = PointToClient(pos);
                if (draggable && pos.Y < cCaption)
                {
                    m.Result = (IntPtr)HTCAPTION;  // drag
                    return;
                }
                if (resizable && pos.X >= ClientSize.Width - cGrip && pos.Y >= ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)HTBOTTOMRIGHT; // resize
                    return;
                }
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
