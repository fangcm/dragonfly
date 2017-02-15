using FluentScheduler;
using System;

namespace Dragonfly.Plugin.Task
{
    internal class SchedulerRegistry : Registry
    {
        internal const string JOB_NAME_INTERVAL = "INTERVAL";
        internal const string JOB_NAME_FIX = "FIX";
        internal const string JOB_NAME_TOOLATE = "TOOLATE";

        public SchedulerRegistry()
        {
            DateTime startTime = JobSetting.GetInstance().caculateFirstTriggerTime();
            int interval = JobSetting.GetInstance().caculateSchedulerInterval();

            Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = false }).WithName(JOB_NAME_INTERVAL).ToRunOnceAt(startTime).AndEvery(interval).Minutes();
#if DEBUG
            int leftMinutes = (startTime - DateTime.Now).Minutes;
            LoggerUtil.Log(Logger.LoggType.Other, "job1 leftMinutes: " + leftMinutes + ", startTime: " + startTime.ToString("yyyy-MM-dd HH:mm:ss") + ", interval: " + interval);
#endif

            int remainingMinutes = JobSetting.GetInstance().caculateRemainingMinutes();
            if (remainingMinutes > 0)
            {
                Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = true, SpecifyLockScreenMinutes = remainingMinutes }).WithName(JOB_NAME_FIX).ToRunNow();
#if DEBUG
                LoggerUtil.Log(Logger.LoggType.Other, "job2 remainingMinutes: " + remainingMinutes);
#endif
            }

            if (JobSetting.GetInstance().IsTooLateLockScreen)
            {
                DateTime tooLateTriggerTime = JobSetting.GetInstance().TooLateTriggerTime;
                int tooLateMinutes = JobSetting.GetInstance().TooLateMinutes;
                Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = true, SpecifyLockScreenMinutes = tooLateMinutes }).WithName(JOB_NAME_TOOLATE).ToRunOnceAt(tooLateTriggerTime).AndEvery(1).Days();
#if DEBUG
                LoggerUtil.Log(Logger.LoggType.Other, "job3 tooLateTriggerTime: " + tooLateTriggerTime.ToString("yyyy-MM-dd HH:mm:ss") + ", tooLateMinutes: " + tooLateMinutes);
#endif
            }
        }

        internal static void StartAllTask()
        {
            StopAllTask();
            JobManager.Initialize(new SchedulerRegistry());
        }

        internal static void StopAllTask()
        {
            JobManager.Stop();
            foreach (Schedule job in JobManager.AllSchedules)
            {
                JobManager.RemoveJob(job.Name);
            }

        }

    }
}
