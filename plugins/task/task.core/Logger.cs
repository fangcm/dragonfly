﻿using System;
using System.IO;
using System.Text;

namespace Dragonfly.Task.Core
{
    public static class Logger
    {
        public static void info(string loggerName, params object[] values)
        {
            log("INFO {0} - {1}", loggerName, string.Join(" ", values));
        }

        public static void error(string loggerName, params object[] values)
        {
            log("ERROR {0} - {1}", loggerName, string.Join(" ", values));
        }

        public static void debug(string loggerName, params object[] values)
        {
            log("DEBUG {0} - {1}", loggerName, string.Join(" ", values));
        }

        public static bool isDebugEnabled()
        {
            return true;
        }

        public static void log(string format, params object[] values)
        {
            log(string.Format(format, values));
        }

        public static void log(string line)
        {
            string fileName = Path.Combine(Logger.LogsPath, DateTime.Now.ToString("yyyyMMdd") + ".notify.log");
            WriteLog(fileName, line);
        }

        public static void WriteLog(string filename, string line)
        {
            WriteLine(filename, string.Format("{0} {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), line));
        }

        private static readonly object _lockObject = new object();
        private static string _workingPath = string.Empty;

        public static string LogsPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_workingPath))
                {
                    string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    _workingPath = Path.Combine(appDataPath, "dragonfly", "logs");
                }
                return _workingPath;
            }
        }

        public static void WriteLine(string filename, string line)
        {
            lock (_lockObject)
            {
                using (var fileStream = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                using (var streamWriter = new StreamWriter(fileStream, Encoding.UTF8))
                {
                    try
                    {
                        streamWriter.WriteLine(line);
                        streamWriter.Flush();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                }
            }
        }
    }

}

