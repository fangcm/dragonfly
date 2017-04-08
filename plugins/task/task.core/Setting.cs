using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Dragonfly.Task.Core
{
    [XmlRoot("NotifySetting", Namespace = "", IsNullable = false)]
    public class NotifySetting
    {
        [XmlAttribute("LastTriggerTime")]
        public DateTime LastTriggerTime { get; set; }

        [XmlAttribute("EndTriggerTime")]
        public DateTime EndTriggerTime { get; set; }

        public static void SaveToFile(NotifySetting setting)
        {
            Helper.SaveToFile(Helper.NotifySettingFile, setting);
        }

        public static NotifySetting LoadFromFile()
        {
            return (NotifySetting)Helper.LoadFromFile(Helper.NotifySettingFile, typeof(NotifySetting));
        }

    }

    public class Helper
    {
        public static string NotifySettingFile
        {
            get { return Path.Combine(WorkingPath, "notify_setting.xml"); }
        }

        public static string WorkingPath
        {
            get
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string path = Path.Combine(appDataPath, "dragonfly");
                if (!Directory.Exists(path))
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                    }
                    catch
                    {
                        return appDataPath;
                    }
                }
                return path;
            }
        }

        public static void SaveToFile(string filePath, object obj)
        {
            if (!string.IsNullOrWhiteSpace(filePath) && obj != null)
            {
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                XmlWriterSettings settings = new XmlWriterSettings
                {
                    Indent = true,
                    IndentChars = "    ",
                    OmitXmlDeclaration = false,
                    Encoding = new UTF8Encoding(false),
                };


                XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
                using (XmlWriter writer = XmlWriter.Create(filePath, settings))
                {
                    xmlSerializer.Serialize(writer, obj, ns);
                }

            }
        }

        public static object LoadFromFile(string filePath, Type type)
        {
            object result = null;

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(type);
                    result = xmlSerializer.Deserialize(reader);
                }
            }

            return result;
        }
    }
}
