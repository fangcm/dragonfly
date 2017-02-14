using System;
using System.Configuration;
using System.Windows.Forms;

namespace Dragonfly.Common.Utils
{
    public class AppConfig
    {
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

        public static string GetString(string key)
        {
            return ReadAppSetting(key);
        }

        public static bool GetBoolean(string key)
        {
            return Convert.ToBoolean(ReadAppSetting(key));
        }

    }

}