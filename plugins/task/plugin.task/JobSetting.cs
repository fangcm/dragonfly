using Dragonfly.Common.Utils;
using System;
using System.IO;
using System.Xml;

namespace Dragonfly.Plugin.Task
{
    internal class JobSetting
    {
        internal const int LockScreenApp_Basic = 0;

        internal const int NotifyInternalType_None = 0; //无操作
        internal const int NotifyInternalType_ShutDown = 1;
        internal const int NotifyInternalType_Hibernate = 2;

        private static JobSetting instance;
        private static readonly object locker = new object();

        public string SettingsFileName { get; private set; }

        public string Description { get; set; }
        public int IntervalMinutes { get; set; }
        public bool IsTooLateLockScreen { get; set; }
        public DateTime TooLateTriggerTime { get; set; }
        public int TooLateMinutes { get; set; }
        public bool IsLockScreen { get; set; }
        public int LockScreenMinutes { get; set; }
        public int LockScreenApp { get; set; }
        public int NotifyInternalType { get; set; }
        public bool IsNotifyRunApp { get; set; }
        public string NotifyRunApp { get; set; }
        public string NotifyRunAppParam { get; set; }
        public string NotifyRunAppStartpath { get; set; }
        public DateTime LastTriggerTime { get; set; }


        private JobSetting()
        {
            string path = AppConfig.WorkingPath;
            SettingsFileName = Path.Combine(path, "TaskSettings.xml");

            Description = "健康是生命之本，保护视力，从娃娃开始！";
            IntervalMinutes = 60; //重复间隔
            IsTooLateLockScreen = true;
            TooLateTriggerTime = new DateTime(2017, 2, 15, 22, 0, 0);
            TooLateMinutes = 60;
            IsLockScreen = true;
            LockScreenMinutes = 60;
            LockScreenApp = LockScreenApp_Basic;
            NotifyInternalType = NotifyInternalType_None;
            IsNotifyRunApp = false;
            NotifyRunApp = string.Empty;
            NotifyRunAppParam = string.Empty;
            NotifyRunAppStartpath = string.Empty;
            LastTriggerTime = DateTime.MinValue; //上次触发时间

        }

        public static JobSetting GetInstance()
        {
            if (instance == null)
            {
                lock (locker)
                {
                    if (instance == null)

                    {
                        instance = new JobSetting();
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
                XmlHelper xmlHelper = new XmlHelper();
                bool loaded = xmlHelper.Load(SettingsFileName);
                if (!loaded)
                {
                    LockScreenMinutes = AppConfig.GetInt("task.LockScreenMinutes", LockScreenMinutes);
                    LockScreenApp = AppConfig.GetInt("task.LockScreenApp", LockScreenApp);
                    IntervalMinutes = AppConfig.GetInt("task.IntervalMinutes", IntervalMinutes);
                    IsTooLateLockScreen = AppConfig.GetBoolean("task.IsTooLateLockScreen", IsTooLateLockScreen);
                    return false;
                }

                XmlNode xmlNode = xmlHelper.Document.SelectSingleNode("/TaskSettings/NotifyJob");

                Description = XmlHelper.GetElementText(xmlNode, "Description", Description);
                IntervalMinutes = XmlHelper.GetInt(xmlNode, "IntervalMinutes", IntervalMinutes);
                IsTooLateLockScreen = XmlHelper.GetBoolean(xmlNode, "IsTooLateLockScreen", IsTooLateLockScreen);
                TooLateTriggerTime = XmlHelper.GetDateTime(xmlNode, "TooLateTriggerTime", TooLateTriggerTime);
                TooLateMinutes = XmlHelper.GetInt(xmlNode, "TooLateMinutes", TooLateMinutes);
                IsLockScreen = XmlHelper.GetBoolean(xmlNode, "IsLockScreen", IsLockScreen);
                LockScreenMinutes = XmlHelper.GetInt(xmlNode, "LockScreenMinutes", LockScreenMinutes);
                LockScreenApp = XmlHelper.GetInt(xmlNode, "LockScreenApp", LockScreenApp);
                NotifyInternalType = XmlHelper.GetInt(xmlNode, "NotifyInternalType", NotifyInternalType);
                IsNotifyRunApp = XmlHelper.GetBoolean(xmlNode, "IsNotifyRunApp", IsNotifyRunApp);
                NotifyRunApp = XmlHelper.GetElementText(xmlNode, "NotifyRunApp", NotifyRunApp);
                NotifyRunAppParam = XmlHelper.GetElementText(xmlNode, "NotifyRunAppParam", NotifyRunAppParam);
                NotifyRunAppStartpath = XmlHelper.GetElementText(xmlNode, "NotifyRunAppStartpath", NotifyRunAppStartpath);
                LastTriggerTime = XmlHelper.GetDateTime(xmlNode, "LastTriggerTime", DateTime.MinValue);

                return true;
            }

        }

        public bool Save()
        {
            lock (locker)
            {
                XmlHelper xmlHelper = new XmlHelper();
                XmlElement xmlRoot = xmlHelper.CreateRootElement("TaskSettings");

                XmlNode xmlNode = xmlHelper.Document.CreateElement("NotifyJob");
                xmlRoot.AppendChild(xmlNode);

                XmlHelper.PutElementText(xmlNode, "Description", Description);
                XmlHelper.PutInt(xmlNode, "IntervalMinutes", IntervalMinutes);
                XmlHelper.PutBoolean(xmlNode, "IsTooLateLockScreen", IsTooLateLockScreen);
                XmlHelper.PutDateTime(xmlNode, "TooLateTriggerTime", TooLateTriggerTime);
                XmlHelper.PutInt(xmlNode, "TooLateMinutes", TooLateMinutes);
                XmlHelper.PutBoolean(xmlNode, "IsLockScreen", IsLockScreen);
                XmlHelper.PutInt(xmlNode, "LockScreenMinutes", LockScreenMinutes);
                XmlHelper.PutInt(xmlNode, "LockScreenApp", LockScreenApp);
                XmlHelper.PutInt(xmlNode, "NotifyInternalType", NotifyInternalType);
                XmlHelper.PutBoolean(xmlNode, "IsNotifyRunApp", IsNotifyRunApp);
                XmlHelper.PutElementText(xmlNode, "NotifyRunApp", NotifyRunApp);
                XmlHelper.PutElementText(xmlNode, "NotifyRunAppParam", NotifyRunAppParam);
                XmlHelper.PutElementText(xmlNode, "NotifyRunAppStartpath", NotifyRunAppStartpath);
                XmlHelper.PutDateTime(xmlNode, "LastTriggerTime", LastTriggerTime);

                return xmlHelper.Save(SettingsFileName);
            }
        }

        public int CaculateSchedulerInterval()
        {
            return IntervalMinutes + LockScreenMinutes;
        }

        public int CaculateRemainingMinutes()
        {
            if (!DateTime.MinValue.Equals(LastTriggerTime) && LastTriggerTime.AddMinutes(LockScreenMinutes).CompareTo(DateTime.Now) > 0)
            {
                return LockScreenMinutes - Convert.ToInt32((DateTime.Now - LastTriggerTime).TotalMinutes);
            }

            return 0;
        }

        public DateTime CaculateFirstTriggerTime(int suspendCount)
        {
            int remainingMinutes = CaculateRemainingMinutes();
            if (remainingMinutes > 0)
            {
                return DateTime.Now.AddMinutes(remainingMinutes + IntervalMinutes);
            }

            int minutes = IntervalMinutes;
            if (suspendCount >= 3)
            {
                minutes /= 3;
            }
            return DateTime.Now.AddMinutes(minutes);

        }


    }
}
