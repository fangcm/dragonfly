using System;
using System.Configuration;

namespace Dragonfly.Common.Utils
{
    public class AppConfig
    {
        private static Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public static bool GetBoolean(string key)
        {
            return Convert.ToBoolean(GetString(key));
        }

        public static string GetString(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static void UpdateSetting(string key, string value)
        {
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);

            ConfigurationManager.RefreshSection("appSettings");
        }

    }

}