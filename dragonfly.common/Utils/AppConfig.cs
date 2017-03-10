using System;
using System.Configuration;
using System.IO;

namespace Dragonfly.Common.Utils
{
    public class AppConfig
    {
        private static string _workingPath = string.Empty;

        public static string WorkingPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_workingPath))
                {
                    string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    string path = Path.Combine(appDataPath, "dragonfly");
                    if (Directory.Exists(path))
                    {
                        _workingPath = path;
                    }
                    else
                    {
                        try
                        {
                            Directory.CreateDirectory(path);
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
                return Path.Combine(WorkingPath, "plugins");
            }
        }

        public static string LogsPath
        {
            get
            {
                return Path.Combine(WorkingPath, "logs");
            }
        }

        public static string ReadAppSetting(string key)
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

        public static void UpdateAppSetting(string key, string value)
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