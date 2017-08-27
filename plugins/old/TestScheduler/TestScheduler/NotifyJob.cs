using Dragonfly.Common.Utils;
using FluentScheduler;
using System;
using System.Diagnostics;
using System.IO;


namespace Dragonfly.Plugin.Task
{
    internal class NotifyJob : IJob
    {
        public bool IsSpecifyLockScreenMinutes { get; set; }
        public int SpecifyLockScreenMinutes { get; set; }

        internal NotifyJob()
        {
            IsSpecifyLockScreenMinutes = false;
        }

        void IJob.Execute()
        {
            try
            {
                Logger.info("NotifyJob", "Execute start ...");

                SettingHelper helper = SettingHelper.GetInstance();
                NotifyJobSetting setting = helper.PluginSetting.NotifyJobSetting;

                int lockScreenMinutes;
                if (IsSpecifyLockScreenMinutes)
                {
                    lockScreenMinutes = SpecifyLockScreenMinutes;
                }
                else
                {
                    if (setting.LockScreenType == SettingHelper.LockScreenType_Ten)
                    {
                        lockScreenMinutes = 10;
                    }
                    else
                    {
                        lockScreenMinutes = 60;
                    }
                }
                Logger.info("NotifyJob", "IsSpecifyLockScreenMinutes:", IsSpecifyLockScreenMinutes, "lockScreenMinutes:", lockScreenMinutes);

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
                string notifyRunAppParam = string.Format("-lockminutes {0}", lockScreenMinutes);
                Logger.info("Exec App: ",notifyRunApp, notifyRunAppParam, notifyRunAppStartpath);
                Logger.info("NotifyJob", "lockScreen:", lockScreenApp, ", minutes:", lockScreenMinutes);

            }
            catch (Exception e)
            {
                Logger.info("NotifyJob", "IJob.Execute error:", e.Message, e.StackTrace);
            }

        }

     

    }

}