using System.Collections.Generic;
using System.Xml.Serialization;

namespace Dragonfly.Updater
{
    [XmlRoot("UpdateConfig")]
    public class UpdateConfig
    {
        [XmlArray("CopyFiles")]
        public List<FileInfo> CopyFiles { get; set; }

        [XmlArray("DeleteFiles")]
        public List<FileInfo> DeleteFiles { get; set; }

        [XmlArray("Commands")]
        public List<CommandInfo> Commands { get; set; }
    }

    [XmlRoot("FileInfo")]
    public class FileInfo
    {
        [XmlElement("PublishPath")]
        public string PublishPath { get; set; }

        [XmlElement("FileName")]
        public string FileName { get; set; }
    }

    [XmlRoot("CommandInfo")]
    public class CommandInfo
    {
        [XmlElement("Type")]
        public string Type { get; set; }

        [XmlElement("FileName")]
        public string FileName { get; set; }

        [XmlElement("Param")]
        public string Param { get; set; }

        [XmlElement("Startpath")]
        public string Startpath { get; set; }
    }

}
