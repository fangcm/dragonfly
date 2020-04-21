using Dragonfly.Common.Utils;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Dragonfly.Plugin.GridTrading
{
    [XmlRoot("GridTradingSettings", Namespace = "", IsNullable = false)]
    public class PluginSetting
    {
        [XmlElement("NotifyJob")]
        public NotifyJobSetting NotifyJobSetting { get; set; }

    }

    [XmlRoot("NotifyJob")]
    public class NotifyJobSetting
    {
        [XmlAttribute("IsTooLateLockScreen")]
        public bool IsTooLateLockScreen { get; set; }

        [XmlAttribute("TooLateTriggerTime")]
        public string TooLateTriggerTime { get; set; }

        [XmlAttribute("TooLateMinutes")]
        public int TooLateMinutes { get; set; }

        [XmlAttribute("LockScreenApp")]
        public int LockScreenApp { get; set; }

        [XmlAttribute("LockScreenType")]
        public int LockScreenType { get; set; }

        [XmlAttribute("LockScreenDuration")]
        public int LockScreenDuration { get; set; }

        [XmlAttribute("StartTime")]
        public string StartTime { get; set; }
    }


    [XmlRoot("NotifySetting", Namespace = "", IsNullable = false)]
    public class NotifySetting
    {
        [XmlAttribute("LastTriggerTime")]
        public DateTime LastTriggerTime { get; set; }

        [XmlAttribute("EndTriggerTime")]
        public DateTime EndTriggerTime { get; set; }

        public static NotifySetting LoadFromFile()
        {
            return (NotifySetting)XmlHelper.LoadFromFile(NotifySetting.GetNotifySettingFile(), typeof(NotifySetting));
        }

        public static string GetNotifySettingFile()
        {
            return Path.Combine(AppConfig.WorkingPath, "notify_setting.xml");
        }

    }
}
