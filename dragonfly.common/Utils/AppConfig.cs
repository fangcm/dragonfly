using System;
using System.Configuration;
using System.IO;

namespace Dragonfly.Common.Utils
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

        private static string ReadAppSetting(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch
            {
                return null;
            }
        }

        public static void SaveAppSetting(string key, string value)
        {
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings[key].Value = value;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
            }
            catch
            {
            }
        }

        public static string GetString(string key, string defaultValue)
        {
            string value = ReadAppSetting(key);
            if (value == null)
            {
                return defaultValue;
            }
            else
            {
                return value;
            }
        }

        public static bool GetBoolean(string key, bool defaultValue)
        {
            try
            {
                return Convert.ToBoolean(GetString(key, Convert.ToString(defaultValue)));
            }
            catch
            {
                return defaultValue;
            }
        }

        public static int GetInt(string key, int defaultValue)
        {
            try
            {
                return Convert.ToInt32(GetString(key, Convert.ToString(defaultValue)));
            }
            catch
            {
                return defaultValue;
            }

        }

    }

}