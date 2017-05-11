using Dragonfly.Common.Utils;
using FluentScheduler;
using System;
using System.Collections.Generic;

namespace Dragonfly.Plugin.Task
{
    internal class SchedulerRegistry : Registry
    {
        internal const string JOB_NAME_INTERVAL = "INTERVAL";
        internal const string JOB_NAME_FIX = "FIX";
        internal const string JOB_NAME_TOOLATE = "TOOLATE";

        public SchedulerRegistry()
        {
            SettingHelper helper = SettingHelper.GetInstance();
            NotifyJobSetting setting = helper.PluginSetting.NotifyJobSetting;

            Dictionary<string, int> lastMinutes = helper.CaculateRemainingMinutes();
            int delayMinutes = lastMinutes["delayMinutes"];
            int remainingMinutes = lastMinutes["remainingMinutes"];
            int interval = lastMinutes["interval"];

            Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = false }).WithName(JOB_NAME_INTERVAL).ToRunEvery(interval).Minutes().DelayFor(delayMinutes).Minutes();
            Logger.debug("SchedulerRegistry", "job", JOB_NAME_INTERVAL, " leftMinutes: ", (interval + delayMinutes), ", delayMinutes: ", delayMinutes, ", interval: ", interval);

            if (remainingMinutes > 0)
            {
                Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = true, SpecifyLockScreenMinutes = remainingMinutes }).WithName(JOB_NAME_FIX).ToRunNow();
                Logger.debug("SchedulerRegistry", "job", JOB_NAME_FIX, " remainingMinutes: ", remainingMinutes);
            }

            if (setting.IsTooLateLockScreen)
            {
                int tooLateMinutes = setting.TooLateMinutes;

                DateTime now = DateTime.Now;
                int nowHour = now.Hour;
                int nowMinute = now.Minute;
                int tooLateSettingHour = 21;
                int tooLateSettingMinute = 0;
                try
                {
                    DateTime settingTime = DateTime.ParseExact(setting.TooLateTriggerTime, "HH:mm", null);
                    tooLateSettingHour = settingTime.Hour;
                    tooLateSettingMinute = settingTime.Minute;
                }
                catch
                {
                }

                if (tooLateSettingHour * 100 + tooLateSettingMinute < nowHour * 100 + nowMinute)
                {
                    Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = true, SpecifyLockScreenMinutes = tooLateMinutes }).WithName(JOB_NAME_TOOLATE).ToRunNow();
                }
                Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = true, SpecifyLockScreenMinutes = tooLateMinutes }).WithName(JOB_NAME_TOOLATE).ToRunEvery(1).Days().At(tooLateSettingHour, tooLateSettingMinute);
                Logger.debug("SchedulerRegistry", "job", JOB_NAME_TOOLATE, " tooLateTriggerTime:  at ", setting.TooLateTriggerTime, ", tooLateMinutes: ", tooLateMinutes);

            }

        }

        internal static void StartAllTask()
        {
            StopAllTask();
            JobManager.Initialize(new SchedulerRegistry());
            JobManager.JobException += (JobExceptionInfo obj) =>
                Logger.error("SchedulerRegistry", "Schedule JobException, job name:", obj.Name, ",Error:", obj.Exception.Message, obj.Exception.StackTrace,
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

    }
}
