using Dragonfly.Common.Utils;
using Dragonfly.Plugin.Task.Utils;
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

                //判断起始时间
                DateTime now = DateTime.Now;
                int nowHour = now.Hour;
                int nowMinute = now.Minute;
                int startTimeSettingHour = 10;
                int startTimeSettingMinute = 0;
                try
                {
                    DateTime settingTime = DateTime.ParseExact(setting.StartTime, "HH:mm", null);
                    startTimeSettingHour = settingTime.Hour;
                    startTimeSettingMinute = settingTime.Minute;
                }
                catch
                {
                }
                if (startTimeSettingHour * 100 + startTimeSettingMinute < nowHour * 100 + nowMinute)
                {
                    return;
                }

                int lockScreenMinutes = setting.LockScreenDuration;
                if (IsSpecifyLockScreenMinutes)
                {
                    lockScreenMinutes = SpecifyLockScreenMinutes;
                }

                Logger.info("NotifyJob", "IsSpecifyLockScreenMinutes:", IsSpecifyLockScreenMinutes, "lockScreenMinutes:", lockScreenMinutes);
                LoggerUtil.Log(LoggType.Trigger, "指令:锁屏【" + lockScreenMinutes + "】分钟");

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
                ExecApp(notifyRunApp, notifyRunAppParam, notifyRunAppStartpath);
                Logger.info("NotifyJob", "lockScreen:", lockScreenApp, ", minutes:", lockScreenMinutes);

                JobManager.AddJob(new RecoveryJob(), (s) => s.WithName("RECOVERY").ToRunEvery(10).Seconds());


            }
            catch (Exception e)
            {
                Logger.info("NotifyJob", "IJob.Execute error:", e.Message, e.StackTrace);
            }

        }

        public static bool ExecApp(string app, string appParam, string appStartpath)
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
            catch (Exception e)
            {
                Logger.info("NotifyJob", "ExecApp error:", e.Message, e.StackTrace);
                return false;
            }
        }

    }

}