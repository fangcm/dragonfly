using System;
using System.IO;

namespace Dragonfly.Common.Utils
{
    public static class Logger
    {
        public static void info(string loggerName, string info)
        {
            log("INFO {0} - {1}", info);
        }

        public static void error(string loggerName, string error)
        {
            log("ERROR {0} - {1}", error);
        }

        public static void log(string format, params object[] list)
        {
            log(string.Format(format, list));
        }

        public static void log(string line)
        {
            string fileName = Path.Combine(AppConfig.LogsPath, DateTime.Now.ToString("yyyyMMdd") + ".trace.log");
            WriteLog(fileName, line);
        }

        public static void WriteLog(string filename, string line)
        {
            WriteLine(filename, string.Format("{0} {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), line));
        }

        public static bool WriteLine(string filename, string line)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(filename, true);
                sw.WriteLine(line);
                sw.Flush();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (sw != null)
                {
                    try
                    {
                        sw.Close();
                    }
                    catch
                    {
                    }
                }
            }
        }

    }
}
