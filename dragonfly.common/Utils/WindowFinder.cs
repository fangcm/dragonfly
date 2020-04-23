﻿using System;
using System.Runtime.InteropServices;

namespace Dragonfly.Common.Utils
{
    public class WindowFinder
    {
        private string m_classname; // class name to look for
        private string m_caption; // caption name to look for

        private IntPtr m_hWnd; // HWND if found
        private IntPtr m_hParentWnd;

        public IntPtr FoundHandle
        {
            get { return m_hWnd; }
        }

        public IntPtr FoundParentHandle
        {
            get { return m_hParentWnd; }
        }

        public WindowFinder(IntPtr hwndParent, string classname, string caption)
        {
            m_hWnd = IntPtr.Zero;
            m_classname = classname;
            m_caption = caption;
            FindChildClassHwnd(hwndParent, IntPtr.Zero);
        }

        private bool FindChildClassHwnd(IntPtr hwndParent, IntPtr lParam)
        {
            EnumWindowProc childProc = new EnumWindowProc(FindChildClassHwnd);
            IntPtr hwnd = FindWindowEx(hwndParent, IntPtr.Zero, this.m_classname, this.m_caption);
            if (hwnd != IntPtr.Zero)
            {
                this.m_hWnd = hwnd; // found: save it
                this.m_hParentWnd = hwndParent;
                return false; // stop enumerating
            }
            EnumChildWindows(hwndParent, childProc, IntPtr.Zero); // 递归回调 FindChildClassHwnd
            return true;// keep looking
        }

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "EnumChildWindows")]
        public static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);
        public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
    }
}
