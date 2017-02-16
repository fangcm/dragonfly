using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragonfly.Plugin.Task.Logger
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

        public void AddItem(DateTime date, LoggType type)
        {
            if (type != LoggType.Suspend && type != LoggType.Resume && type != LoggType.Trigger)
            {
                return;
            }
            if (date <= lastTriggerTime)
            {
                //早于最后的数据忽略
                return;
            }
            if (type == LoggType.Trigger)
            {
                SetLastTriggerTime(date);
                return;
            }

            if (type == LoggType.Suspend)
            {
                suspendCount++;
            }

        }

        public static int CaculateSuspendCount()
        {
            LoggerReport loggerReport = new LoggerReport();
            foreach (LoggInfo loggInfo in Logger.LoggInfos)
            {
                loggerReport.AddItem(loggInfo.Date, loggInfo.Type);
            }
            return loggerReport.suspendCount;
        }
        
    }
}
