using Dragonfly.Plugin.Task.Logger;
using System;
using System.Collections;
using System.Collections.Specialized;

namespace Dragonfly.Plugin.Task
{
    internal class LoggerUtil
    {
        private static TaskMainPanel taskMainPanel;
        private static LoggerReport loggerReport;

        public static void Init(TaskMainPanel taskMainPanel)
        {
            loggerReport.Init(JobSetting.GetInstance().LastTriggerTime);

            LoggerUtil.taskMainPanel = taskMainPanel;
            IList loggInfos = Logger.Logger.LoggInfos;
            foreach (LoggInfo loggInfo in loggInfos)
            {
                loggerReport.CaculateFixedTime(loggInfo.Date, loggInfo.Type);
                InserLineToTaskMainPanel(loggInfo.Date, loggInfo.Type, loggInfo.Text);
            }

            Logger.Logger.LoggInfos.CollectionChanged += LoggInfos_CollectionChanged;
        }

        private static void LoggInfos_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            IList loggInfos =  e.NewItems;
            foreach(LoggInfo loggInfo in loggInfos)
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
