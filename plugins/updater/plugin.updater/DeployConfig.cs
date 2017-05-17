using System;
using System.Xml.Serialization;

namespace Dragonfly.Plugin.Updater
{
    [XmlRoot("Deploy", Namespace = "")]
    public class DeployConfig
    {
        [XmlElement("LastDeployTime")]
        public DateTime LastDeployTime { get; set; }

        [XmlElement("LastDeployFileName")]
        public string LastDeployFileName { get; set; }
    }

}
