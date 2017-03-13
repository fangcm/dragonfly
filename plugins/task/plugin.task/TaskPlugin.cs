using Dragonfly.Common.Plugin;
using Dragonfly.Common.Utils;
using Dragonfly.Plugin.Task.Utils;
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
            if (mainPanel == null)
            {
                //为了初始化
                UserControl m = PluginPanel;
            }
            LoggerUtil.Init(mainPanel);
            LoggerUtil.Log(LoggType.Resume, "启动初始化");
            Logger.info("TaskPlugin Initialize");
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
                LoggerUtil.Log(LoggType.Suspend, "休眠");
                Logger.info("休眠");
            }
            else if (e.Mode == PowerModes.Resume)
            {
                LoggerUtil.Log(LoggType.Resume, "唤醒");
                Logger.info("唤醒");
                StartTask();
            }
        }

        private void SystemEvents_SessionEnded(object sender, SessionEndedEventArgs e)
        {
            if (e.Reason == SessionEndReasons.Logoff)
            {
                LoggerUtil.Log(LoggType.Suspend, "注销登录");
                Logger.info("注销登录");
            }
            else if (e.Reason == SessionEndReasons.SystemShutdown)
            {
                LoggerUtil.Log(LoggType.Suspend, "关机");
                Logger.info("关机");
            }
        }

        internal void StartTask()
        {
            SchedulerRegistry.StartAllTask();
        }

        internal void StopTask()
        {
            SchedulerRegistry.StopAllTask();
        }

        public DateTime TaskNextRun()
        {
            DateTime nextRun = DateTime.MaxValue;
            foreach (Schedule schedule in JobManager.AllSchedules)
            {
                if (schedule.Disabled)
                    continue;
                if (nextRun > schedule.NextRun)
                {
                    nextRun = schedule.NextRun;
                }
            }
            return nextRun;
        }

    }
}
