using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FluentScheduler;

namespace Dragonfly.Plugin.Task
{
    internal class SchedulerRegistry : Registry
    {
        internal static readonly string JOB_NAME = "SchedulerRegistry";
        public SchedulerRegistry()
        {
            Schedule<NotifyJob>().WithName(JOB_NAME).NonReentrant().ToRunOnceAt(8,10).AndEvery(2).Seconds();
        }

    }

    internal class TaskCenter
    {
        private TaskPlugin m_plugin;

        public TaskCenter(TaskPlugin plugin)
        {
            m_plugin = plugin;
            
        }

        ~TaskCenter()
        {
            Stop();
        }

        public Task AddTask()
        {
            using (TaskSettingsForm form = new TaskSettingsForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    KeyValuePair<String,object> param = new KeyValuePair<String, object>();
                    param.["Title"] = form.Title;
                    param["Description"] = form.Description;
                    param["Interval"] = form.Interval;
                    param["IsNotifyInternal"] = form.IsNotifyInternal;
                    param["NotifyInternalType"] = form.NotifyInternalType;
                    param["LockScreenSeconds"] = form.LockScreenSeconds;
                    param["IsNotifyRunApp"] = form.IsNotifyRunApp;
                    param["NotifyRunApp"] = form.NotifyRunApp;
                    param["NotifyRunAppParam"] = form.NotifyRunAppParam;
                    param["NotifyRunAppStartpath"] = form.NotifyRunAppStartpath;
                    param["TriggerCron"] = form.TriggerCron;

                    return AddTask(param);
                }
                else
                    return null;
            }
        }


        public void Start()
        {
            Schedule job = JobManager.GetSchedule(SchedulerRegistry.JOB_NAME);
            if (job != null)
            {
                JobManager.RemoveJob(SchedulerRegistry.JOB_NAME);
            }
            JobManager.Initialize(new SchedulerRegistry());
        }

        public void Stop()
        {
            JobManager.RemoveJob(SchedulerRegistry.JOB_NAME);
        }



    }
}
