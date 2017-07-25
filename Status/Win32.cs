using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Status
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SHFILEINFO
    {
        public IntPtr hIcon;
        public IntPtr iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    };

    static class Win32
    {
        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
        public const uint SHGFI_SMALLICON = 0x1; // 'Small icon

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        public static Image getImage(string Path)
        {
            IntPtr hImgSmall; //the handle to the system image list
            //IntPtr hImgLarge; //the handle to the system image list
            SHFILEINFO shinfo = new SHFILEINFO();

            //Use this to get the Icon
            hImgSmall = SHGetFileInfo(Path, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | SHGFI_SMALLICON);
            //hImgLarge = Win32.SHGetFileInfo(fName, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON);
            //The icon is returned in the hIcon member of the shinfo struct
            Icon myIcon = Icon.FromHandle(shinfo.hIcon);

            return myIcon.ToBitmap();
        }

        public static int getFreeSpace(int n)
        {
            try
            {
                DriveInfo drive = UI.window.drives[n];
                double freeSpace = 100 - (double)drive.TotalFreeSpace / (double)drive.TotalSize * 100;
                return (int)freeSpace;
            }
            catch
            {
                return 0;
            }
        }
    }
}
