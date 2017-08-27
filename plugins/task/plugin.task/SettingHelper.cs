﻿using Dragonfly.Common.Utils;
using System;
using System.Collections.Generic;
using System.IO;

namespace Dragonfly.Plugin.Task
{
    internal class SettingHelper
    {
        internal const int LockScreenApp_Simple = 0;
        internal const int LockScreenApp_Question = 1;

        internal const int LockScreenType_Odd = 0; //奇数开始锁一个小时
        internal const int LockScreenType_Even = 1; //偶数开始锁一个小时
        internal const int LockScreenType_Ten = 2; //每小时锁十分钟
        internal const int LockScreenType_HalfHour = 3; //每小时锁30分钟

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
                LockScreenType = LockScreenType_Odd,
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
                    PluginSetting.NotifyJobSetting.LockScreenApp = AppConfig.GetInt("task.LockScreenApp", PluginSetting.NotifyJobSetting.LockScreenApp);
                    PluginSetting.NotifyJobSetting.LockScreenType = AppConfig.GetInt("task.LockScreenType", PluginSetting.NotifyJobSetting.LockScreenType);
                    PluginSetting.NotifyJobSetting.IsTooLateLockScreen = AppConfig.GetBoolean("task.IsTooLateLockScreen", PluginSetting.NotifyJobSetting.IsTooLateLockScreen);
                    return false;
                }

                if (setting.NotifyJobSetting == null)
                {
                    setting.NotifyJobSetting = DefaultNotifyJobSetting();
                }

                PluginSetting = setting;
                PluginSetting.NotifyJobSetting.LockScreenType = LockScreenType_HalfHour;

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

        public Dictionary<string, int> CaculateRemainingMinutes()
        {
            Dictionary<string, int> ret = new Dictionary<string, int>();
            NotifySetting notifySetting = NotifySetting.LoadFromFile();

            DateTime now = DateTime.Now;

            int remainingMinutes = 0;
            int interval = 120;
            int lockMinutes = 60;
            int delayMinutes = 0;

            int start; //起始时间点

            switch (PluginSetting.NotifyJobSetting.LockScreenType)
            {
                case LockScreenType_Odd: //奇数开始锁
                    if ((now.Hour & 1) == 0)
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
                case LockScreenType_Even: //偶数开始锁
                    if ((now.Hour & 1) == 0)
                    {
                        remainingMinutes = 60 - now.Minute;
                        delayMinutes = 0 - now.Minute;
                    }
                    else
                    {
                        remainingMinutes = 0;
                        delayMinutes = 0 - 60 - now.Minute;
                    }
                    break;
                case LockScreenType_Ten: //每小时锁十分钟
                    interval = 60;
                    lockMinutes = 10;
                    start = 40;
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

                case LockScreenType_HalfHour: //每小时锁30分钟
                    interval = 60;
                    lockMinutes = 30;
                    start = 20;
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
            }

            ret.Add("remainingMinutes", remainingMinutes);
            ret.Add("interval", interval);
            ret.Add("lockMinutes", lockMinutes);
            ret.Add("delayMinutes", delayMinutes);

            return ret;
        }

    }
}
