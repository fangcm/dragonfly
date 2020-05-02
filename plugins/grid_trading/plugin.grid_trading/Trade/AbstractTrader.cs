using Dragonfly.Plugin.GridTrading.Utils;
using Dragonfly.Plugin.GridTrading.Utils.Win32;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

        internal bool ValidateTipText(string tipText, Dictionary<string, string> patten)
        {
            Dictionary<string, string> pattenCopy = new Dictionary<string, string>(patten);
            string[] tipTextArray = tipText.Split('\n');
            foreach (string line in tipTextArray)
            {
                string[] sKeyValue = line.Split(':');
                if (sKeyValue.Length != 2)
                    continue;
                string key = sKeyValue[0].Trim();
                string value = sKeyValue[1].Trim();

                if (pattenCopy.ContainsKey(key))
                {
                    if (Regex.IsMatch(value, pattenCopy[key]))
                    {
                        pattenCopy.Remove(key);
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            if (pattenCopy.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }

}