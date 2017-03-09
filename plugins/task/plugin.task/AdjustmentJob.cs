using Dragonfly.Common.Utils;
using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;


namespace Dragonfly.Plugin.Task
{
    internal class AdjustmentJob : IJob
    {
        void IJob.Execute()
        {
            LoggerUtil.Log(Logger.LoggType.Other, "AdjustmentJob running");
            int adjustmentSeconds = SelfAdjusting.CaculateAdjustmentSeconds();
            if (adjustmentSeconds <= 0)
            {
                return;
            }
            foreach (Schedule job in JobManager.AllSchedules)
            {
                if (SchedulerRegistry.JOB_NAME_INTERVAL.Equals(job.Name))
                {
                    Trace.WriteLine(job.Name + " ," + job.NextRun);
                }
            }

            SettingHelper helper = SettingHelper.GetInstance();
            NotifyJobSetting setting = helper.PluginSetting.NotifyJobSetting;

            //DateTime startTime = helper.CaculateFirstTriggerTime(suspendCount);
            //int interval = helper.CaculateSchedulerInterval();

            //Schedule(new NotifyJob { IsSpecifyLockScreenMinutes = false }).WithName(SchedulerRegistry.JOB_NAME_INTERVAL).ToRunOnceAt(startTime).AndEvery(interval).Minutes();
            //var expected = DateTime.Now.AddSeconds(12);
             
        }



    }

}