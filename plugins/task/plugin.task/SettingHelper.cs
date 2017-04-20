using Dragonfly.Common.Utils;
using System;
using System.Collections.Generic;
using System.IO;

namespace Dragonfly.Plugin.Task
{
    internal class SettingHelper
    {
        internal const int LockScreenApp_Simple = 0;
        internal const int LockScreenApp_Question = 1;

        internal const int NotifyInternalType_None = 0; //无操作
        internal const int NotifyInternalType_ShutDown = 1;
        internal const int NotifyInternalType_Hibernate = 2;

        private static SettingHelper instance;
        private static readonly object locker = new object();

        public string SettingsFileName { get; private set; }
        public PluginSetting PluginSetting { get; private set; }

        private SettingHelper()
        {
            string path = AppConfig.WorkingPath;
            SettingsFileName = Path.Combine(path, "TaskSettings.xml");
            PluginSetting = new PluginSetting()
            {
                NotifyJobSetting = DefaultNotifyJobSetting(),
                AdjustmentSetting = DefaultAdjustmentSetting(),
            };

        }

        private NotifyJobSetting DefaultNotifyJobSetting()
        {
            return new NotifyJobSetting()
            {
                Description = "健康是生命之本，保护视力，从娃娃开始！",
                IntervalMinutes = 60, //重复间隔
                IsTooLateLockScreen = true,
                TooLateTriggerTime = "21:00",
                TooLateMinutes = 60,
                IsLockScreen = true,
                LockScreenMinutes = 60,
                LockScreenApp = LockScreenApp_Simple,
                NotifyInternalType = NotifyInternalType_None,
                IsAppAdjustment = true,
                IsNotifyRunApp = false,
                NotifyRunApp = string.Empty,
                NotifyRunAppParam = string.Empty,
                NotifyRunAppStartpath = string.Empty,
            };
        }

        private AdjustmentSetting DefaultAdjustmentSetting()
        {
            return new AdjustmentSetting()
            {
                IntervalSeconds = 60,
            };
        }

        public static SettingHelper GetInstance()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)

                    {
                        instance = new SettingHelper();
                        instance.Load();
                    }
                }
            }
            return instance;
        }

        public bool Load()
        {
            lock (locker)
            {
                PluginSetting setting = null;
                try
                {
                    setting = (PluginSetting)XmlHelper.LoadFromFile(SettingsFileName, typeof(PluginSetting));
                }
                catch (Exception e)
                {
                    Logger.error("SettingHelper", "Load setting:", e.Message);
                }
                if (setting == null)
                {
                    PluginSetting.NotifyJobSetting.LockScreenMinutes = AppConfig.GetInt("task.LockScreenMinutes", PluginSetting.NotifyJobSetting.LockScreenMinutes);
                    PluginSetting.NotifyJobSetting.LockScreenApp = AppConfig.GetInt("task.LockScreenApp", PluginSetting.NotifyJobSetting.LockScreenApp);
                    PluginSetting.NotifyJobSetting.IntervalMinutes = AppConfig.GetInt("task.IntervalMinutes", PluginSetting.NotifyJobSetting.IntervalMinutes);
                    PluginSetting.NotifyJobSetting.IsTooLateLockScreen = AppConfig.GetBoolean("task.IsTooLateLockScreen", PluginSetting.NotifyJobSetting.IsTooLateLockScreen);
                    return false;
                }

                if (setting.NotifyJobSetting == null)
                {
                    setting.NotifyJobSetting = DefaultNotifyJobSetting();
                }
                if (setting.AdjustmentSetting == null)
                {
                    setting.AdjustmentSetting = DefaultAdjustmentSetting();
                }

                PluginSetting = setting;

                return true;
            }

        }

        public bool Save()
        {
            lock (locker)
            {
                try
                {
                    XmlHelper.SaveToFile(SettingsFileName, PluginSetting);
                    return true;
                }
                catch (Exception e)
                {
                    Logger.error("SettingHelper", "Save setting:", e.Message);
                    return false;
                }
            }
        }

        public int CaculateSchedulerInterval()
        {
            return PluginSetting.NotifyJobSetting.IntervalMinutes + PluginSetting.NotifyJobSetting.LockScreenMinutes;
        }

        public Dictionary<string, int> CaculateRemainingMinutes()
        {
            Dictionary<string, int> ret = new Dictionary<string, int>();
            NotifySetting notifySetting = NotifySetting.LoadFromFile();

            int delayMinutes = 0;
            int remainingMinutes = 0;
            if (notifySetting != null && notifySetting.EndTriggerTime != null && !DateTime.MinValue.Equals(notifySetting.EndTriggerTime))
            {
                remainingMinutes = Convert.ToInt32((notifySetting.EndTriggerTime - DateTime.Now).TotalMinutes);
                if (remainingMinutes < 0)
                { //非正锁屏中
                    if (remainingMinutes > 0 - PluginSetting.NotifyJobSetting.IntervalMinutes)
                    { //上次退出锁屏在周期内，继续本周期
                        delayMinutes = remainingMinutes;
                    }
                    remainingMinutes = 0;
                }
            }

            ret.Add("remainingMinutes", remainingMinutes);

            delayMinutes -= PluginSetting.NotifyJobSetting.LockScreenMinutes;
            ret.Add("delayMinutes", delayMinutes);

            return ret;
        }

        public int CaculateDelaySecondsAtTime(DateTime nextRun)
        {
            int ret = Convert.ToInt32((nextRun - DateTime.Now).TotalSeconds);
            ret -= (PluginSetting.NotifyJobSetting.IntervalMinutes * 60);
            ret -= (PluginSetting.NotifyJobSetting.LockScreenMinutes * 60);

            return ret;

        }



    }
}
