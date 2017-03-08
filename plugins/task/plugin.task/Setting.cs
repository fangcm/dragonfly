﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Dragonfly.Plugin.Task
{
    [XmlRoot("TaskSettings", Namespace = "", IsNullable = false)]
    public class PluginSetting
    {
        [XmlElement("NotifyJob")]
        public NotifyJobSetting NotifyJobSetting { get; set; }

        [XmlElement("Adjustment")]
        public AdjustmentSetting AdjustmentSetting { get; set; }
        
    }

    [XmlRoot("NotifyJob")]
    public class NotifyJobSetting
    {
        [XmlElement("Description")]
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

        [XmlElement("NotifyRunApp")]
        public string NotifyRunApp { get; set; }

        [XmlElement("NotifyRunAppParam")]
        public string NotifyRunAppParam { get; set; }

        [XmlElement("NotifyRunAppStartpath")]
        public string NotifyRunAppStartpath { get; set; }

        [XmlAttribute("LastTriggerTime")]
        public DateTime LastTriggerTime { get; set; }
    }

    [XmlRoot("Adjustment")]
    public class AdjustmentSetting
    {
        [XmlAttribute("IntervalSeconds")]
        public int IntervalSeconds { get; set; }

        [XmlArray("Conditions")]
        public List<AdjustmentCondition> Conditions { get; set; }

        public AdjustmentSetting()
        {
            Conditions = new List<AdjustmentCondition>();
        }
    }

    [XmlRoot("Condition")]
    public class AdjustmentCondition
    {
        //0 filename, 1 title, 2 processname
        [XmlAttribute("ConditionType")]
        public int ConditionType { get; set; }

        [XmlElement("ConditionValue")]
        public string ConditionValue { get; set; }

        [XmlAttribute("Accumulated")]
        public bool Accumulated { get; set; }

        [XmlAttribute("IsIgnoreLock")]
        public bool IsIgnoreLock { get; set; }

        [XmlAttribute("SpanSeconds")]
        public int SpanSeconds { get; set; }
    }
}
