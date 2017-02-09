using FluentScheduler;
using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;



namespace Dragonfly.Plugin.Task
{

    internal class NotifyJob : IJob
    {
        void IJob.Execute()
        {

            System.Diagnostics.Debug.WriteLine("worker execute:" + DateTime.Now);

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

   
 

  
} 
