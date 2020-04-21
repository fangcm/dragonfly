using Dragonfly.Common.Utils;
using System;
using System.Collections.Specialized;

namespace Dragonfly.Plugin.GridTrading.Utils
{
    internal enum LoggType
    {
        Trigger,
        Suspend,
        Resume,
        Other
    }

    internal class LoggerUtil
    {
        private static GridTradingMainPanel gridTradingMainPanel;

        public static void Init(GridTradingMainPanel gridTradingMainPanel)
        {
            LoggerUtil.gridTradingMainPanel = gridTradingMainPanel;

            foreach (LoggInfo loggInfo in ReadableLogger.LoggInfos)
            {
                LoggType loggType = ConvertToLoggType(loggInfo.Type);
                InserLineToGridTradingMainPanel(loggInfo.Date, loggType, loggInfo.Text);
            }

            ReadableLogger.LoggInfos.CollectionChanged += LoggInfos_CollectionChanged;
        }

        private static void LoggInfos_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (LoggInfo loggInfo in e.NewItems)
            {
                LoggType loggType = ConvertToLoggType(loggInfo.Type);
                InserLineToGridTradingMainPanel(loggInfo.Date, loggType, loggInfo.Text);
            }
        }

        public static void Log(LoggType type, string msg)
        {
            ReadableLogger.Instance.Log(type.ToString(), msg);
        }

        public static void InserLineToGridTradingMainPanel(DateTime date, LoggType type, string msg)
        {
            string typeInfo;
            switch (type)
            {
                case LoggType.Trigger:
                    typeInfo = "触发";
                    break;
                case LoggType.Suspend:
                    typeInfo = "休息";
                    break;
                case LoggType.Resume:
                    typeInfo = "唤醒";
                    break;
                default:
                    typeInfo = "其它";
                    break;
            }
            LoggerUtil.gridTradingMainPanel.InsertLine(date, typeInfo, msg);
        }

        private static LoggType ConvertToLoggType(string type)
        {
            LoggType loggType;
            if (!Enum.TryParse<LoggType>(type, out loggType))
            {
                Logger.error("LoggerUtil", "loggInfo.Type is error, type:" , type);
                return LoggType.Other;
            }
            return loggType;
        }
    }
}
