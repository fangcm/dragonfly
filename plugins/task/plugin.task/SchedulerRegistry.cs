using Dragonfly.Common.Utils;
using Dragonfly.Plugin.Task.Utils;
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

            Logger.debug("SchedulerRegistry", "job", JOB_NAME_INTERVAL, " leftMinutes: ", (interval + delayMinutes), ", delayMinutes: ", delayMinutes, ", interval: ", interval);

            int remainingMinutes = helper.CaculateRemainingMinutes();
            if (remainingMinutes > 0)
            {
                Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = true, SpecifyLockScreenMinutes = remainingMinutes }).WithName(JOB_NAME_FIX).ToRunNow();

                Logger.debug("SchedulerRegistry", "job", JOB_NAME_FIX, " remainingMinutes: ", remainingMinutes);
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

                DateTime now = DateTime.Now;
                if (settingTime < now  && settingTime.DayOfYear == now.DayOfYear)
                {
                    Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = true, SpecifyLockScreenMinutes = tooLateMinutes }).WithName(JOB_NAME_TOOLATE).ToRunNow();
                }

                Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = true, SpecifyLockScreenMinutes = tooLateMinutes }).WithName(JOB_NAME_TOOLATE).ToRunEvery(1).Days().At(settingTime.Hour, settingTime.Minute);

                Logger.debug("SchedulerRegistry", "job", JOB_NAME_TOOLATE, " tooLateTriggerTime:  at ", setting.TooLateTriggerTime, ", tooLateMinutes: ", tooLateMinutes);

            }

            Schedule(new AdjustmentJob()).WithName(JOB_NAME_ADJUSTMENT).ToRunEvery(helper.PluginSetting.AdjustmentSetting.IntervalSeconds).Seconds();
        }

        internal static void StartAllTask()
        {
            StopAllTask();
            JobManager.Initialize(new SchedulerRegistry());
            JobManager.JobException += (JobExceptionInfo obj) =>
                Logger.error("SchedulerRegistry", "Schedule JobException, job name:", obj.Name, ",Error:", obj.Exception.Message,obj.Exception.StackTrace,
                            ",InnerException:", obj.Exception.InnerException?.StackTrace ?? string.Empty);

            if (Logger.isDebugEnabled())
            {
                foreach (Schedule job in JobManager.AllSchedules)
                {
                    Logger.debug("SchedulerRegistry", "job:", job.Name, ", nextRun: ", job.NextRun.ToString("yyyy-MM-dd HH:mm:ss"));
                }
            }
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
            Schedule schedule = JobManager.GetSchedule(JOB_NAME_INTERVAL);
            if (schedule == null)
            {
                return;
            }
            DateTime nextRunTime = schedule.NextRun.AddSeconds(relativeSeconds);
            if (nextRunTime.CompareTo(DateTime.Now.AddSeconds(30)) <= 0)
            {
                Logger.info("SchedulerRegistry", "Time is short. No need to adjust");
                return;
            }

            if (Logger.isDebugEnabled())
            {
                Logger.debug("SchedulerRegistry", "Before adjustment");
                foreach (Schedule job in JobManager.AllSchedules)
                {
                    Logger.debug("SchedulerRegistry", "job:", job.Name, ", nextRun: ", job.NextRun.ToString("yyyy-MM-dd HH:mm:ss"));
                }
            }

            SettingHelper helper = SettingHelper.GetInstance();
            int delaySeconds = helper.CaculateDelaySecondsAtTime(nextRunTime);

            JobManager.RemoveJob(JOB_NAME_INTERVAL);

            int interval = helper.CaculateSchedulerInterval();
            JobManager.AddJob(new NotifyJob { IsSpecifyLockScreenMinutes = false },(s) => s.WithName(JOB_NAME_INTERVAL).ToRunEvery(interval).Minutes().DelayFor(delaySeconds).Seconds());

            if (Logger.isDebugEnabled())
            {
                Logger.debug("SchedulerRegistry", "After adjustment");
                foreach (Schedule job in JobManager.AllSchedules)
                {
                    Logger.debug("SchedulerRegistry", "job:", job.Name, ", nextRun: ", job.NextRun.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                Logger.debug("SchedulerRegistry", "Finish adjustment .");
            }
        }
    }
}
