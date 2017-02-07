using System;
using System.IO;

namespace Dragonfly.Common.Utils
{
    public class Logger
    {
        protected static string strLogFilePath = string.Empty;
        private static StreamWriter sw = null;

        public static string LogFilePath
        {
            set
            {
                strLogFilePath = value;
            }
            get
            {
                return strLogFilePath;
            }
        }

        public static bool log(string message)
        {
            return log(message, string.Empty);
        }

        public static bool log(string message, string title)
        {
            try
            {
                if (true != writeLog(message, title))
                    return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool writeLog(string message, string title)
        {
            string strPathName = string.Empty;
            if (string.IsNullOrEmpty(strLogFilePath))
            {
                //Get Default log file path "LogFile.txt"
                strPathName = GetLogFilePath();
            }
            else
            {

                //If the log file path is not empty but the file is not available it will create it
                if (false == File.Exists(strLogFilePath))
                {
                    if (false == CheckDirectory(strLogFilePath))
                        return false;

                    FileStream fs = new FileStream(strLogFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fs.Close();
                }
                strPathName = strLogFilePath;

            }

            bool bReturn = true;
            // write the error log to that text file
            if (true != writeLog(strPathName, message, title))
            {
                bReturn = false;
            }
            return bReturn;
        }

        private static bool writeLog(string strPathName, string message, string title)
        {
            bool bReturn = false;
            string strException = string.Empty;
            try
            {
                sw = new StreamWriter(strPathName, true);
                if (!string.IsNullOrEmpty(title))
                {
                    sw.WriteLine("\r\n" + title);
                }
                sw.Write(message);
                sw.Flush();
                sw.Close();
                bReturn = true;
            }
            catch
            {
                bReturn = false;
            }
            return bReturn;
        }
        /// <summary>
        /// Check the log file in applcation directory. If it is not available, creae it
        /// </summary>
        /// <returns>Log file path</returns>
        private static string GetLogFilePath()
        {
            try
            {
                // get the base directory
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string retFilePath = baseDir + "LogFile.txt";

                // if exists, return the path
                if (File.Exists(retFilePath) == true)
                    return retFilePath;
                //create a text file
                else
                {
                    if (false == CheckDirectory(retFilePath))
                        return string.Empty;

                    FileStream fs = new FileStream(retFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    fs.Close();
                }

                return retFilePath;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// Create a directory if not exists
        /// </summary>
        /// <param name="strLogPath"></param>
        /// <returns></returns>
        public static bool CheckDirectory(string strLogPath)
        {
            try
            {
                int nFindSlashPos = strLogPath.Trim().LastIndexOf("\\");
                string strDirectoryname = strLogPath.Trim().Substring(0, nFindSlashPos);

                if (false == Directory.Exists(strDirectoryname))
                    Directory.CreateDirectory(strDirectoryname);

                return true;
            }
            catch (Exception)
            {
                return false;

            }

    
        }
    }
}
