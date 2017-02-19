using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Dragonfly.Questions
{
    [XmlRootAttribute("Examination")]
    public class Examination
    {
        [XmlElementAttribute("Properties", IsNullable = false)]
        public Properties Properties { get; set; }

        [XmlArrayAttribute("Readings")]
        public List<Reading> Readings { get; set; }

        public Examination()
        {
            Readings = new List<Reading>();
            Properties = new Properties();
        }

        public void AddReading(string readingTitle)
        {
            Reading reading = Readings.FirstOrDefault(s => s.Title == readingTitle);
            if (reading == null)
            {
                reading = new Reading();
                reading.Title = readingTitle;
                Readings.Add(reading);
            }
        }

        public void RemoveReading(string readingTitle)
        {
            Reading reading = Readings.FirstOrDefault(s => s.Title == readingTitle);
            if (reading != null)
                Readings.Remove(reading);
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

    [XmlRootAttribute("Properties")]
    public class Properties
    {
        [XmlElementAttribute("Title", IsNullable = false)]
        public string Title { get; set; }

        [XmlAttribute("Passmark")]
        public double Passmark { get; set; }
    }

    [XmlRootAttribute("Reading")]
    public class Reading
    {
        [XmlElementAttribute("Title", IsNullable = false)]
        public string Title { get; set; }

        [XmlElementAttribute("Text", IsNullable = false)]
        public string Text { get; set; }

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
