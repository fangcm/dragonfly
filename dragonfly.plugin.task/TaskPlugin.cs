using Dragonfly.Common.Plugin;
using FluentScheduler;
using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace Dragonfly.Plugin.Task
{

    public class TaskPlugin : IPlugin
    {
        private TaskMainPanel mainPanel = null;

        private PowerModeChangedEventHandler pmceh;
        private SessionEndedEventHandler seeh;

        public TaskPlugin()
        {

        }
        ~TaskPlugin()
        {
            StopTask();
        }

        public string Name { get { return "DragonflyTask"; } }
        public string Caption { get { return "定时提醒"; } }
        public string Version { get { return "1.1.0"; } }

        public void Initialize()
        {
            if(mainPanel == null)
            {
                //为了初始化
                UserControl m = PluginPanel;
            }
            LoggerUtil.Init(mainPanel);
            LoggerUtil.Log(Logger.LoggType.Resume, "启动初始化");
            pmceh = new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
            seeh = new SessionEndedEventHandler(SystemEvents_SessionEnded);

            SystemEvents.SessionEnded += seeh;
            SystemEvents.PowerModeChanged += pmceh;

            StartTask();
        }
        
        private void detachEventsHandlers()
        {
            if (pmceh != null) SystemEvents.PowerModeChanged -= this.pmceh;
            if (seeh != null) SystemEvents.SessionEnded -= this.seeh;
        }

        public void Dispose()
        {
            detachEventsHandlers();
            StopTask();
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


        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Suspend)
            {
                LoggerUtil.Log(Logger.LoggType.Suspend, "休眠");
            }
            else if (e.Mode == PowerModes.Resume)
            {
                LoggerUtil.Log(Logger.LoggType.Resume, "唤醒");
                StartTask();
            }
        }

        private void SystemEvents_SessionEnded(object sender, SessionEndedEventArgs e)
        {
            if (e.Reason == SessionEndReasons.Logoff)
            {
                LoggerUtil.Log(Logger.LoggType.Suspend, "注销登录");
            }
            else if (e.Reason == SessionEndReasons.SystemShutdown)
            {
                LoggerUtil.Log(Logger.LoggType.Suspend, "关机");
            }
        }

        internal void StartTask()
        {
            StopTask();
            JobManager.Initialize(new SchedulerRegistry());
        }

        internal void StopTask()
        {
            Schedule jobInterval = JobManager.GetSchedule(SchedulerRegistry.JOB_NAME_INTERVAL);
            if (jobInterval != null)
            {
                JobManager.RemoveJob(SchedulerRegistry.JOB_NAME_INTERVAL);
            }
            Schedule jobFix = JobManager.GetSchedule(SchedulerRegistry.JOB_NAME_FIX);
            if (jobFix != null)
            {
                JobManager.RemoveJob(SchedulerRegistry.JOB_NAME_FIX);
            }
        }

    }
}
