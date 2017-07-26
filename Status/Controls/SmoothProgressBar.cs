using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Status
{
    public class SmoothProgressBar : ProgressBar
    {
        private static Brush green = new SolidBrush(Color.FromArgb(255, 6, 176, 37));
        private static Brush yellow = new SolidBrush(Color.FromArgb(255, 218, 203, 38));
        private static Brush red = new SolidBrush(Color.FromArgb(255, 218, 38, 38));

        private int SmoothValue = -1;

        public bool InvertedCritical = false;

        public SmoothProgressBar()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (SmoothValue == -1)
            {
                // First value - jump directly to value
                SmoothValue = Value;
            }
            else
            {
                // Smooth Transition
                SmoothValue += Math.Sign(Value - SmoothValue);
            }
            double percent = (double)SmoothValue / Maximum;

            Rectangle rectangle = e.ClipRectangle;
            rectangle.Width = (int)Math.Round(rectangle.Width * percent) - 2;
            ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rectangle.Height = Height - 2;

            Brush brush;
            if (InvertedCritical)
            {
                brush = percent < 0.1 ? red : percent < 0.25 ? yellow : green;
            }
            else
            {
                brush = percent > 0.9 ? red : percent > 0.75 ? yellow : green;
            }
            e.Graphics.FillRectangle(brush, 1, 1, rectangle.Width, rectangle.Height);
        }
    }
}
