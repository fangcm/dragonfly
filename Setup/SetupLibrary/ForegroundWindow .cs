using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SetupLibrary
{
    public class ForegroundWindow : IWin32Window
    {
        private static ForegroundWindow _window = new ForegroundWindow();
        private ForegroundWindow() { }

        public static IWin32Window Instance
        {
            get { return _window; }
        }

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        IntPtr IWin32Window.Handle
        {
            get
            {
                return GetForegroundWindow();
            }
        }
    }
}
