using System;
using System.Collections.Generic;
using System.Text;
using Quartz;
using Quartz.Impl;
using System.Windows.Forms;

namespace Dragonfly.Plugin.Task
{
    internal class TaskCenter
    {

        private List<Task> m_tasks;
        private ISchedulerFactory m_schedFactory;
        private TaskPlugin m_plugin;

        public TaskCenter(TaskPlugin plugin)
        {
            m_plugin = plugin;
            m_tasks = new List<Task>();

            System.Collections.Specialized.NameValueCollection properties = new System.Collections.Specialized.NameValueCollection();
            properties["quartz.scheduler.instanceName"] = "DefaultQuartzScheduler";
            properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
            properties["quartz.threadPool.threadCount"] = "3";
            properties["quartz.threadPool.threadPriority"] = "Normal";
            properties["quartz.jobStore.misfireThreshold"] = "60000";
            properties["quartz.jobStore.type"] = "Quartz.Simpl.RAMJobStore, Quartz";
            m_schedFactory = new StdSchedulerFactory(properties);
        }

        ~TaskCenter()
        {
            TerminateAllTask();
        }

        public List<Task> Tasks
        {
            get
            {
                return m_tasks;
            }
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

        public Task EditTask(Task task)
        {
            using (TaskSettingsForm form = new TaskSettingsForm())
            {
                Hashtable param = task.Params;
                form.Title = (string)param["Title"];
                form.Description = (string)param["Description"];
                form.Interval = (EnumInterval)param["Interval"];
                form.IsNotifyInternal = (bool)param["IsNotifyInternal"];
                form.NotifyInternalType = (NotifyInternalType)param["NotifyInternalType"];
                form.LockScreenSeconds = (int)param["LockScreenSeconds"];
                form.IsNotifyRunApp = (bool)param["IsNotifyRunApp"];
                form.NotifyRunApp = (string)param["NotifyRunApp"];
                form.NotifyRunAppParam = (string)param["NotifyRunAppParam"];
                form.NotifyRunAppStartpath = (string)param["NotifyRunAppStartpath"];

                if (form.ShowDialog() == DialogResult.OK)
                {
                    param = new Hashtable();

                    param["Title"] = form.Title;
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

                    Task t = AddTask(param);
                    DelTask(task);

                    return t;
                }
                else
                    return null;
            }
        }

        public Task AddTask(Hashtable taskParams)
        {
            string cron = (string)taskParams["TriggerCron"];
            DateTime beginTime = (DateTime)taskParams["BeginTime"];

            DateTime now = DateTime.Now.AddSeconds(10);

            if (now.CompareTo(beginTime) > 0)
            {
                beginTime = now;
            }

            System.Diagnostics.Debug.WriteLine("AddTask: begintime:" + beginTime + " cron:" + cron);

            NotifyTrigger trigger = new NotifyTrigger(beginTime, cron);
            trigger.Name = Guid.NewGuid().ToString();

            Task task = new Task(this.m_manager);
            task.Name = Guid.NewGuid().ToString();
            task.Trigger = trigger;

            task.Params = taskParams;

            return AddTask(task);
        }

        private Task AddTask(Task newTask)
        {
            if (newTask.QuartzTrigger != null)
            {
                IScheduler scheduler = m_schedFactory.GetScheduler();

                m_tasks.Add(newTask);

                try
                {
                    scheduler.ScheduleJob(newTask.QuartzJob, newTask.QuartzTrigger);
                }
                catch (Exception)
                {
                }
            }

            return newTask;
        }

        public void DelTask(Task delTask)
        {
            IScheduler scheduler = m_schedFactory.GetScheduler();
            if (scheduler.UnscheduleJob(delTask.Trigger.Name, "Notifys"))
                m_tasks.Remove(delTask);
        }

        public void StartAllTask()
        {
            IScheduler scheduler = m_schedFactory.GetScheduler();
            scheduler.Start();
        }

        public void TerminateAllTask()
        {
            try
            {
                IScheduler scheduler = m_schedFactory.GetScheduler();
                scheduler.Shutdown(false);
            }
            catch (SchedulerException)
            {
            }
        }



    }
}
