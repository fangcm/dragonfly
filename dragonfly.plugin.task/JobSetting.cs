using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using FluentScheduler;
using Dragonfly.Common.Utils;
using System.Xml;

namespace Dragonfly.Plugin.Task
{
    internal class JobSetting
    {
        private static JobSetting instance;
        private static readonly object locker = new object();

        internal static readonly int NotifyInternalType_None = 0;
        internal static readonly int NotifyInternalType_ShutDown = 1;
        internal static readonly int NotifyInternalType_Hibernate = 2;

        private string sSettingsFileName;

        private string description = "健康是生命之本，保护视力，从娃娃开始！";
        private int intervalMinutes = 60; //重复间隔
        private bool isLockScreen = true;
        private int lockScreenMinutes = 60;
        private int notifyInternalType = 0; //无操作
        private bool isNotifyRunApp = false;
        private string notifyRunApp;
        private string notifyRunAppParam;
        private string notifyRunAppStartpath;

        private DateTime lastTriggerTime = DateTime.MinValue; //上次触发时间
        private DateTime lastTurnOffMachineTime = DateTime.MinValue; //上次关机时间，不需要保存
        private DateTime turnOnMachineTime = DateTime.Now; //开机时间，不需要保存

        private JobSetting()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = appDataPath + "\\fangcm\\";
            Util.CreateDirectory(path);
            this.sSettingsFileName = path + "TaskSettings.xml";
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

        public DateTime TurnOnMachineTime
        {
            get { return turnOnMachineTime; }
            set { turnOnMachineTime = value; }
        }

        public DateTime LastTurnOffMachineTime
        {
            get { return lastTurnOffMachineTime; }
            set { lastTurnOffMachineTime = value; }
        }

        public bool Load()
        {
            lock (locker)
            {
                XmlDocument xmlDocument = XmlHelper.Load(sSettingsFileName);
                if (xmlDocument == null)
                {
                    return false;
                }

                XmlNode xmlNode = xmlDocument.SelectSingleNode("/TaskSettings/NotifyJob");

                description = XmlHelper.GetElementText(xmlNode, "Description");
                intervalMinutes = XmlHelper.GetAttributeValue(xmlNode, "IntervalMinutes", 60);
                isLockScreen = XmlHelper.GetAttributeValue(xmlNode, "IsLockScreen", true);
                lockScreenMinutes = XmlHelper.GetAttributeValue(xmlNode, "LockScreenMinutes", 60);
                notifyInternalType = XmlHelper.GetAttributeValue(xmlNode, "NotifyInternalType", 0);
                isNotifyRunApp = XmlHelper.GetAttributeValue(xmlNode, "IsNotifyRunApp", false);
                notifyRunApp = XmlHelper.GetElementText(xmlNode, "NotifyRunApp");
                notifyRunAppParam = XmlHelper.GetElementText(xmlNode, "NotifyRunAppParam");
                notifyRunAppStartpath = XmlHelper.GetElementText(xmlNode, "NotifyRunAppStartpath");
                lastTriggerTime = XmlHelper.GetAttributeValue(xmlNode, "LastTriggerTime", DateTime.MinValue);
                lastTurnOffMachineTime = XmlHelper.GetAttributeValue(xmlNode, "LastTurnOffMachineTime", DateTime.MinValue);

                return true;
            }

        }

        public bool Save()
        {
            lock (locker)
            {
                XmlDocument xmlDocument = new XmlDocument();
                XmlDeclaration xmldecl = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDocument.AppendChild(xmldecl);

                XmlNode xmlRoot = xmlDocument.CreateNode("element", "TaskSettings", "");
                xmlDocument.AppendChild(xmlRoot);

                XmlNode xmlNode = xmlDocument.CreateNode("element", "NotifyJob", "");

                XmlHelper.PutElementText(xmlNode, "Description", description);
                XmlHelper.PutAttributeValue(xmlNode, "IntervalMinutes", intervalMinutes);
                XmlHelper.PutAttributeValue(xmlNode, "IsLockScreen", isLockScreen);
                XmlHelper.PutAttributeValue(xmlNode, "LockScreenMinutes", lockScreenMinutes);
                XmlHelper.PutAttributeValue(xmlNode, "NotifyInternalType", notifyInternalType);
                XmlHelper.PutAttributeValue(xmlNode, "IsNotifyRunApp", isNotifyRunApp);
                XmlHelper.PutElementText(xmlNode, "NotifyRunApp", notifyRunApp);
                XmlHelper.PutElementText(xmlNode, "NotifyRunAppParam", notifyRunAppParam);
                XmlHelper.PutElementText(xmlNode, "NotifyRunAppStartpath", notifyRunAppStartpath);
                XmlHelper.PutAttributeValue(xmlNode, "LastTriggerTime", lastTriggerTime);
                XmlHelper.PutAttributeValue(xmlNode, "LastTurnOffMachineTime", lastTurnOffMachineTime);

                xmlRoot.AppendChild(xmlNode);

                return XmlHelper.Save(sSettingsFileName, xmlDocument);
            }
        }

    }
}
