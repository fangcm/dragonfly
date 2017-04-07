using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Dragonfly.Questions.Core
{
    [XmlRoot("MockResult")]
    public class MockResult
    {
        [XmlArray("Practices")]
        public List<Practice> Practices { get; set; }

        public MockResult()
        {
            Practices = new List<Practice>();
        }

        public Practice SavePractice(string fileName)
        {
            Practice practice = Practices.FirstOrDefault(s => s.FileName == fileName);
            if (practice == null)
            {
                practice = new Practice();
                practice.FileName = fileName;
                Practices.Add(practice);
            }
            return practice;
        }

        public void RemovePractice(string fileName)
        {
            Practice practice = Practices.FirstOrDefault(s => s.FileName == fileName);
            if (practice != null)
            {
                Practices.Remove(practice);
            }
        }

        public void SaveReadingResults(string fileName, ReadingResult readingResult)
        {
            Practice practice = SavePractice(fileName);
            ReadingResult result = practice.ReadingResults.FirstOrDefault(s => s.Title == readingResult.Title);
            if (result == null)
            {
                practice.ReadingResults.Add(readingResult);
            }
            else
            {
                result.NumberOfQuestions = readingResult.NumberOfQuestions;
                result.NumberOfCorrectAnswers = readingResult.NumberOfCorrectAnswers;
                result.Score = readingResult.Score;
                result.EndTime = readingResult.EndTime;
                result.SpendTime = readingResult.SpendTime;
            }
        }

        public void RemoveReadingResult(string fileName, string title)
        {
            Practice practice = Practices.FirstOrDefault(s => s.FileName == fileName);
            if (practice != null)
            {
                ReadingResult result = practice.ReadingResults.FirstOrDefault(s => s.Title == title);
                if (result != null)
                {
                    practice.ReadingResults.Remove(result);
                }
            }
        }
    }

    [XmlRoot("Practice")]
    public class Practice
    {
        [XmlElement("FileName", IsNullable = false)]
        public string FileName { get; set; }

        [XmlArray("ReadingResults")]
        public List<ReadingResult> ReadingResults { get; set; }

        public Practice()
        {
            ReadingResults = new List<ReadingResult>();
        }

    }

    [XmlRoot("ReadingResult")]
    public class ReadingResult
    {
        [XmlElement("Title", IsNullable = false)]
        public string Title { get; set; }

        [XmlAttribute("NumberOfQuestions")]
        public int NumberOfQuestions { get; set; }

        [XmlAttribute("NumberOfCorrectAnswers")]
        public int NumberOfCorrectAnswers { get; set; }

        [XmlAttribute("Score")]
        public int Score { get; set; }

        [XmlAttribute("EndTime")]
        public DateTime EndTime { get; set; }

        [XmlAttribute("SpendTime")]
        public int SpendTime { get; set; }
    }


}
