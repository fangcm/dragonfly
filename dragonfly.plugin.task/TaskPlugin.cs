using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Dragonfly.Common.Plugin;
using Dragonfly.Common.Utils;
using FluentScheduler;

namespace Dragonfly.Plugin.Task
{

    public class TaskPlugin : IPlugin
    {
        private JobSetting jobSetting = null;
        private TaskMainPanel mainPanel = null;

        public TaskPlugin()
        {
       
        }
        ~TaskPlugin()
        {
            StopTask();
        }

        public string Name { get { return "DragonflyTask"; } }
        public string Caption { get { return "提醒"; } }
        public string Version { get { return "1.1.0"; } }

        public void Initialize()
        {
            if (jobSetting == null)
            {
                jobSetting = new JobSetting();
                jobSetting.Load();
            }

            StartTask();
        }

        public void Dispose()
        {
            StopTask();
            if (mainPanel != null && !mainPanel.IsDisposed)
            {
                mainPanel.Dispose();
            }
            jobSetting.Save();
        }

        internal JobSetting JobSetting
        {
            get
            {
                if (jobSetting == null)
                {
                    jobSetting = new JobSetting();
                    jobSetting.Load();
                }

                return this.jobSetting;
            }
        }

        public UserControl PluginPanel
        {
            get
            {
                if (mainPanel == null || mainPanel.IsDisposed)
                {
                    this.mainPanel = new TaskMainPanel();
                    this.mainPanel.TaskPlugin = this;
                }
                return mainPanel;
            }
        }

        internal void StartTask()
        {
            Schedule job = JobManager.GetSchedule(SchedulerRegistry.JOB_NAME);
            if (job != null)
            {
                JobManager.RemoveJob(SchedulerRegistry.JOB_NAME);
            }
            JobManager.Initialize(new SchedulerRegistry());
        }

        internal void StopTask()
        {
            JobManager.RemoveJob(SchedulerRegistry.JOB_NAME);
        }

    }
}
