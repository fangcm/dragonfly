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
            IList loggInfos = Logger.Logger.LoggInfos;
            foreach (LoggInfo loggInfo in loggInfos)
            {
                AddMsg(loggInfo.Date, loggInfo.Type, loggInfo.Text);
            }

            Logger.Logger.LoggInfos.CollectionChanged += LoggInfos_CollectionChanged;
        }

        private static void LoggInfos_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            IList loggInfos =  e.NewItems;
            foreach(LoggInfo loggInfo in loggInfos)
            {
                AddMsg(loggInfo.Date, loggInfo.Type, loggInfo.Text);
            }
        }

        public static void Log(Logger.LoggType type, string msg)
        {
            Logger.Logger.Default.Log(type, msg);
        }

        public static void AddMsg(DateTime date, Logger.LoggType type, string msg)
        {
            string typeInfo = "其它";
            switch(type)
            {
                case Logger.LoggType.Command:
                    typeInfo = "命令";
                    break;
                case Logger.LoggType.LockScreen:
                    typeInfo = "锁屏";
                    break;
                case Logger.LoggType.Logoff:
                    typeInfo = "注销";
                    break;
                case Logger.LoggType.Suspend:
                    typeInfo = "休眠";
                    break;
                case Logger.LoggType.SystemShutdown:
                    typeInfo = "关机";
                    break;
                case Logger.LoggType.Resume:
                    typeInfo = "唤醒";
                    break;
            }
            LoggerUtil.taskMainPanel.InsertLine(date, typeInfo, msg);
        }
    }
}
