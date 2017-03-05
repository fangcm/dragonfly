using System;
using System.IO;
using System.Text;
using System.Xml;

namespace Dragonfly.Plugin.Task.Logger
{
    internal class XmlLogger : Logger
    {
        public static bool Indent = true;

        internal XmlLogger() { }


        public override void Log(LoggInfo loggInfo)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.ConformanceLevel = ConformanceLevel.Auto;
            settings.Encoding = Encoding.UTF8;
            settings.Indent = Indent;
            string filePath = GetLogFilePathName();
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


        protected override System.Collections.ObjectModel.ObservableCollection<LoggInfo> GetLogg()
        {
            System.Collections.ObjectModel.ObservableCollection<LoggInfo> loggInfos = new System.Collections.ObjectModel.ObservableCollection<LoggInfo>();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            settings.IgnoreWhitespace = true;
            settings.IgnoreProcessingInstructions = true;

            string filePath = GetLogFilePathName();
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
                    LoggType loggType;
                    if (!Enum.TryParse<LoggType>(logNode.Attributes["type"].InnerText, out loggType))
                        continue;
                    loggInfo.Type = loggType;
                    if (logNode["text"] != null)
                        loggInfo.Text = logNode["text"].InnerText;

                    loggInfos.Add(loggInfo);
                }
            }


            return loggInfos;
        }

    }
}