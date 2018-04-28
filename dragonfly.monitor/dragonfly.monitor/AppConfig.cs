using Microsoft.Win32;
using System;
using System.IO;

namespace Dragonfly.Service
{
    public class AppConfig
    {
        private const string regKeyFolders = @"HKEY_USERS\<SID>\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders";
        private const string regValueAppData = @"AppData";

        private static string _workingPath = string.Empty;
        private static string _pluginsPath = string.Empty;
        private static string _logsPath = string.Empty;

        public static string WorkingPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_workingPath))
                {
                    System.Security.Principal.WindowsIdentity currentUser = System.Security.Principal.WindowsIdentity.GetCurrent();
                    string sid = currentUser.User.ToString();
                    string appDataPath = Registry.GetValue(regKeyFolders.Replace("<SID>", sid), regValueAppData, null) as string;
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