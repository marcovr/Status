using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Status
{
    public class ProgressBarEx : ProgressBar
    {
        public Brush brush, brush_green, brush_yellow, brush_red;
        public bool invertedCritical = false;
        private int lastValue = -1;
        public ProgressBarEx()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            brush_green = new SolidBrush(Color.FromArgb(255, 6, 176, 37));
            brush_yellow = new SolidBrush(Color.FromArgb(255, 218, 203, 38));
            brush_red = new SolidBrush(Color.FromArgb(255, 218, 38, 38));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            // Smoothe Transition
            if (lastValue == -1)
            {
                lastValue = Value;
            }
            else if (lastValue < (int)Value)
            {
                lastValue++;
            }
            else if (lastValue > (int)Value)
            {
                lastValue--;
            }

            Rectangle rectangle = e.ClipRectangle;
            rectangle.Width = (int)(rectangle.Width * ((double)lastValue / Maximum)) - 2;
            ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rectangle.Height = Height - 2;

            if (invertedCritical)
            {
                if ((double)lastValue / Maximum < 0.1)
                {
                    brush = brush_red;
                }
                else if ((double)lastValue / Maximum < 0.25)
                {
                    brush = brush_yellow;
                }
                else
                {
                    brush = brush_green;
                }
            }
            else
            {
                if ((double)lastValue / Maximum > 0.9)
                {
                    brush = brush_red;
                }
                else if ((double)lastValue / Maximum > 0.75)
                {
                    brush = brush_yellow;
                }
                else
                {
                    brush = brush_green;
                }
            }
            e.Graphics.FillRectangle(brush, 1, 1, rectangle.Width, rectangle.Height);
        }
    }
}
