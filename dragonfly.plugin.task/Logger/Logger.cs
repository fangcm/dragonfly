﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dragonfly.Plugin.Task.Logger
{
    public static class Logger
    {
        public static string OutputLogPath = AppDomain.CurrentDomain.BaseDirectory;

        public const string OUTPUT_DIRECTORY_DEBUG = "Debug";
        public const string OUTPUT_DIRECTORY_ERROR = "Error";
        public const string OUTPUT_DIRECTORY_NOTIFICATION = "Notification";
        public const string OUTPUT_DIRECTORY_WARNING = "Warning";

        public static string AppicationName { get; set; }

        static LogQueue logQueue = new LogQueue();

        #region "Public"

        /// <summary>
        /// Add line to Log
        /// </summary>
        /// <param name="text"></param>
        /// <param name="file"></param>
        /// <param name="member"></param>
        /// <param name="lineNumber"></param>
        public static void Log(string text, LogLineType type = LogLineType.Notification, [CallerFilePath] string filename = "", [CallerMemberName] string member = "", [CallerLineNumber] int lineNumber = 0)
        {
            string[] lines = text.Split(new string[] { "\r\n", "\n", Environment.NewLine }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                var queueLine = new Line();
                queueLine.Text = line;
                queueLine.Type = type;
                queueLine.Timestamp = DateTime.Now;

                var assembly = Assembly.GetCallingAssembly();

                queueLine.Assembly = assembly.FullName;
                queueLine.Filename = filename;
                queueLine.Member = member;
                queueLine.LineNumber = lineNumber;

                logQueue.AddLineToQueue(queueLine);
                Console.WriteLine(line);
            }
        }

        public static string ReadOutputLogText(string applicationName, DateTime timestamp)
        {
            string result = null;

            result += ReadOutputLogText(LogLineType.Debug, applicationName, timestamp);
            result += ReadOutputLogText(LogLineType.Error, applicationName, timestamp);
            result += ReadOutputLogText(LogLineType.Notification, applicationName, timestamp);
            result += ReadOutputLogText(LogLineType.Warning, applicationName, timestamp);

            return result;
        }

        private static string ReadOutputLogText(LogLineType type, string applicationName, DateTime timestamp)
        {
            string result = null;

            XmlNode[] nodes = ReadOutputLogXml(type, applicationName, timestamp);
            if (nodes != null)
            {
                result = "";

                foreach (XmlNode lineNode in nodes)
                {
                    string t = XML.Attributes.Get(lineNode, "timestamp");
                    if (t != null)
                    {
                        DateTime date = DateTime.MinValue;
                        if (DateTime.TryParse(t, out date))
                        {
                            if (date > timestamp)
                            {
                                result += lineNode.InnerText + Environment.NewLine;
                            }
                        }
                    }
                }
            }

            return result;
        }

        public static XmlNode[] ReadOutputLogXml(LogLineType type, string applicationName, DateTime timestamp)
        {
            XmlNode[] result = null;

            string path = "Log-" + FormatDate(DateTime.Now) + ".xml";

            switch (type)
            {
                case LogLineType.Debug: path = Path.Combine(OutputLogPath, OUTPUT_DIRECTORY_DEBUG, path); break;
                case LogLineType.Error: path = Path.Combine(OutputLogPath, OUTPUT_DIRECTORY_ERROR, path); break;
                case LogLineType.Notification: path = Path.Combine(OutputLogPath, OUTPUT_DIRECTORY_NOTIFICATION, path); break;
                case LogLineType.Warning: path = Path.Combine(OutputLogPath, OUTPUT_DIRECTORY_WARNING, path); break;
            }

            var doc = XML.Files.ReadDocument(path);
            if (doc != null)
            {
                if (doc.DocumentElement != null)
                {
                    var node = doc.DocumentElement.SelectSingleNode("//" + applicationName);
                    if (node != null)
                    {
                        var nodes = new List<XmlNode>();

                        foreach (XmlNode lineNode in node.ChildNodes)
                        {
                            string t = XML.Attributes.Get(lineNode, "timestamp");
                            if (t != null)
                            {
                                DateTime date = DateTime.MinValue;
                                if (DateTime.TryParse(t, out date))
                                {
                                    if (date > timestamp)
                                    {
                                        nodes.Add(lineNode);
                                    }
                                }
                            }
                        }

                        result = nodes.ToArray();
                    }
                }
            }

            return result;
        }

        #endregion

        internal static string FormatDate(DateTime date)
        {
            return date.Year.ToString() + "-" + date.Month.ToString() + "-" + date.Day.ToString();
        }

    }
}
