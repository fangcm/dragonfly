using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragonfly.Plugin.Task.Logger
{
    internal class LoggerReport
    {
        private int totalResumeTime = 0;
        private int totalSuspendTime = 0;
        private DateTime lastTriggerTime = DateTime.MinValue;
        private DateTime lastCaculateDate = DateTime.MinValue;
        private LoggType lastLoggType = LoggType.Resume;

        public void Init(DateTime lastTriggerTime)
        {
            totalResumeTime = 0;
            totalSuspendTime = 0;
            lastCaculateDate = this.lastTriggerTime = lastTriggerTime;
            lastLoggType = LoggType.Resume;
        }

        public void CaculateFixedTime(DateTime date, LoggType type)
        {
            if (type != LoggType.Suspend && type != LoggType.Resume)
            {
                return;
            }
            if (date <= lastTriggerTime)
            {
                lastCaculateDate = date;
                lastLoggType = type;
                return;
            }
            if (lastCaculateDate <= DateTime.MinValue)
            {
                //从未触发过
                lastCaculateDate = date;
                return;
            }
            if (lastLoggType == type)
            {
                return;
            }

            int totalMinutes = Convert.ToInt32(Math.Round((date - lastCaculateDate).TotalMinutes));
            if (type == LoggType.Suspend)
            {
                totalSuspendTime += totalMinutes;
            }
            else if (type == LoggType.Resume)
            {
                totalResumeTime += totalMinutes;
            }


            lastCaculateDate = date;
        }
    }
}
