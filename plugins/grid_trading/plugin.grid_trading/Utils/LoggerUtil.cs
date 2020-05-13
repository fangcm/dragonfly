﻿using Dragonfly.Common.Utils;
using System;
using System.Drawing;
using System.Collections.Specialized;

namespace Dragonfly.Plugin.GridTrading.Utils
{
    internal enum LoggType
    {
        Red, //买入
        Green, //卖出
        Black, //信息
        Gray, //提示 debug
        MediumBlue, //错误
    }

    internal class LoggerUtil
    {
        private static GridTradingMainPanel gridTradingMainPanel;

        public static void Init(GridTradingMainPanel gridTradingMainPanel)
        {
            LoggerUtil.gridTradingMainPanel = gridTradingMainPanel;

            /*
            foreach (LoggInfo loggInfo in ReadableLogger.LoggInfos)
            {
                LoggType loggType = ConvertToLoggType(loggInfo.Type);
                InserLineToGridTradingMainPanel(loggInfo.Date, loggType, loggInfo.Text);
            }

            ReadableLogger.LoggInfos.CollectionChanged += LoggInfos_CollectionChanged;
            */
        }

        private static void LoggInfos_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (LoggInfo loggInfo in e.NewItems)
            {
                LoggType loggType = ConvertToLoggType(loggInfo.Type);
                InserLineToGridTradingMainPanel(loggInfo.Date, loggType, loggInfo.Text);
            }
        }

        public static void Log(LoggType loggType, string msg)
        {
            /*
            ReadableLogger.Instance.Log(type.ToString(), msg);
            */
            InserLineToGridTradingMainPanel(DateTime.Now, loggType, msg);
        }

        public static void InserLineToGridTradingMainPanel(DateTime date, LoggType type, string msg)
        {
            Color foreColor;
            switch (type)
            {
                case LoggType.Red:
                    foreColor = Color.Red;
                    break;
                case LoggType.Green:
                    foreColor = Color.Green;
                    break;
                case LoggType.MediumBlue:
                    foreColor = Color.MediumBlue;
                    break;
                case LoggType.Gray:
                    foreColor = Color.Gray;
                    break;
                case LoggType.Black:
                default:
                    foreColor = Color.Black;
                    break;
            }
            LoggerUtil.gridTradingMainPanel.InsertLine(date, foreColor, msg);
        }

        private static LoggType ConvertToLoggType(string type)
        {
            LoggType loggType;
            if (!Enum.TryParse<LoggType>(type, out loggType))
            {
                Logger.error("LoggerUtil", "loggInfo.Type is error, type:", type);
                return LoggType.Black;
            }
            return loggType;
        }
    }
}
