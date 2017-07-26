using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Status
{
    class Hotkey
    {
        [Flags]
        public enum Modifiers : uint
        {
            None = 0,
            Alt = 1,
            Ctrl = 2,
            Shift = 4,
            Win = 8
        }

        private Modifiers modifier;
	    private Keys key;
        private int id;

        private static HotkeyManager manager = new HotkeyManager();

        public delegate void HotkeyFiredEvent();
        public event HotkeyFiredEvent Fired;

        public Hotkey(Modifiers modifier, Keys key)
	    {
	        this.modifier = modifier;
	        this.key = key;
	        id = GetHashCode();
	    }

        public bool Register()
	    {
            return manager.Register(this);
	    }
	 
	    public bool Unregister()
	    {
            return manager.Unregister(this);
	    }

        public static void UnregisterAll()
        {
            manager.UnregisterAll();
        }

        // pseudo-window to manage hotkeys
        private class HotkeyManager : NativeWindow
        {
            [DllImport("user32.dll")]
            private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

            [DllImport("user32.dll")]
            private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

            //windows message id for hotkey
            private const int WM_HOTKEY_MSG_ID = 0x0312;
            private static List<Hotkey> hotkeys = new List<Hotkey>();

            protected override void WndProc(ref Message m)
            {
                // check if we got a hot key pressed.
                if (m.Msg == WM_HOTKEY_MSG_ID)
                {
                    // get the keys.
                    Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                    Modifiers modifier = (Modifiers)((int)m.LParam & 0xFFFF);

                    foreach (Hotkey hotkey in hotkeys)
                    {
                        if (key == hotkey.key && modifier == hotkey.modifier)
                        {
                            hotkey.Fired?.Invoke();
                        }
                    }
                }

                base.WndProc(ref m);
            }

            public bool Register(Hotkey hotkey)
            {
                hotkeys.Add(hotkey);
                return RegisterHotKey(Handle, hotkey.id, (int)hotkey.modifier, (int)hotkey.key);
            }

            public bool Unregister(Hotkey hotkey)
            {
                hotkeys.Remove(hotkey);
                return UnregisterHotKey(Handle, hotkey.id);
            }

            public void UnregisterAll()
            {
                foreach (Hotkey hotkey in hotkeys)
                {
                    UnregisterHotKey(Handle, hotkey.id);
                }
                hotkeys.Clear();
            }
        }
    }
}
