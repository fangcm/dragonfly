﻿using Dragonfly.Plugin.GridTrading.Utils;
using Dragonfly.Plugin.GridTrading.Utils.Win32;
using System;

namespace Dragonfly.Plugin.GridTrading.Trade
{
    public abstract class AbstractTrader
    {
        protected IntPtr hAppWnd;    // 主窗口句柄（可能是外壳行情，如果无行情则与hMainWnd同）
        protected IntPtr hMainWnd;    // 交易软件主窗口句柄

        internal void Log(LoggType type, string msg)
        {
            LoggerUtil.Log(type, msg);
        }

        internal bool Init(string appClassName, string appName)
        {
            hAppWnd = hMainWnd = NativeMethods.FindWindow(appClassName, appName);
            if (hMainWnd == IntPtr.Zero)
                return false;

            return true;
        }

    }

}