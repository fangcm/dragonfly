using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Dragonfly.Questions
{
    class Helper
    {
        public static void SaveExaminationToFile(string filePath, Examination exam)
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

        public static Examination LoadExaminationFromFile(string filePath)
        {
            Examination result = null;

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath, Encoding.UTF8))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Examination));
                    result = (Examination)xmlSerializer.Deserialize(reader);
                }
            }

            return result;
        }
    }
}
