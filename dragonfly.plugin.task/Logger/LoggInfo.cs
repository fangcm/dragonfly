using System;
using System.Xml;

namespace Dragonfly.Plugin.Task.Logger
{
    public enum LoggType
    {
        LockScreen,
        Command,
        SystemShutdown,
        Logoff,
        Suspend,
        Resume,
        Other
    }

    public class LoggInfo
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