using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Dragonfly.Common.Plugin;
using Dragonfly.Common.Utils;
using FluentScheduler;
using Microsoft.Win32;

namespace Dragonfly.Plugin.Task
{

    public class TaskPlugin : IPlugin
    {
        private TaskMainPanel mainPanel = null;

        private PowerModeChangedEventHandler pmceh;
        private SessionEndedEventHandler seeh;
        private EventHandler timeChanged;

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

            pmceh = new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
            seeh = new SessionEndedEventHandler(SystemEvents_SessionEnded);
            timeChanged = new EventHandler(SystemEvents_TimeChanged);

            SystemEvents.SessionEnded += seeh;
            SystemEvents.PowerModeChanged += pmceh;
            SystemEvents.TimeChanged += timeChanged;

            StartTask();
        }
        
        private void detachEventsHandlers()
        {
            if (pmceh != null) SystemEvents.PowerModeChanged -= this.pmceh;
            if (seeh != null) SystemEvents.SessionEnded -= this.seeh;
            if (timeChanged != null) SystemEvents.TimeChanged -= this.timeChanged;
        }

        public void Dispose()
        {
            detachEventsHandlers();
            StopTask();
            JobSetting.GetInstance().Save();
        }

        public UserControl PluginPanel
        {
            get
            {
                if (mainPanel == null || mainPanel.IsDisposed)
                {
                    this.mainPanel = new TaskMainPanel();
                }
                return mainPanel;
            }
        }


        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Suspend)
            {
                JobSetting.GetInstance().LastTurnOffMachineTime = DateTime.Now;
                JobSetting.GetInstance().Save();
                LoggerUtil.Log(Logger.LoggType.Suspend, "休眠");
            }
            else if (e.Mode == PowerModes.Resume)
            {
                JobSetting.GetInstance().TurnOnMachineTime = DateTime.Now;
                JobSetting.GetInstance().Save();
                LoggerUtil.Log(Logger.LoggType.Resume, "唤醒");
            }
        }

        private void SystemEvents_SessionEnded(object sender, SessionEndedEventArgs e)
        {
            JobSetting.GetInstance().LastTurnOffMachineTime = DateTime.Now;
            JobSetting.GetInstance().Save();
            if (e.Reason == SessionEndReasons.Logoff)
            {
                LoggerUtil.Log(Logger.LoggType.Logoff, "注销登录");
            }
            else if (e.Reason == SessionEndReasons.SystemShutdown)
            {
                LoggerUtil.Log(Logger.LoggType.SystemShutdown, "关机");
            }
        }

        private void SystemEvents_TimeChanged(object sender, EventArgs e)
        {
            LoggerUtil.Log(Logger.LoggType.Other, "修改系统时间");
        }

        internal void StartTask()
        {
            LoggerUtil.Log(Logger.LoggType.Other, "开始线程");
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
