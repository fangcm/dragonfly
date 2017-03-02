using System;
using System.IO;
using System.Text;
using System.Xml;
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

        public static string SaveExaminationToString(Examination exam, bool ignoreXmlDecl)
        {
            return SaveToString(exam, ignoreXmlDecl);
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

        public static string SaveToString(object obj, bool ignoreXmlDecl)
        {
            if (obj == null)
                return null;

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "    ",
                OmitXmlDeclaration = ignoreXmlDecl ? true : false,
                Encoding = new UTF8Encoding(false),
            };

            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());

            using (MemoryStream stream = new MemoryStream())
            using (XmlWriter writer = XmlWriter.Create(stream, settings))
            {
                xmlSerializer.Serialize(writer, obj, ns);
                return Encoding.UTF8.GetString(stream.ToArray());
            }

        }

        public static object LoadFromString(string xmlString, Type type)
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                return xmlSerializer.Deserialize(stream);
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
