using Dragonfly.Common.Utils;
using System;
using System.Collections.Generic;
using System.IO;

namespace Dragonfly.Plugin.GridTrading
{
    internal class SettingHelper
    {
        internal const string ConnenctionString = @"Data Source=grid_trading.db;Version=3;";
        internal const int LockScreenApp_Simple = 0;
        internal const int LockScreenApp_Question = 1;

        internal const int LockScreenType_OneHour = 1; //周期为1个小时
        internal const int LockScreenType_TwoHour = 2; //周期为2个小时

        private static SettingHelper instance;
        private static readonly object locker = new object();

        public string SettingsFileName { get; private set; }
        public PluginSetting PluginSetting { get; private set; }

        private SettingHelper()
        {
            string path = AppConfig.WorkingPath;
            SettingsFileName = Path.Combine(path, "GridTradingSettings.xml");
            PluginSetting = new PluginSetting()
            {
                NotifyJobSetting = DefaultNotifyJobSetting(),
            };

        }

        private NotifyJobSetting DefaultNotifyJobSetting()
        {
            return new NotifyJobSetting()
            {
                IsTooLateLockScreen = true,
                TooLateTriggerTime = "21:30",
                TooLateMinutes = 120,
                LockScreenApp = LockScreenApp_Simple,
                LockScreenType = LockScreenType_OneHour,
                LockScreenDuration = 30,
                StartTime = "10:00"
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

        public void Load()
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
                    PluginSetting.NotifyJobSetting.LockScreenApp = AppConfig.GetInt("gridTrading.LockScreenApp", PluginSetting.NotifyJobSetting.LockScreenApp);
                    PluginSetting.NotifyJobSetting.LockScreenType = AppConfig.GetInt("gridTrading.LockScreenType", PluginSetting.NotifyJobSetting.LockScreenType);
                    PluginSetting.NotifyJobSetting.IsTooLateLockScreen = AppConfig.GetBoolean("gridTrading.IsTooLateLockScreen", PluginSetting.NotifyJobSetting.IsTooLateLockScreen);
                }
                else
                {

                    if (setting.NotifyJobSetting == null)
                    {
                        setting.NotifyJobSetting = DefaultNotifyJobSetting();
                    }
                    PluginSetting = setting;
                }

                if (PluginSetting.NotifyJobSetting.LockScreenType == LockScreenType_OneHour)
                {
                    if (PluginSetting.NotifyJobSetting.LockScreenDuration > 30 ||
                        PluginSetting.NotifyJobSetting.LockScreenDuration < 1)
                    {
                        PluginSetting.NotifyJobSetting.LockScreenDuration = 30;
                    }
                }
                else if (PluginSetting.NotifyJobSetting.LockScreenType == LockScreenType_TwoHour)
                {
                    PluginSetting.NotifyJobSetting.LockScreenDuration = 60;
                }
                else
                {
                    PluginSetting.NotifyJobSetting.LockScreenType = LockScreenType_OneHour;
                    PluginSetting.NotifyJobSetting.LockScreenDuration = 30;
                }
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

        public Dictionary<string, int> CaculateRemainingMinutes()
        {
            Dictionary<string, int> ret = new Dictionary<string, int>();
            NotifySetting notifySetting = NotifySetting.LoadFromFile();

            DateTime now = DateTime.Now;

            int interval;
            int lockMinutes;
            int start; //起始时间点

            int remainingMinutes = 0;
            int delayMinutes = 0;


            switch (PluginSetting.NotifyJobSetting.LockScreenType)
            {
                case LockScreenType_OneHour: //周期为1小时
                default:
                    interval = 60;
                    lockMinutes = PluginSetting.NotifyJobSetting.LockScreenDuration;
                    start = 50 - lockMinutes;
                    if (now.Minute >= start && now.Minute < start + lockMinutes)
                    {
                        remainingMinutes = lockMinutes - (now.Minute - start);
                        delayMinutes = 0 - (now.Minute - start);
                    }
                    else
                    {
                        remainingMinutes = 0;
                        delayMinutes = start - now.Minute;
                        if (start > now.Minute)
                        {
                            delayMinutes -= 60;
                        }

                    }
                    break;

                case LockScreenType_TwoHour: //周期为1小时,奇数或偶数开始锁
                    interval = 120;
                    lockMinutes = 60;
                    if ((now.Hour & 1) == (PluginSetting.NotifyJobSetting.LockScreenDuration & 1))
                    {
                        remainingMinutes = 0;
                        delayMinutes = 0 - 60 - now.Minute;
                    }
                    else
                    {
                        remainingMinutes = 60 - now.Minute;
                        delayMinutes = 0 - now.Minute;
                    }
                    break;

            }

            ret.Add("remainingMinutes", remainingMinutes);
            ret.Add("interval", interval);
            ret.Add("lockMinutes", lockMinutes);
            ret.Add("delayMinutes", delayMinutes);

            return ret;
        }

    }
}
