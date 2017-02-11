using System;
using System.Collections.Generic;
using System.Text;
using FluentScheduler;

namespace Dragonfly.Plugin.Task
{
    internal class SchedulerRegistry : Registry
    {
        internal const string JOB_NAME_INTERVAL = "SchedulerRegistry";
        internal const string JOB_NAME_FIX = "SchedulerRegistry";

        public SchedulerRegistry()
        {
            DateTime startTime = JobSetting.GetInstance().caculateFirstTriggerTime();
            int interval = JobSetting.GetInstance().caculateSchedulerInterval();

            Schedule<NotifyJob>().WithName(JOB_NAME_INTERVAL).ToRunOnceAt(startTime).AndEvery(interval).Minutes();

            int remainingMinutes = JobSetting.GetInstance().caculateRemainingMinutes();
            if (remainingMinutes > 0)
            {
                Schedule<NotifyJob>().WithName(JOB_NAME_FIX).ToRunOnceIn(remainingMinutes);
            }
        }

    }
}
