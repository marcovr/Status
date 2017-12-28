using System;
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
                double fraction = (double)drive.TotalFreeSpace / drive.TotalSize;
                return (int)Math.Round(100 - fraction * 100);
            }
            catch
            {
                return 0;
            }
        }
    }
}
