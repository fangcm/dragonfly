using Dragonfly.Common.Utils;
using System;

namespace Dragonfly.Plugin.Task.Utils
{
    internal class LoggerReport
    {
        private int suspendCount = 0;
        private DateTime lastTriggerTime = DateTime.MinValue;

        private void SetLastTriggerTime(DateTime lastTriggerTime)
        {
            this.suspendCount = 0;
            this.lastTriggerTime = lastTriggerTime;
        }

        public void AddItem(DateTime date, string type)
        {
            if ("Suspend".CompareTo(type) != 0 && "Resume".CompareTo(type) != 0 && "Trigger".CompareTo(type) != 0)
            {
                return;
            }
            if (date <= lastTriggerTime)
            {
                //早于最后的数据忽略
                return;
            }
            if ("Trigger".CompareTo(type) == 0)
            {
                SetLastTriggerTime(date);
                return;
            }
            if ("Suspend".CompareTo(type) == 0)
            {
                suspendCount++;
            }

        }

        public static int CaculateSuspendCount()
        {
            LoggerReport loggerReport = new LoggerReport();
            foreach (LoggInfo loggInfo in ReadableLogger.LoggInfos)
            {
                loggerReport.AddItem(loggInfo.Date, loggInfo.Type);
            }
            return loggerReport.suspendCount;
        }

    }
}
