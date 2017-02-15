using Dragonfly.Common.Utils;
using System;
using System.IO;
using System.Xml;

namespace Dragonfly.Plugin.Task
{
    internal class JobSetting
    {
        internal const int NotifyInternalType_None = 0;
        internal const int NotifyInternalType_ShutDown = 1;
        internal const int NotifyInternalType_Hibernate = 2;

        private static JobSetting instance;
        private static readonly object locker = new object();

        private string sSettingsFileName;

        private string description = "健康是生命之本，保护视力，从娃娃开始！";
        private int intervalMinutes = 60; //重复间隔
        private bool isTooLateLockScreen = true;
        private DateTime tooLateTriggerTime = new DateTime(2017, 2, 15, 22, 0, 0);
        private int tooLateMinutes = 60;
        private bool isLockScreen = true;
        private int lockScreenMinutes = 60;
        private int notifyInternalType = 0; //无操作
        private bool isNotifyRunApp = false;
        private string notifyRunApp = string.Empty;
        private string notifyRunAppParam = string.Empty;
        private string notifyRunAppStartpath = string.Empty;

        private DateTime lastTriggerTime = DateTime.MinValue; //上次触发时间

        private JobSetting()
        {
            string path = AppConfig.WorkingPath;
            this.sSettingsFileName = Path.Combine(path, "TaskSettings.xml");
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

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int IntervalMinutes
        {
            get { return intervalMinutes; }
            set { intervalMinutes = value; }
        }

        public bool IsTooLateLockScreen
        {
            get { return isTooLateLockScreen; }
            set { isTooLateLockScreen = value; }
        }

        public DateTime TooLateTriggerTime
        {
            get { return tooLateTriggerTime; }
            set { tooLateTriggerTime = value; }
        }

        public int TooLateMinutes
        {
            get { return tooLateMinutes; }
            set { tooLateMinutes = value; }
        }

        public bool IsLockScreen
        {
            get { return isLockScreen; }
            set { isLockScreen = value; }
        }

        public int LockScreenMinutes
        {
            get { return lockScreenMinutes; }
            set { lockScreenMinutes = value; }
        }

        public int NotifyInternalType
        {
            get { return notifyInternalType; }
            set { notifyInternalType = value; }
        }


        public bool IsNotifyRunApp
        {
            get { return isNotifyRunApp; }
            set { isNotifyRunApp = value; }
        }

        public string NotifyRunApp
        {
            get { return notifyRunApp; }
            set { notifyRunApp = value; }
        }

        public string NotifyRunAppParam
        {
            get { return notifyRunAppParam; }
            set { notifyRunAppParam = value; }
        }

        public string NotifyRunAppStartpath
        {
            get { return notifyRunAppStartpath; }
            set { notifyRunAppStartpath = value; }
        }

        public DateTime LastTriggerTime
        {
            get { return lastTriggerTime; }
            set { lastTriggerTime = value; }
        }

        public bool Load()
        {
            lock (locker)
            {
                XmlHelper xmlHelper = new XmlHelper();
                bool loaded = xmlHelper.Load(sSettingsFileName);
                if (!loaded)
                {
                    lockScreenMinutes = AppConfig.GetInt("task.LockScreenMinutes", lockScreenMinutes);
                    intervalMinutes = AppConfig.GetInt("task.IntervalMinutes", intervalMinutes);
                    isTooLateLockScreen = AppConfig.GetBoolean("task.IsTooLateLockScreen", isTooLateLockScreen);
                    return false;
                }

                XmlNode xmlNode = xmlHelper.Document.SelectSingleNode("/TaskSettings/NotifyJob");

                description = XmlHelper.GetElementText(xmlNode, "Description", description);
                intervalMinutes = XmlHelper.GetInt(xmlNode, "IntervalMinutes", intervalMinutes);
                isTooLateLockScreen = XmlHelper.GetBoolean(xmlNode, "IsTooLateLockScreen", isTooLateLockScreen);
                tooLateTriggerTime = XmlHelper.GetDateTime(xmlNode, "TooLateTriggerTime", tooLateTriggerTime);
                tooLateMinutes = XmlHelper.GetInt(xmlNode, "TooLateMinutes", tooLateMinutes);
                isLockScreen = XmlHelper.GetBoolean(xmlNode, "IsLockScreen", isLockScreen);
                lockScreenMinutes = XmlHelper.GetInt(xmlNode, "LockScreenMinutes", lockScreenMinutes);
                notifyInternalType = XmlHelper.GetInt(xmlNode, "NotifyInternalType", notifyInternalType);
                isNotifyRunApp = XmlHelper.GetBoolean(xmlNode, "IsNotifyRunApp", isNotifyRunApp);
                notifyRunApp = XmlHelper.GetElementText(xmlNode, "NotifyRunApp", notifyRunApp);
                notifyRunAppParam = XmlHelper.GetElementText(xmlNode, "NotifyRunAppParam", notifyRunAppParam);
                notifyRunAppStartpath = XmlHelper.GetElementText(xmlNode, "NotifyRunAppStartpath", notifyRunAppStartpath);
                lastTriggerTime = XmlHelper.GetDateTime(xmlNode, "LastTriggerTime", DateTime.MinValue);

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

                XmlHelper.PutElementText(xmlNode, "Description", description);
                XmlHelper.PutInt(xmlNode, "IntervalMinutes", intervalMinutes);
                XmlHelper.PutBoolean(xmlNode, "IsTooLateLockScreen", isTooLateLockScreen);
                XmlHelper.PutDateTime(xmlNode, "TooLateTriggerTime", tooLateTriggerTime);
                XmlHelper.PutInt(xmlNode, "TooLateMinutes", tooLateMinutes);
                XmlHelper.PutBoolean(xmlNode, "IsLockScreen", isLockScreen);
                XmlHelper.PutInt(xmlNode, "LockScreenMinutes", lockScreenMinutes);
                XmlHelper.PutInt(xmlNode, "NotifyInternalType", notifyInternalType);
                XmlHelper.PutBoolean(xmlNode, "IsNotifyRunApp", isNotifyRunApp);
                XmlHelper.PutElementText(xmlNode, "NotifyRunApp", notifyRunApp);
                XmlHelper.PutElementText(xmlNode, "NotifyRunAppParam", notifyRunAppParam);
                XmlHelper.PutElementText(xmlNode, "NotifyRunAppStartpath", notifyRunAppStartpath);
                XmlHelper.PutDateTime(xmlNode, "LastTriggerTime", lastTriggerTime);

                return xmlHelper.Save(sSettingsFileName);
            }
        }

        public int caculateSchedulerInterval()
        {
            return intervalMinutes + LockScreenMinutes;
        }

        public int caculateRemainingMinutes()
        {
            if (!DateTime.MinValue.Equals(lastTriggerTime) && lastTriggerTime.AddMinutes(LockScreenMinutes).CompareTo(DateTime.Now) > 0)
            {
                return LockScreenMinutes - (DateTime.Now - lastTriggerTime).Minutes;
            }

            return 0;
        }

        public DateTime caculateFirstTriggerTime()
        {
            int remainingMinutes = caculateRemainingMinutes();
            if (remainingMinutes > 0)
            {
                return DateTime.Now.AddMinutes(remainingMinutes + intervalMinutes);
            }

            return DateTime.Now.AddMinutes(intervalMinutes);

        }


    }
}
