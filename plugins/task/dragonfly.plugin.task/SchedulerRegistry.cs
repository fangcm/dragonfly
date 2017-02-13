using FluentScheduler;
using System;

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

            Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = false }).WithName(JOB_NAME_INTERVAL).ToRunOnceAt(startTime).AndEvery(interval).Minutes();

            int remainingMinutes = JobSetting.GetInstance().caculateRemainingMinutes();
            if (remainingMinutes > 0)
            {
                Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = true, SpecifyLockScreenMinutes = remainingMinutes }).WithName(JOB_NAME_FIX).ToRunNow();
            }
#if DEBUG
            int leftMinutes = (startTime - DateTime.Now).Minutes;
            LoggerUtil.Log(Logger.LoggType.Other, "job1 leftMinutes: " + leftMinutes + ", startTime: " + startTime.ToString("yyyy-MM-dd HH:mm:ss") + ", interval: " + interval);
            LoggerUtil.Log(Logger.LoggType.Other, "job2 remainingMinutes: " + remainingMinutes);
#endif
        }

    }
}
