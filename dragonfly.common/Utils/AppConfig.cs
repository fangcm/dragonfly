using System;
using System.Configuration;
using System.IO;

namespace Dragonfly.Common.Utils
{
    public class AppConfig
    {
        public static string WorkingPath
        {
            get
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string path = Path.Combine(appDataPath, "dragonfly");
                if (!Directory.Exists(path))
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                    }
                    catch
                    {
                        return appDataPath;
                    }
                }            
                return path;
            }
        }

        public static string ReadAppSetting(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch (ConfigurationErrorsException)
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
            catch (ConfigurationErrorsException)
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
            catch (Exception)
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
            catch (Exception)
            {
                return defaultValue;
            }
           
        }

    }

}