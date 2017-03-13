using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml;

namespace Dragonfly.Common.Utils
{
    public class ReadableLogger
    {
        protected static ReadableLogger _instance;
        private ObservableCollection<LoggInfo> loggInfos;

        public static ReadableLogger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ReadableLogger();
                }
                return _instance;
            }
        }

        public static ObservableCollection<LoggInfo> LoggInfos
        {
            get
            {
                if (Instance.loggInfos == null)
                    Instance.loggInfos = Instance.GetLogg();
                return Instance.loggInfos;
            }
        }

        private ReadableLogger() { }

        public void Log(string type, string text, params object[] arg)
        {
            LoggInfo loggInfo = new LoggInfo(string.Format(text, arg), type);
            Log(loggInfo);
        }

        public void Log(LoggInfo loggInfo)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.ConformanceLevel = ConformanceLevel.Auto;
            settings.Encoding = Encoding.UTF8;
            settings.Indent = true;

            string filePath = Path.Combine(AppConfig.LogsPath, DateTime.Now.ToString("yyyyMMdd") + ".log");
            bool exists = File.Exists(filePath);
            AddToObservable(loggInfo);
            XmlDocument document = new XmlDocument();
            if (exists)
            {
                try
                {
                    document.Load(filePath);
                }
                catch
                {
                    XmlNode rootNode = document.CreateElement("logs");
                    document.AppendChild(rootNode);
                }
            }
            else
            {
                XmlNode rootNode = document.CreateElement("logs");
                document.AppendChild(rootNode);
            }

            XmlNode logNode = document.CreateElement("log");
            XmlAttribute dateAttr = document.CreateAttribute("date");
            dateAttr.Value = loggInfo.Date.ToString();
            XmlAttribute typeAttr = document.CreateAttribute("type");
            typeAttr.Value = loggInfo.Type.ToString();
            logNode.Attributes.Append(dateAttr);
            logNode.Attributes.Append(typeAttr);

            if (!String.IsNullOrWhiteSpace(loggInfo.Text))
            {
                XmlNode textNode = document.CreateElement("text");
                textNode.InnerText = loggInfo.Text;
                logNode.AppendChild(textNode);
            }

            document.DocumentElement.AppendChild(logNode);

            using (XmlWriter writer = XmlWriter.Create(filePath, settings))
            {
                document.Save(writer);
            }

        }

        protected ObservableCollection<LoggInfo> GetLogg()
        {
            ObservableCollection<LoggInfo> loggInfos = new ObservableCollection<LoggInfo>();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            settings.IgnoreWhitespace = true;
            settings.IgnoreProcessingInstructions = true;

            string filePath = Path.Combine(AppConfig.LogsPath, DateTime.Now.ToString("yyyyMMdd") + ".log");
            bool exists = File.Exists(filePath);
            if (!exists)
            {
                return loggInfos;
            }
            using (XmlReader logReader = XmlReader.Create(filePath, settings))
            {
                XmlDocument document = new XmlDocument();
                try
                {
                    document.Load(logReader);
                }
                catch
                {
                    return loggInfos;
                }

                foreach (XmlNode logNode in document["logs"].ChildNodes)
                {
                    LoggInfo loggInfo = new LoggInfo();
                    loggInfo.Date = DateTime.Parse(logNode.Attributes["date"].InnerText);
                    loggInfo.Type = logNode.Attributes["type"].InnerText;
                    if (logNode["text"] != null)
                    {
                        loggInfo.Text = logNode["text"].InnerText;
                    }
                    loggInfos.Add(loggInfo);
                }
            }


            return loggInfos;
        }

        protected static void AddToObservable(LoggInfo loggInfo)
        {
            LoggInfos.Add(loggInfo);
        }

    }

    public class LoggInfo
    {
        public LoggInfo()
        {
            this.Date = DateTime.Now;
        }
        public LoggInfo(string Type, string Text)
        {
            this.Text = Text;
            this.Type = Type;
            this.Date = DateTime.Now;
        }

        public LoggInfo(DateTime date, string Type, string text)
            : this(Type, text)
        {
            this.Date = date;
        }

        public string Text { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }

    }

}