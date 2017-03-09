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
        internal const string JOB_NAME_ADJUSTMENT = "ADJUSTMENT";

        public SchedulerRegistry()
        {
            SettingHelper helper = SettingHelper.GetInstance();
            NotifyJobSetting setting = helper.PluginSetting.NotifyJobSetting;

            int suspendCount = LoggerReport.CaculateSuspendCount();
            int delayMinutes = helper.CaculateFirstDelayMinutes(suspendCount);
            int interval = helper.CaculateSchedulerInterval();

            Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = false }).WithName(JOB_NAME_INTERVAL).ToRunEvery(interval).Minutes().DelayFor(delayMinutes).Minutes();
#if DEBUG
            LoggerUtil.Log(Logger.LoggType.Other, "job1 leftMinutes: " + (interval + delayMinutes) + ", delayMinutes: " + delayMinutes + ", interval: " + interval);
#endif

            int remainingMinutes = helper.CaculateRemainingMinutes();
            if (remainingMinutes > 0)
            {
                Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = true, SpecifyLockScreenMinutes = remainingMinutes }).WithName(JOB_NAME_FIX).ToRunNow();
#if DEBUG
                LoggerUtil.Log(Logger.LoggType.Other, "job2 remainingMinutes: " + remainingMinutes);
#endif
            }

            if (setting.IsTooLateLockScreen)
            {
                int tooLateMinutes = setting.TooLateMinutes;

                DateTime settingTime;
                try
                {
                    settingTime = DateTime.ParseExact(setting.TooLateTriggerTime, "HH:mm", null);
                }
                catch
                {
                    settingTime = DateTime.ParseExact("21:00", "HH:mm", null);
                }

                if (settingTime < DateTime.Now)
                {
                    Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = true, SpecifyLockScreenMinutes = tooLateMinutes }).WithName(JOB_NAME_TOOLATE).ToRunNow();
                }

                Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = true, SpecifyLockScreenMinutes = tooLateMinutes }).WithName(JOB_NAME_TOOLATE).ToRunEvery(1).Days().At(settingTime.Hour, settingTime.Minute);
#if DEBUG
                LoggerUtil.Log(Logger.LoggType.Other, "job3 tooLateTriggerTime:  at " + setting.TooLateTriggerTime + ", tooLateMinutes: " + tooLateMinutes);
#endif
            }

            Schedule(new AdjustmentJob()).WithName(JOB_NAME_ADJUSTMENT).ToRunEvery(helper.PluginSetting.AdjustmentSetting.IntervalSeconds).Seconds();
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

        internal static void AdjustingDelaySeconds(int relativeSeconds)
        {
#if DEBUG
            LoggerUtil.Log(Logger.LoggType.Other, "调整触发时间");
            foreach (Schedule job in JobManager.AllSchedules)
            {
                LoggerUtil.Log(Logger.LoggType.Other, "job:" + job.Name + ", nextRun: " + job.NextRun.ToString("yyyy-MM-dd HH:mm:ss") + ", disabled: " + job.Disabled);
            }
#endif

            SettingHelper helper = SettingHelper.GetInstance();
            int interval = helper.CaculateSchedulerInterval();

            Schedule schedule = JobManager.GetSchedule(JOB_NAME_INTERVAL);
            if (schedule == null)
            {
                return;
            }

            DateTime nextRunTime = schedule.NextRun.AddSeconds(relativeSeconds);
            int delaySeconds = helper.CaculateDelaySecondsAtTime(nextRunTime);
            JobManager.RemoveJob(JOB_NAME_INTERVAL);


            JobManager.AddJob<NotifyJob>(s => s.WithName(JOB_NAME_INTERVAL).ToRunEvery(interval).Minutes().DelayFor(delaySeconds).Seconds());

#if DEBUG
            LoggerUtil.Log(Logger.LoggType.Other, "调整时间后");
            foreach (Schedule job in JobManager.AllSchedules)
            {
                LoggerUtil.Log(Logger.LoggType.Other, "job:" + job.Name + ", nextRun: " + job.NextRun.ToString("yyyy-MM-dd HH:mm:ss") + ", disabled: " + job.Disabled);
            }
            LoggerUtil.Log(Logger.LoggType.Other, "调整完成");
#endif
        }
    }
}
