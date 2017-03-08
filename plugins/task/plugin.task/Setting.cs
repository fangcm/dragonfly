using System;
using System.Xml.Serialization;

namespace Dragonfly.Plugin.Task
{
    [XmlRootAttribute("TaskSettings", Namespace = "", IsNullable = false)]
    public class PluginSetting
    {
        [XmlElementAttribute("NotifyJob")]
        public NotifyJobSetting NotifyJobSetting { get; set; }
    }

    [XmlRootAttribute("NotifyJob")]
    public class NotifyJobSetting
    {
        [XmlElementAttribute("Description")]
        public string Description { get; set; }

        [XmlAttribute("IntervalMinutes")]
        public int IntervalMinutes { get; set; }

        [XmlAttribute("IsTooLateLockScreen")]
        public bool IsTooLateLockScreen { get; set; }

        [XmlAttribute("TooLateTriggerTime")]
        public DateTime TooLateTriggerTime { get; set; }

        [XmlAttribute("TooLateMinutes")]
        public int TooLateMinutes { get; set; }

        [XmlAttribute("IsLockScreen")]
        public bool IsLockScreen { get; set; }

        [XmlAttribute("LockScreenMinutes")]
        public int LockScreenMinutes { get; set; }

        [XmlAttribute("LockScreenApp")]
        public int LockScreenApp { get; set; }

        [XmlAttribute("NotifyInternalType")]
        public int NotifyInternalType { get; set; }

        [XmlAttribute("IsNotifyRunApp")]
        public bool IsNotifyRunApp { get; set; }

        [XmlElementAttribute("NotifyRunApp")]
        public string NotifyRunApp { get; set; }

        [XmlElementAttribute("NotifyRunAppParam")]
        public string NotifyRunAppParam { get; set; }

        [XmlElementAttribute("NotifyRunAppStartpath")]
        public string NotifyRunAppStartpath { get; set; }

        [XmlAttribute("LastTriggerTime")]
        public DateTime LastTriggerTime { get; set; }
    }
    
}
