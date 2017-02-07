using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;
using Quartz;
using Quartz.Impl;


namespace Dragonfly.Plugin.Task
{

    public class NotifyTrigger
    {
        private string m_name;
        private DateTime m_beginTime; 
        private DateTime m_endTime; 
        private bool m_hasEndTime;
        private string m_cron;

        public NotifyTrigger(DateTime beginTime, string cron) 
        {
            BeginTime = beginTime;
            m_cron = cron;
            m_hasEndTime = false;
        }

        public NotifyTrigger(DateTime beginTime, DateTime endTime, string cron)
        {
            BeginTime = beginTime;
            EndTime = endTime;
            m_cron = cron;
        }

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        public DateTime BeginTime
        { 
            get{ return m_beginTime;} 
            set{m_beginTime = value;} 
        }

        public DateTime EndTime
        { 
            get{ return m_endTime;} 
            set
            {
                m_endTime = value;
                m_hasEndTime = true;
            } 
        }

        public bool HasEndTime {
			get {
				return m_hasEndTime;
			}
		}

        public string Cron
        {
            get
            {
                return m_cron;
            }
            set
            {
                m_cron = value;
            }
        }

        public Trigger QuartzTrigger
        {
            get
            {
                if (string.IsNullOrEmpty(m_cron))
                    return null;

                CronTrigger trigger = new CronTrigger(Name, "Notifys", m_cron);

                trigger.StartTimeUtc = this.BeginTime.ToUniversalTime();
                if(HasEndTime)
                    trigger.EndTimeUtc = this.EndTime.ToUniversalTime();
                return trigger;
            }

        }

    }


    public class NotifyJob : IJob
    {
        public const string JOB_DATA = "job_data";

        public virtual void Execute(JobExecutionContext context)
        {
            string jobName = context.JobDetail.FullName;
            Hashtable param = (Hashtable)context.JobDetail.JobDataMap.Get(JOB_DATA);

            if (param == null || param.Count == 0)
                return;


            System.Diagnostics.Debug.WriteLine("job:" + DateTime.Now + jobName);

            string title = (string)param["Title"];
            string description = (string)param["Description"];

            bool isNotifyShowMessage = (bool)param["IsNotifyShowMessage"];
            if (isNotifyShowMessage)
            {
                string notifyRunApp = Application.StartupPath + @"\dragonfly.plugin.task.notify.exe";
                string notifyRunAppParam = string.Format("msg \"{0}\" \"{1}\"",title,description);
                string notifyRunAppStartpath = Application.StartupPath;
                ExecApp(notifyRunApp, notifyRunAppParam, notifyRunAppStartpath);
            }

            bool isNotifyShowAnimation = (bool)param["IsNotifyShowAnimation"];
            if (isNotifyShowAnimation)
            {
                int showSeconds = 60; // (int)param["ShowSeconds"];
                string notifyRunApp = Application.StartupPath + @"\dragonfly.plugin.task.notify.exe";
                string notifyRunAppParam = string.Format("other \"{0}\"", showSeconds);
                string notifyRunAppStartpath = Application.StartupPath;
                ExecApp(notifyRunApp, notifyRunAppParam, notifyRunAppStartpath);
            }

            bool isNotifyInternal = (bool)param["IsNotifyInternal"];
            if (isNotifyInternal)
            {
                NotifyInternalType notifyInternalType = (NotifyInternalType)param["NotifyInternalType"];
                int lockScreenSeconds = (int)param["LockScreenSeconds"];

                string notifyRunApp = Application.StartupPath + @"\dragonfly.plugin.task.notify.exe";
                string notifyRunAppParam;
                string notifyRunAppStartpath = Application.StartupPath;

                if (notifyInternalType == NotifyInternalType.LockScreen)
                {
                    notifyRunAppParam = string.Format("lock {0} \"{1}\" \"{2}\"", lockScreenSeconds, title, description);
                }
                else if (notifyInternalType == NotifyInternalType.Hibernate)
                {
                    notifyRunAppParam = "shutdown hibernate";
                }
                else if (notifyInternalType == NotifyInternalType.ShutDown)
                {
                    notifyRunAppParam = "shutdown poweroff";
                }
                else
                {
                    notifyRunAppParam = string.Format("lock 30 提醒 锁定屏幕，请稍休息一下");
                }

                ExecApp(notifyRunApp, notifyRunAppParam, notifyRunAppStartpath);

                System.Diagnostics.Debug.WriteLine("ExecApp:" + notifyRunApp);
            }

            bool isNotifyRunApp = (bool)param["IsNotifyRunApp"];
            if (isNotifyRunApp)
            {

                string notifyRunApp = (string)param["NotifyRunApp"];
                string notifyRunAppParam = (string)param["NotifyRunAppParam"];
                string notifyRunAppStartpath = (string)param["NotifyRunAppStartpath"];

                ExecApp(notifyRunApp, notifyRunAppParam, notifyRunAppStartpath);

                System.Diagnostics.Debug.WriteLine("ExecApp:" + notifyRunApp);
            }

        }



