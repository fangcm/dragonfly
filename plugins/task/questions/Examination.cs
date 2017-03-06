using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace Dragonfly.Questions.Core
{
    [XmlRootAttribute("Examination", Namespace = "", IsNullable = false)]
    public class Examination
    {
        [XmlElementAttribute("ExamProperties", IsNullable = false)]
        public ExamProperties ExamProperties { get; set; }

        [XmlArrayAttribute("Readings")]
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

    [XmlRootAttribute("ExamProperties")]
    public class ExamProperties
    {
        [XmlElementAttribute("Title", IsNullable = false)]
        public string Title { get; set; }

        [XmlAttribute("Score")]
        public int Score { get; set; }

        [XmlAttribute("PassScore")]
        public int PassScore { get; set; }
    }

    [XmlRootAttribute("Reading", Namespace = "")]
    public class Reading
    {
        [XmlElementAttribute("Title", IsNullable = false)]
        public string Title { get; set; }

        [XmlIgnore]
        public string Text { get; set; }

        [XmlElementAttribute("Text", IsNullable = false, Type = typeof(XmlCDataSection))]
        public XmlCDataSection TextCData
        {
            get
            {
                return new System.Xml.XmlDocument().CreateCDataSection(Text);
            }
            set
            {
                Text = value.Value;
            }
        }


        [XmlArrayAttribute("Questions")]
        public List<Question> Questions { get; set; }

        public Reading()
        {
            Questions = new List<Question>();
        }

    }

    [XmlRootAttribute("Question")]
    public class Question
    {
        [XmlAttribute("No")]
        public int No { get; set; }

        [XmlElementAttribute("Text", IsNullable = false)]
        public string Text { get; set; }

        [XmlAttribute("Answer")]
        public char Answer { get; set; }

        [XmlAttribute("IsMultipleChoice")]
        public bool IsMultipleChoice { get; set; }

        [XmlArrayAttribute("Answers")]
        public char[] Answers { get; set; }

        [XmlArrayAttribute("Options")]
        public List<Option> Options { get; set; }

        [XmlElementAttribute("Explanation")]
        public string Explanation { get; set; }

        public Question()
        {
            Options = new List<Option>();
        }
    }

    [XmlRootAttribute("Option")]
    public class Option
    {
        [XmlAttribute("Alphabet")]
        public char Alphabet { get; set; }

        [XmlElementAttribute("Text", IsNullable = false)]
        public string Text { get; set; }
    }

}
