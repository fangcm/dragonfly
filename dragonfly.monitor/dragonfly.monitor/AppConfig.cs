using System;
using System.IO;

namespace Dragonfly.Monitor
{
    public class AppConfig
    {
        private static string _workingPath = string.Empty;
        private static string _pluginsPath = string.Empty;
        private static string _logsPath = string.Empty;

        public static string WorkingPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_workingPath))
                {
                    string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    _workingPath = Path.Combine(appDataPath, "dragonfly");
                    if (!Directory.Exists(_workingPath))
                    {
                        try
                        {
                            Directory.CreateDirectory(_workingPath);
                        }
                        catch
                        {
                            _workingPath = appDataPath;
                        }
                    }
                }
                return _workingPath;

            }
        }

        public static string PluginsPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_pluginsPath))
                {
                    _pluginsPath = Path.Combine(WorkingPath, "plugins");
                }
                return _pluginsPath;
            }
        }

        public static string LogsPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_logsPath))
                {
                    _logsPath = Path.Combine(WorkingPath, "logs");
                    if (!Directory.Exists(_logsPath))
                    {
                        try
                        {
                            Directory.CreateDirectory(_logsPath);
                        }
                        catch
                        {
                            _logsPath = WorkingPath;
                        }
                    }
                }
                return _logsPath;
            }
        }


    }

}