using Dragonfly.Common.Utils;
using Dragonfly.Plugin.Task.Utils;
using FluentScheduler;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;


namespace Dragonfly.Plugin.Task
{
    internal class RecoveryJob : IJob
    {
        void IJob.Execute()
        {
            try
            {
                bool notifyRunning = IsNotifyProgramRunning();
                if (notifyRunning)
                {
                    return;
                }

                bool needRecovery = false;
                NotifySetting notifySetting = NotifySetting.LoadFromFile();

                if (notifySetting != null && notifySetting.EndTriggerTime != null && !DateTime.MinValue.Equals(notifySetting.EndTriggerTime))
                {
                    if (DateTime.Now.CompareTo(notifySetting.EndTriggerTime) < 0)
                    {
                        needRecovery = true;
                    }
                }

                if (needRecovery)
                {

                    Logger.info("RecoveryJob", "Need RecoveryJob start ...");

                    SettingHelper helper = SettingHelper.GetInstance();
                    NotifyJobSetting setting = helper.PluginSetting.NotifyJobSetting;
                    if (setting.IsLockScreen || setting.NotifyInternalType != SettingHelper.NotifyInternalType_None)
                    {
                        string lockScreenApp;
                        if (setting.LockScreenApp == 1)
                        {
                            lockScreenApp = "questions.notify.exe";
                        }
                        else
                        {
                            lockScreenApp = "simple.notify.exe";
                        }
                        string notifyRunAppStartpath = AppConfig.PluginsPath;
                        string notifyRunApp = Path.Combine(notifyRunAppStartpath, lockScreenApp);
                        string notifyRunAppParam = string.Format("-lock true -recovery true -cmd {0} -desc \"{1}\"", setting.NotifyInternalType, setting.Description);
                        NotifyJob.ExecApp(notifyRunApp, notifyRunAppParam, notifyRunAppStartpath);
                        Logger.info("RecoveryJob", "lockScreen:", lockScreenApp);
                    }
                }
                else
                {
                    JobManager.RemoveJob("RECOVERY");
                }

            }
            catch (Exception e)
            {
                Logger.info("NotifyJob", "IJob.Execute error:", e.Message, e.StackTrace);
            }

        }

        private bool IsNotifyProgramRunning()
        {
            bool found = false;
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                try
                {
                    if (process.MainModule.FileName.ToLower().EndsWith(".notify.exe"))
                    {
                        found = true;
                        break;
                    }
                }
                catch
                {
                    continue;
                }
            }
            return found;
        }

    }

}