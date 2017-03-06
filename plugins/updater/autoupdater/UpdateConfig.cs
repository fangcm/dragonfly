using System.Collections.Generic;
using System.Xml.Serialization;

namespace Dragonfly.Updater
{
    [XmlRootAttribute("UpdateConfig")]
    public class UpdateConfig
    {
        [XmlArrayAttribute("CopyFiles")]
        public List<FileInfo> CopyFiles { get; set; }

        [XmlArrayAttribute("DeleteFiles")]
        public List<FileInfo> DeleteFiles { get; set; }
    }

    [XmlRootAttribute("FileInfo")]
    public class FileInfo
    {
        [XmlElementAttribute("PublishPath")]
        public string PublishPath { get; set; }

        [XmlElementAttribute("FileName")]
        public string FileName { get; set; }
    }

}