        private bool ExecApp(string app, string appParam, string appStartpath)
        {

            try
            {
                Process myprocess = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo(app, appParam);
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                startInfo.WorkingDirectory = appStartpath;
                myprocess.StartInfo = startInfo;
                myprocess.StartInfo.UseShellExecute = false;
                myprocess.Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }     

    public class Task
    { 
        private string m_name;
        private NotifyTrigger m_trigger;
        private Hashtable m_paramHashTable = new Hashtable();
        public TaskManager m_manager;

        public Task(TaskManager manager)
        {
            m_manager = manager;

        }

        public string Name 
        { 
            get 
            { 
                return m_name; 
            } 
            set 
            { 
                m_name = value; 
            } 
        }

        public NotifyTrigger Trigger
        {
            get
            {
                return m_trigger;
            }
            set
            {
                m_trigger = value;
            }
        }

        public Hashtable Params
        {
			get
            {
                return m_paramHashTable;
			}
            set
            {
                m_paramHashTable = value;
            }
		}

        public void AddParam(string key, object data)
        {
            if (m_paramHashTable == null)
                m_paramHashTable = new Hashtable();
            m_paramHashTable.Add(key,data);
        }

        public JobDetail QuartzJob
        {
            get
            {

                JobDetail job = new JobDetail(m_name, "Notifys", typeof(NotifyJob));
                if (job.JobDataMap.Get(NotifyJob.JOB_DATA) != null)
                    job.JobDataMap.Remove(NotifyJob.JOB_DATA);

                job.JobDataMap.Put(NotifyJob.JOB_DATA, m_paramHashTable);

                return job;

            }

        }
        public Trigger QuartzTrigger
        {
            get
            {
                return m_trigger.QuartzTrigger;
            }

        }

        #region IThreadedExecuterView Members

        public void SetWait(bool isEnabled)
        {
        }

        public void HandleException(Exception ex)
        {
        }

        #endregion

    }

    public class TaskCenter
    {
        private ArrayList m_tasks;
        private ISchedulerFactory m_schedFactory;
        private TaskManager m_manager;

        public TaskCenter(TaskManager manager)
        {
            m_manager = manager;
            m_tasks = new ArrayList();

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

        public ArrayList Tasks
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
                    Hashtable param = new Hashtable();
                    param["Title"] = form.Title;
                    param["Description"] = form.Description;

                    param["TriggerType"] = form.TriggerType;
                    param["BeginTime"] = form.BeginTime;
                    param["IsInterval"] = form.IsInterval;
                    param["Interval"] = form.Interval;
                    param["DaysOfTheWeek"] = form.DaysOfTheWeek;

                    param["IsNotifyShowMessage"] = form.IsNotifyShowMessage;
                    param["IsNotifyShowAnimation"] = form.IsNotifyShowAnimation;
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

                form.TriggerType = (int)param["TriggerType"];
                form.BeginTime = (DateTime)param["BeginTime"];
                form.IsInterval = (bool)param["IsInterval"];
                form.Interval = (EnumInterval)param["Interval"];
                form.DaysOfTheWeek = (DaysOfTheWeek)param["DaysOfTheWeek"];

                form.IsNotifyShowMessage = (bool)param["IsNotifyShowMessage"];
                form.IsNotifyShowAnimation = (bool)param["IsNotifyShowAnimation"];
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

                    param["TriggerType"] = form.TriggerType;
                    param["BeginTime"] = form.BeginTime;
                    param["IsInterval"] = form.IsInterval;
                    param["Interval"] = form.Interval;
                    param["DaysOfTheWeek"] = form.DaysOfTheWeek;

                    param["IsNotifyShowMessage"] = form.IsNotifyShowMessage;
                    param["IsNotifyShowAnimation"] = form.IsNotifyShowAnimation;
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

            System.Diagnostics.Debug.WriteLine("AddTask: begintime:" + beginTime +" cron:" + cron);

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
                catch(Exception)
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
