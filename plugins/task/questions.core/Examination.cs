using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Dragonfly.Questions.Core
{
    [XmlRoot("Examination", Namespace = "", IsNullable = false)]
    public class Examination
    {
        [XmlElement("ExamProperties", IsNullable = false)]
        public ExamProperties ExamProperties { get; set; }

        [XmlArray("Readings")]
        public List<Reading> Readings { get; set; }

        public Examination()
        {
            Readings = new List<Reading>();
            ExamProperties = new ExamProperties();
        }

        public Reading SaveReading(string readingTitle)
        {
            Reading reading = Readings.FirstOrDefault(s => s.Title == readingTitle);
            if (reading == null)
            {
                reading = new Reading();
                reading.Title = readingTitle;
                Readings.Add(reading);
            }
            return reading;
        }

        public void RemoveReading(string readingTitle)
        {
            Reading reading = Readings.FirstOrDefault(s => s.Title == readingTitle);
            if (reading != null)
            {
                Readings.Remove(reading);
            }
        }

        public void AddQuestion(string readingTitle, Question question)
        {
            Reading reading = Readings.FirstOrDefault(s => s.Title == readingTitle);
            if (reading == null)
            {
                reading = new Reading();
                reading.Title = readingTitle;
                Readings.Add(reading);
            }

            reading.Questions.Add(question);
        }

        public void RemoveQuestion(string readingTitle, Question question)
        {
            Reading reading = Readings.FirstOrDefault(s => s.Title == readingTitle);
            if (reading != null)
            {
                reading.Questions.Remove(question);
            }
        }
    }

    [XmlRoot("ExamProperties")]
    public class ExamProperties
    {
        [XmlElement("Title", IsNullable = false)]
        public string Title { get; set; }

        [XmlAttribute("Score")]
        public int Score { get; set; }

        [XmlAttribute("PassScore")]
        public int PassScore { get; set; }
    }

    [XmlRoot("Reading", Namespace = "")]
    public class Reading
    {
        [XmlElement("Title", IsNullable = false)]
        public string Title { get; set; }

        [XmlIgnore]
        public string Text { get; set; }

        [XmlElement("Text", IsNullable = false, Type = typeof(XmlCDataSection))]
        public XmlCDataSection TextCData
        {
            get
            {
                return new XmlDocument().CreateCDataSection(Text);
            }
            set
            {
                Text = value.Value;
            }
        }


        [XmlArray("Questions")]
        public List<Question> Questions { get; set; }

        public Reading()
        {
            Questions = new List<Question>();
        }

    }

    [XmlRoot("Question")]
    public class Question
    {
        [XmlAttribute("No")]
        public int No { get; set; }

        [XmlIgnore]
        public string Text { get; set; }

        [XmlElement("Text", IsNullable = false, Type = typeof(XmlCDataSection))]
        public XmlCDataSection TextCData
        {
            get
            {
                return new XmlDocument().CreateCDataSection(Text);
            }
            set
            {
                Text = value.Value;
            }
        }

        [XmlAttribute("Answer")]
        public char Answer { get; set; }

        [XmlAttribute("IsMultipleChoice")]
        public bool IsMultipleChoice { get; set; }

        [XmlArray("Answers")]
        public char[] Answers { get; set; }

        [XmlArray("Options")]
        public List<Option> Options { get; set; }

        public Question()
        {
            Options = new List<Option>();
        }
    }

    [XmlRoot("Option")]
    public class Option
    {
        [XmlAttribute("Alphabet")]
        public char Alphabet { get; set; }

        [XmlIgnore]
        public string Text { get; set; }

        [XmlElement("Text", IsNullable = false, Type = typeof(XmlCDataSection))]
        public XmlCDataSection TextCData
        {
            get
            {
                return new XmlDocument().CreateCDataSection(Text);
            }
            set
            {
                Text = value.Value;
            }
        }
    }

}
