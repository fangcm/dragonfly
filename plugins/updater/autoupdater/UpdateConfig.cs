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
    }

    [XmlRoot("FileInfo")]
    public class FileInfo
    {
        [XmlElement("PublishPath")]
        public string PublishPath { get; set; }

        [XmlElement("FileName")]
        public string FileName { get; set; }
    }

}
