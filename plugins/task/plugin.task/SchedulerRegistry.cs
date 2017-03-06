using Dragonfly.Plugin.Task.Logger;
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
            int suspendCount = LoggerReport.CaculateSuspendCount();
            DateTime startTime = JobSetting.GetInstance().CaculateFirstTriggerTime(suspendCount);
            int interval = JobSetting.GetInstance().CaculateSchedulerInterval();

            Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = false }).WithName(JOB_NAME_INTERVAL).ToRunOnceAt(startTime).AndEvery(interval).Minutes();
#if DEBUG
            int leftMinutes = Convert.ToInt32(Math.Round((startTime - DateTime.Now).TotalMinutes));
            LoggerUtil.Log(Logger.LoggType.Other, "job1 leftMinutes: " + leftMinutes + ", startTime: " + startTime.ToString("yyyy-MM-dd HH:mm:ss") + ", interval: " + interval);
#endif

            int remainingMinutes = JobSetting.GetInstance().CaculateRemainingMinutes();
            if (remainingMinutes > 0)
            {
                Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = true, SpecifyLockScreenMinutes = remainingMinutes }).WithName(JOB_NAME_FIX).ToRunNow();
#if DEBUG
                LoggerUtil.Log(Logger.LoggType.Other, "job2 remainingMinutes: " + remainingMinutes);
#endif
            }

            if (JobSetting.GetInstance().IsTooLateLockScreen)
            {
                int tooLateMinutes = JobSetting.GetInstance().TooLateMinutes;

                DateTime settingTime = JobSetting.GetInstance().TooLateTriggerTime;
                DateTime now = DateTime.Now;
                DateTime tooLateTriggerTime = new DateTime(now.Year,now.Month,now.Day,settingTime.Hour,settingTime.Minute,settingTime.Second);
                if(tooLateTriggerTime < now)
                {
                    Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = true, SpecifyLockScreenMinutes = tooLateMinutes }).WithName(JOB_NAME_TOOLATE).ToRunNow();
                    tooLateTriggerTime = tooLateTriggerTime.AddDays(1);
                }

                Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = true, SpecifyLockScreenMinutes = tooLateMinutes }).WithName(JOB_NAME_TOOLATE).ToRunOnceAt(tooLateTriggerTime).AndEvery(24).Hours();
#if DEBUG
                LoggerUtil.Log(Logger.LoggType.Other, "job3 tooLateTriggerTime: " + tooLateTriggerTime.ToString("yyyy-MM-dd HH:mm:ss") + ", tooLateMinutes: " + tooLateMinutes);
#endif
            }
        }

        internal static void StartAllTask()
        {
            StopAllTask();
            JobManager.Initialize(new SchedulerRegistry());
#if DEBUG
            foreach (Schedule job in JobManager.AllSchedules)
            {
                LoggerUtil.Log(Logger.LoggType.Other, "job:" + job.Name + ", nextRun: " + job.NextRun.ToString("yyyy-MM-dd HH:mm:ss") + ", disabled: " + job.Disabled);
            }
#endif
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
