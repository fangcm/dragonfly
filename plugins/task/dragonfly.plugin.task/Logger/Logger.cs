using Dragonfly.Common.Utils;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Dragonfly.Plugin.Task.Logger
{
    internal abstract class Logger
    {
        private static string fileName;
        protected static Logger _default;
        private static ObservableCollection<LoggInfo> loggInfos;

        public static Logger Create()
        {
            _default = new XmlLogger();
            return _default;
        }

        public static Logger Default
        {
            get
            {
                if (_default == null)
                    Create();

                return _default;
            }
        }

        public static string GetLogFilePathName()
        {
            string path = AppConfig.WorkingPath;
            return Path.Combine(path, DateTime.Now.ToString("yyyyMMdd") + ".log.xml");
        }

        public static ObservableCollection<LoggInfo> LoggInfos
        {
            get
            {
                if (loggInfos == null)
                    loggInfos = Default.GetLogg();
                return loggInfos;
            }
        }

        public void Log(LoggType type, string text, params object[] arg)
        {
            LoggInfo loggInfo = new LoggInfo(string.Format(text, arg), type);
            Log(loggInfo);
        }

        public abstract void Log(LoggInfo loggInfo);

        protected abstract ObservableCollection<LoggInfo> GetLogg();

        protected static void AddToObservable(LoggInfo loggInfo)
        {
            LoggInfos.Add(loggInfo);
        }
    }
}

