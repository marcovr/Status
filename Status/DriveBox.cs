using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Status
{
    public class DriveBox
    {
        public DriveBox(int driveIndex)
        {
            int n = UI.window.driveBoxes.Count;
            this.driveIndex = driveIndex;
            drive = UI.window.drives[driveIndex];

            progressbar = new ProgressBarEx();
            progressbar.Location = new Point(28, 19 + n * 22);
            progressbar.Size = new Size(108, 16);
            progressbar.Value = Win32.getFreeSpace(driveIndex);
            UI.window.driveFrame.Controls.Add(progressbar);

            label = new Label();
            label.Location = new Point(142, 22 + n * 22);
            label.AutoSize = true;
            label.Size = new Size(22, 13);
            label.Text = drive.Name;
            UI.window.driveFrame.Controls.Add(this.label);

            picturebox = new PictureBox();
            picturebox.BackColor = Color.Transparent;
            picturebox.Location = new Point(6, 19 + n * 22);
            picturebox.Size = new Size(16, 16);
            picturebox.Image = Win32.getImage(drive.Name);
            UI.window.driveFrame.Controls.Add(picturebox);
        }

        public int driveIndex;
        public DriveInfo drive;
        public ProgressBarEx progressbar;
        public Label label;
        public PictureBox picturebox;
    }
}
