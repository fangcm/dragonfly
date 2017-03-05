using System;

namespace Dragonfly.Plugin.Task.Logger
{
    internal enum LoggType
    {
        Trigger,
        Suspend,
        Resume,
        Other
    }

    internal class LoggInfo
    {
        public LoggInfo()
        {
            this.Date = DateTime.Now;
        }
        public LoggInfo(string Text, LoggType Type)
        {
            this.Text = Text;
            this.Type = Type;
            this.Date = DateTime.Now;
        }

        public LoggInfo(DateTime date, string text, LoggType Type)
            : this(text, Type)
        {
            this.Date = date;
        }

        public string Text { get; set; }
        public LoggType Type { get; set; }
        public DateTime Date { get; set; }

    }

}