using Dragonfly.Plugin.Task.Logger;
using System;
using System.Collections;
using System.Collections.Specialized;

namespace Dragonfly.Plugin.Task
{
    internal class LoggerUtil
    {
        private static TaskMainPanel taskMainPanel;

        public static void Init(TaskMainPanel taskMainPanel)
        {
            LoggerUtil.taskMainPanel = taskMainPanel;

            foreach (LoggInfo loggInfo in Logger.Logger.LoggInfos)
            {
                InserLineToTaskMainPanel(loggInfo.Date, loggInfo.Type, loggInfo.Text);
            }

            Logger.Logger.LoggInfos.CollectionChanged += LoggInfos_CollectionChanged;
        }

        private static void LoggInfos_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach(LoggInfo loggInfo in e.NewItems)
            {
                InserLineToTaskMainPanel(loggInfo.Date, loggInfo.Type, loggInfo.Text);
            }
        }

        public static void Log(Logger.LoggType type, string msg)
        {
            Logger.Logger.Default.Log(type, msg);
        }

        public static void InserLineToTaskMainPanel(DateTime date, Logger.LoggType type, string msg)
        {
            string typeInfo;
            switch(type)
            {
                case Logger.LoggType.Trigger:
                    typeInfo = "触发";
                    break;
                case Logger.LoggType.Suspend:
                    typeInfo = "休息";
                    break;
                case Logger.LoggType.Resume:
                    typeInfo = "唤醒";
                    break;
                default:
                    typeInfo = "其它";
                    break;
            }
            LoggerUtil.taskMainPanel.InsertLine(date, typeInfo, msg);
        }
    }
}
