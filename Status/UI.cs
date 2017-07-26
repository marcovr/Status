using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Status
{
    public static class UI
    {
        public static mainWindow window;
        public static Color blue = Color.FromArgb(255, 0, 122, 204);
        public static Color grey = Color.FromArgb(255, 45, 45, 48);
        public static Pen border = new Pen(blue, 2);
    }
}
