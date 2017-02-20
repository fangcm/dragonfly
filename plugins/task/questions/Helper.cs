using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Dragonfly.Questions
{
    public class Helper
    {
        public static void SaveExaminationToFile(string filePath, Examination exam)
        {
            SaveToFile(filePath, exam);
        }

        public static Examination LoadExaminationFromFile(string filePath)
        {
            return (Examination)LoadFromFile(filePath, typeof(Examination));
        }

        public static void SaveToFile(string filePath, object exam)
        {
            if (!string.IsNullOrWhiteSpace(filePath) && exam != null)
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(exam.GetType());
                    xmlSerializer.Serialize(writer, exam);
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
