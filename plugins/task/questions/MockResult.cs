﻿using System.Collections.Generic;
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
            if(result == null)
            {
                practice.ReadingResults.Add(readingResult);
            }else
            {
                result.NumberOfQuestions = readingResult.NumberOfQuestions;
                result.NumberOfCorrectAnswers = readingResult.NumberOfCorrectAnswers;
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

    [XmlRootAttribute("ResultProperties")]
    public class ResultProperties
    {
        [XmlElementAttribute("LastFileName")]
        public string LastFileName { get; set; }

        [XmlAttribute("LasReadingIndex")]
        public int LasReadingIndex { get; set; }

        [XmlAttribute("LastFileFinishedAll")]
        public bool LastFileFinishedAll { get; set; }
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

        [XmlAttribute("Score")]
        public int Score { get; set; }
        

    }


}
