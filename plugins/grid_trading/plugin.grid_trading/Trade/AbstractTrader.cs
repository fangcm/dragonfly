﻿//调用32位程序：    
//1>C#的结构体定义时要设置内存布局为顺序布局（即[StructLayout(LayoutKind.Sequential)]）。    
//2>如果结构体有字符串，记得要设置其大小（即[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]）。    
//3>如果是C#端发送到C++端，记得把要发送的COPYDATASTRUCT 对象开辟一段“非托管内存”,然后赋值发送，因为C#内存机制为自动回收（就是系统帮你托  
//管了，你不必担心内存泄漏问题），这样若果你不开辟直接发送的话，出了这个函数作用域，局部内存就会被回收，也就发送不到C++端了（你可以理解
//为C++的局部变量的意思），因此要用Marshal.AllocHGlobal一份，赋值在发送，发送完记得释放掉
//C#端钩子截获的消息的结构（对应WH_CALLWNDPROC）  
//mbd 这个结构我找了好久，什么钩子对应什么结构  
//网上只有监听鼠标啊，键盘啥的钩子结构，很少有监听SendMessage消息的钩子结构，为此度娘了一番，msdn了一番,  
//找到钩子回调的原型函数ShellPro，然后几经周折发现CWPSTRUCT这个结构，看着有点儿眼熟，发现是上面那篇博客有提到过,  
//于是再看了看,尼玛有点怪,于是在msdn该结构类型，加上[StructLayout(LayoutKind.Sequential)]，    
//转换C#类型，调试，然后终于是ok了
//这里COPYDATASTRUCT对应C++的COPYDATASTRUCT，只不过是把它转为C#结构体  
//注意结构体上面要加上[StructLayout(LayoutKind.Sequential)]，表示结构体为顺序布局
//启用非托管代码 

using Dragonfly.Common.Utils;
using Dragonfly.Plugin.GridTrading.Utils;
using Dragonfly.Plugin.GridTrading.Utils.Win32;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Dragonfly.Plugin.GridTrading.Trade
{
    public abstract class AbstractTrader
    {
        protected IntPtr hMainWnd;    // 主窗口句柄

        internal void Log(LoggType type, string msg)
        {
            LoggerUtil.Log(type, msg);
        }

        public bool Init(string appClassName, string appName)
        {
            hMainWnd = UnsafeNativeMethods.FindWindow(appClassName, appName);
            if (hMainWnd == IntPtr.Zero)
                return false;

            return true;
        }

        protected IntPtr FindHwndInApp(string lpClassName, string lpWindowName)
        {
            WindowFinder finder = new WindowFinder(hMainWnd, lpClassName, lpWindowName);
            return finder.FoundHandle;
        }

        protected IntPtr FindHwndInParent(IntPtr hParent, IntPtr hChildAfter, string lpClassName, string lpWindowName)
        {
            return UnsafeNativeMethods.FindWindowEx(hParent, hChildAfter, lpClassName, lpWindowName);
        }

        protected IntPtr FindHwndInParentRecursive(IntPtr hParent, string lpClassName, string lpWindowName)
        {
            WindowFinder finder = new WindowFinder(hParent, lpClassName, lpWindowName);
            return finder.FoundHandle;
        }

        protected IntPtr FindVisibleHwndInParent(IntPtr hParent, IntPtr hChildAfter, string lpClassName, string lpWindowName)
        {
            IntPtr retHandle = hChildAfter;
            do
            {
                retHandle = UnsafeNativeMethods.FindWindowEx(hParent, retHandle, lpClassName, lpWindowName);
                if (retHandle == IntPtr.Zero)
                {
                    break;
                }
                if (SafeNativeMethods.IsWindowVisible(retHandle))
                {
                    break;
                }
            } while (retHandle != IntPtr.Zero);

            return retHandle;
        }

        protected static int GetTreeViewItemCount(IntPtr hTreeView)
        {
            //return NativeMethods.SendMessage(hTreeView, NativeMethods.TVM_GETCOUNT, 0, 0);
            return 0;
        }

        protected void SelectTreeViewItem(IntPtr hTreeView, IntPtr hItem)
        {
            //NativeMethods.SendMessage(hTreeView, NativeMethods.TVM_SELECTITEM, NativeMethods.TVGN_CARET, hItem);
        }



        public static string GetWindowText(IntPtr hWnd)
        {
            var builder = new StringBuilder();
            return GetWindowText(hWnd, builder);
        }

        public static string GetWindowText(IntPtr hWnd, StringBuilder builder)
        {

            //int length = UnsafeNativeMethods.GetWindowTextLength(hWnd);
            //builder.Capacity = Math.Max(builder.Capacity, length + 1);
            //UnsafeNativeMethods.GetWindowText(hWnd, builder, builder.Capacity);
            //return builder.ToString();

            return "";
        }

        public static int SetWindowText(IntPtr handle, string text)
        {
            //return NativeMethods.SetWindowText(handle, text);
            return 0;
        }

        public static void SetEditText(IntPtr handle, string text)
        {
           // NativeMethods.SendMessage(handle, NativeMethods.WM_SETTEXT, 0, text);
        }

        public static string GetEditText(IntPtr handle)
        {
            StringBuilder data = new StringBuilder(32768);
           // NativeMethods.SendMessage(handle, NativeMethods.WM_GETTEXT, data.Capacity, data);
            return data.ToString();
        }

        public static void SetRichEditText(IntPtr handle, string text)
        {
           // NativeMethods.SendMessage(handle, NativeMethods.EM_SETSEL, 0, -1);
           // NativeMethods.SendMessage(handle, NativeMethods.EM_REPLACESEL, 1, text);
        }

        public static void ClickButton(IntPtr hButton)
        {
            //NativeMethods.PostMessage(hButton, (int)NativeMethods.BM_CLICK, 0, 0);
        }

        public static void MouseClick(IntPtr handle, int x, int y)
        {
           // NativeMethods.SendMessage(handle, NativeMethods.WM_LBUTTONDOWN, 0x00000001, MAKELPARAM(x, y));
           // Delay(5);
           // NativeMethods.SendMessage(handle, NativeMethods.WM_LBUTTONUP, 0x00000000, MAKELPARAM(x, y));
        }

        public static void MouseDoubleClick(IntPtr handle, int x, int y)
        {
           // NativeMethods.SendMessage(handle, NativeMethods.WM_LBUTTONDBLCLK, 0, MAKELPARAM(x, y));

        }




        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)//毫秒
            {
                Application.DoEvents();
            }
        }

        public static int MAKELPARAM(int x, int y)
        {
            return ((y << 16) | (x & 0xFFFF));
        }



    }
}
