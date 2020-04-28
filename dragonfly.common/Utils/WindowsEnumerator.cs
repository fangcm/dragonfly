using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Dragonfly.Common.Utils
{
    public class WindowsEnumerator
    {
        private List<WindowInfo> _windows = new List<WindowInfo>();

        public WindowsEnumerator()
        {
        }

        public List<WindowInfo> Windows
        {
            get
            {
                return _windows;
            }
        }

        public void Begin(IntPtr hWndParent)
        {
            _windows.Clear();

            CallbackEnum enumChildCallback = new CallbackEnum(EnumChildCallBack);
            EnumChildWindows(hWndParent, enumChildCallback, 0);
        }

        private int EnumChildCallBack(IntPtr hWnd, int lParam)
        {
            WindowInfo info = new WindowInfo(hWnd);

            _windows.Add(info);
            return 1;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("User32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern Boolean EnumChildWindows(IntPtr hWndParent, Delegate lpEnumFunc, int lParam);

        public delegate int CallbackEnum(IntPtr hWnd, int lParam);
    }

    public class WindowInfo
    {
        private string _Text;
        public string Text
        {
            get
            {
                if (_Text == null)
                {
                    int textLength = GetWindowTextLength(Handle);
                    if (SystemInformation.DbcsEnabled)
                        textLength = (textLength * 2) + 1;
                    textLength++;

                    StringBuilder text = new StringBuilder(textLength);
                    Marshal.ThrowExceptionForHR(GetWindowText(Handle, text, text.Capacity));
                    _Text = text.ToString();
                }
                return _Text;
            }
        }

        public bool Visible
        {
            get
            {
                return IsWindowVisible(Handle);
            }
        }

        public string ClassName { get; private set; }
        public IntPtr Handle { get; private set; }

        public WindowInfo(IntPtr hWnd)
        {
            Handle = hWnd;
            StringBuilder text = new StringBuilder(256);
            int hr = GetClassName(hWnd, text, 256);
            Marshal.ThrowExceptionForHR(hr);
            ClassName = text.ToString().Trim();
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("user32.dll")]
        internal static extern int GetClassName(IntPtr hWnd, StringBuilder className, int length);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("User32.dll")]
        public static extern Int32 GetWindowText(IntPtr hWnd, StringBuilder text, int nMaxCount);

    }

}
