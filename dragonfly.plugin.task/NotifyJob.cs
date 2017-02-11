using FluentScheduler;
using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;


namespace Dragonfly.Plugin.Task
{
    internal class NotifyJob : IJob
    {
        void IJob.Execute()
        {

            LoggerUtil.Log(Logger.LoggType.Trigger, "worker execute");

            JobSetting setting = JobSetting.GetInstance();
            setting.LastTriggerTime = DateTime.Now;
            setting.Save();


            StringBuilder sb = new StringBuilder();
            sb.Append("触发指令:");
            if (setting.IsLockScreen)
            {
                sb.Append("锁屏【").Append(setting.LockScreenMinutes).Append("】分钟");
            }
            switch (setting.NotifyInternalType)
            {
                case JobSetting.NotifyInternalType_Hibernate:
                    sb.Append("，自动休眠");
                    break;
                case JobSetting.NotifyInternalType_ShutDown:
                    sb.Append("，自动关机");
                    break;
            }
            if (setting.IsNotifyRunApp)
            {
                sb.Append("，执行外部程序【").Append(setting.NotifyRunApp).Append("】");
            }
                LoggerUtil.Log(Logger.LoggType.Trigger, sb.ToString());

            if (setting.IsLockScreen || setting.NotifyInternalType != JobSetting.NotifyInternalType_None)
            {
                string notifyRunApp = Application.StartupPath + @"\dragonfly.plugin.task.notify.exe";
                string notifyRunAppStartpath = Application.StartupPath;
                string notifyRunAppParam = string.Format("-lock {0} -lockminutes {1} -o {2} -desc \"{3}\"", setting.IsLockScreen, setting.LockScreenMinutes, setting.NotifyInternalType, setting.Description);

                ExecApp(notifyRunApp, notifyRunAppParam, notifyRunAppStartpath);
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