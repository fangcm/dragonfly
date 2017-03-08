using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Dragonfly.Plugin.Task
{
    [XmlRootAttribute("TaskSettings", Namespace = "", IsNullable = false)]
    public class PluginSetting
    {
        [XmlElementAttribute("NotifyJob")]
        public NotifyJobSetting NotifyJobSetting { get; set; }

        [XmlElementAttribute("Adjustment")]
        public AdjustmentSetting AdjustmentSetting { get; set; }
        
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

    [XmlRootAttribute("Adjustment")]
    public class AdjustmentSetting
    {
        [XmlAttribute("IntervalSeconds")]
        public int IntervalSeconds { get; set; }

        [XmlArrayAttribute("Conditions")]
        public List<AdjustmentCondition> Conditions { get; set; }

        public AdjustmentSetting()
        {
            Conditions = new List<AdjustmentCondition>();
        }
    }

    [XmlRootAttribute("Condition")]
    public class AdjustmentCondition
    {
        //0 filename, 1 title, 2 processname
        [XmlAttribute("ConditionType")]
        public int ConditionType { get; set; }

        [XmlElementAttribute("ConditionValue")]
        public string ConditionValue { get; set; }

        [XmlAttribute("Accumulated")]
        public bool Accumulated { get; set; }

        [XmlAttribute("IsIgnoreLock")]
        public bool IsIgnoreLock { get; set; }

        [XmlAttribute("SpanSeconds")]
        public int SpanSeconds { get; set; }
    }
}
