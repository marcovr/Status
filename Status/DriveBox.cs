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
        public DriveInfo drive;
        public ProgressBarEx progressbar;
        public Label label;
        public PictureBox picturebox;

        public DriveBox(DriveInfo drive)
        {
            this.drive = drive;
            int n = UI.window.driveBoxes.Count;

            progressbar = new ProgressBarEx()
            {
                Location = new Point(28, 19 + n * 22),
                Size = new Size(108, 16),
                Value = GetUsedSpace()
            };
            UI.window.driveFrame.Controls.Add(progressbar);

            label = new Label()
            {
                Location = new Point(142, 22 + n * 22),
                AutoSize = true,
                Size = new Size(22, 13),
                Text = drive.Name
            };
            UI.window.driveFrame.Controls.Add(label);

            picturebox = new PictureBox()
            {
                BackColor = Color.Transparent,
                Location = new Point(6, 19 + n * 22),
                Size = new Size(16, 16),
                Image = Win32.getImage(drive.Name)
            };
            UI.window.driveFrame.Controls.Add(picturebox);
        }

        public void Update(DriveInfo newdrive)
        {
            if (newdrive.Name != drive.Name)
            {
                label.Text = newdrive.Name;
                picturebox.Image = Win32.getImage(newdrive.Name);
            }
            drive = newdrive;
            progressbar.Value = GetUsedSpace();
        }

        private int GetUsedSpace()
        {
            try
            {
                return (int)Math.Round(100 - (double)drive.TotalFreeSpace / (double)drive.TotalSize * 100);
            }
            catch
            {
                return 0;
            }
        }
    }
}
