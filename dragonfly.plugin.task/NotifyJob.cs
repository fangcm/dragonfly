using FluentScheduler;
using System;
using System.Diagnostics;
using System.Windows.Forms;


namespace Dragonfly.Plugin.Task
{
    internal class NotifyJob : IJob
    {
        void IJob.Execute()
        {

            System.Diagnostics.Debug.WriteLine("worker execute:" + DateTime.Now);

            JobSetting setting = JobSetting.GetInstance();

            if (setting.IsLockScreen || setting.NotifyInternalType != JobSetting.NotifyInternalType_None)
            {
                string notifyRunApp = Application.StartupPath + @"\dragonfly.plugin.task.notify.exe";
                string notifyRunAppStartpath = Application.StartupPath;
                string notifyRunAppParam = string.Format("-lock {0} -lockminutes {1} -o {2} -desc \"{3}\"", setting.IsLockScreen, setting.LockScreenMinutes, setting.NotifyInternalType, setting.Description);

                ExecApp(notifyRunApp, notifyRunAppParam, notifyRunAppStartpath);
                System.Diagnostics.Debug.WriteLine("ExecApp:" + notifyRunApp);
            }

            if (setting.IsNotifyRunApp)
            {
                ExecApp(setting.NotifyRunApp, setting.NotifyRunAppParam, setting.NotifyRunAppStartpath);
                System.Diagnostics.Debug.WriteLine("ExecApp:" + setting.NotifyRunApp);
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