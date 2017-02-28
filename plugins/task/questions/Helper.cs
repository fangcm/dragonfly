using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
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

        public static string SaveExaminationToString(Examination exam)
        {
            return SaveToString(exam);
        }

        public static Examination LoadExaminationFromString(string xml)
        {
            return (Examination)LoadFromString(xml, typeof(Examination));
        }

        public static void SaveMockResultToFile(string filePath, MockResult mockResult)
        {
            SaveToFile(filePath, mockResult);
        }

        public static MockResult LoadMockResultFromFile(string filePath)
        {
            return (MockResult)LoadFromFile(filePath, typeof(MockResult));
        }

        public static string SaveToString(object obj)
        {
            if (obj == null)
                return null;

            MemoryStream stream = new MemoryStream();
            XmlSerializer xml = new XmlSerializer(obj.GetType());

            xml.Serialize(stream, obj);
            stream.Position = 0;
            StreamReader sr = new StreamReader(stream);
            string str = sr.ReadToEnd();

            sr.Dispose();
            stream.Dispose();

            return str;
        }

        public static object LoadFromString(string xml, Type type)
        {
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer xmldes = new XmlSerializer(type);
                return xmldes.Deserialize(sr);
            }
        }

        public static void SaveToFile(string filePath, object obj)
        {
            if (!string.IsNullOrWhiteSpace(filePath) && obj != null)
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
                    xmlSerializer.Serialize(writer, obj);
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
