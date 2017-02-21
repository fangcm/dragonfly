using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Dragonfly.Questions
{
    [XmlRootAttribute("MockResult")]
    public class MockResult
    {
        [XmlElementAttribute("ResultProperties", IsNullable = false)]
        public ResultProperties ResultProperties { get; set; }

        [XmlArrayAttribute("Practices")]
        public List<Practice> Practices { get; set; }

        public MockResult()
        {
            Practices = new List<Practice>();
            ResultProperties = new ResultProperties();
        }

        public void AddPractice(string fileName)
        {
            Practice practice = Practices.FirstOrDefault(s => s.FileName == fileName);
            if (practice == null)
            {
                practice = new Practice();
                practice.FileName = fileName;
                Practices.Add(practice);
            }
        }

        public void RemovePractice(string fileName)
        {
            Practice practice = Practices.FirstOrDefault(s => s.FileName == fileName);
            if (practice != null)
                Practices.Remove(practice);
        }

        public void AddReadingResult(string fileName, ReadingResult readingResult)
        {
            Practice practice = Practices.FirstOrDefault(s => s.FileName == fileName);
            if (practice == null)
            {
                practice = new Practice();
                practice.FileName = fileName;
                Practices.Add(practice);
            }

            practice.ReadingResults.Add(readingResult);
        }

        public void RemoveReadingResult(string fileName, ReadingResult readingResult)
        {
            Practice practice = Practices.FirstOrDefault(s => s.FileName == fileName);
            if (practice != null)
            {
                practice.ReadingResults.Remove(readingResult);
            }
        }
    }

    [XmlRootAttribute("ResultProperties")]
    public class ResultProperties
    {
        [XmlElementAttribute("Title", IsNullable = false)]
        public XmlCDataSection Title { get; set; }

        [XmlAttribute("Passmark")]
        public double Passmark { get; set; }
    }

    [XmlRootAttribute("Practice")]
    public class Practice
    {
        [XmlElementAttribute("FileName", IsNullable = false)]
        public string FileName { get; set; }

        [XmlArrayAttribute("ReadingResults")]
        public List<ReadingResult> ReadingResults { get; set; }

        public Practice()
        {
            ReadingResults = new List<ReadingResult>();
        }

    }

    [XmlRootAttribute("ReadingResult")]
    public class ReadingResult
    {
        [XmlElementAttribute("Title", IsNullable = false)]
        public string Title { get; set; }

        [XmlAttribute("NumberOfQuestions")]
        public int NumberOfQuestions { get; set; }

        [XmlAttribute("NumberOfCorrectAnswers")]
        public int NumberOfCorrectAnswers { get; set; }

    }


}
