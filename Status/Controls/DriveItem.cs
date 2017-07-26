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
    public partial class DriveItem : StatusItem
    {
        private DriveInfo drive;

        public DriveItem(DriveInfo drive)
        {
            this.drive = drive;

            progressBar.Width -= 7;
            label.Left -= 7;

            label.Text = drive.Name;
            pictureBox.Image = Win32.GetImage(drive.Name);
            progressBar.Value = GetUsedSpace();
        }

        public void Update(DriveInfo newdrive)
        {
            if (newdrive.Name != drive.Name)
            {
                label.Text = newdrive.Name;
                pictureBox.Image = Win32.GetImage(newdrive.Name);
            }
            drive = newdrive;
            progressBar.Value = GetUsedSpace();
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
