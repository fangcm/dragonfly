using Dragonfly.Common.Utils;
using System;
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
                LastTriggerTime = DateTime.MinValue, //上次触发时间
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

        public int CaculateRemainingMinutes()
        {
            if (!DateTime.MinValue.Equals(PluginSetting.NotifyJobSetting.LastTriggerTime) &&
                PluginSetting.NotifyJobSetting.LastTriggerTime.AddMinutes(PluginSetting.NotifyJobSetting.LockScreenMinutes).CompareTo(DateTime.Now) > 0)
            {
                int remainingMinutes = PluginSetting.NotifyJobSetting.LockScreenMinutes - Convert.ToInt32((DateTime.Now - PluginSetting.NotifyJobSetting.LastTriggerTime).TotalMinutes);
                return remainingMinutes < 0 ? 0 : remainingMinutes;
            }

            return 0;
        }

        public int CaculateFirstDelayMinutes(int suspendCount)
        {
            int ret = 0;

            int remainingMinutes = CaculateRemainingMinutes();
            if (remainingMinutes > 0)
            {
                ret = remainingMinutes;
            }
            else
            {
                if (suspendCount >= 3)
                {
                    int minutes = PluginSetting.NotifyJobSetting.IntervalMinutes / suspendCount;
                    ret = minutes - PluginSetting.NotifyJobSetting.IntervalMinutes;
                }

            }

            return ret - PluginSetting.NotifyJobSetting.LockScreenMinutes;

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
