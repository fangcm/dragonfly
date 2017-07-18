using System;
using System.IO;
using System.Xml.Serialization;

namespace Dragonfly.Updater
{
    internal sealed class CopyContentCommand : ICommand
    {
        internal static string WorkingPath
        {
            get
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                return Path.Combine(appDataPath, "dragonfly");
            }
        }

        public void Execute()
        {
            string updatePath = Path.Combine(WorkingPath, "update");
            string updateConfig = Path.Combine(updatePath, "config.xml");

            if (!File.Exists(updateConfig))
            {
                return;
            }

            string pluginPath = Path.Combine(WorkingPath, "plugins");
            UpdateConfig config = LoadConfig(updateConfig);
            if (config == null)
                return;

            ExecuteCommand(config, updatePath, "before");
            ExecuteCopy(config, updatePath, pluginPath);
            ExecuteDelete(config, pluginPath);
            ExecuteCommand(config, updatePath, "after");

            File.Delete(updateConfig);

        }

        public void ExecuteCopy(UpdateConfig config, string updatePath, string dstPath)
        {
            foreach (FileInfo fileInfo in config.CopyFiles)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(fileInfo.PublishPath))
                    {
                        dstPath = Path.Combine(dstPath, fileInfo.PublishPath);
                        if (!Directory.Exists(dstPath))
                        {
                            Directory.CreateDirectory(dstPath);
                        }
                    }

                    var srcFile = Path.Combine(updatePath, fileInfo.FileName);
                    var newFile = Path.Combine(dstPath, fileInfo.FileName);

                    File.Copy(srcFile, newFile, true);
                    File.Delete(srcFile);
                }
                catch
                {
                }
            }
        }
        public void ExecuteDelete(UpdateConfig config, string dstPath)
        {
            foreach (FileInfo fileInfo in config.DeleteFiles)
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(fileInfo.PublishPath))
                    {
                        dstPath = Path.Combine(dstPath, fileInfo.PublishPath);
                    }

                    var dstFile = Path.Combine(dstPath, fileInfo.FileName);
                    File.SetAttributes(dstFile, FileAttributes.Normal);
                    File.Delete(dstFile);
                }
                catch
                {
                }
            }

        }
        public void ExecuteCommand(UpdateConfig config, string dstPath, string type)
        {
            foreach (CommandInfo commandInfo in config.Commands)
            {
                try
                {
                    if (!type.Equals(commandInfo.Type, StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    if (string.IsNullOrWhiteSpace(commandInfo.FileName))
                    {
                        if (!string.IsNullOrWhiteSpace(commandInfo.Param))
                        {
                            string info;
                            RestartUtil.RunCmd(commandInfo.Param, out info);
                            Console.WriteLine(info);
                        }
                        continue;
                    }

                    if ("Hibernate".Equals(commandInfo.FileName))
                    {
                        RestartUtil.ExitWindows(RestartOptions.Hibernate, true);
                    }
                    else if ("ShutDown".Equals(commandInfo.FileName))
                    {
                        RestartUtil.ExitWindows(RestartOptions.ShutDown, true);
                    }
                    else if ("Reboot".Equals(commandInfo.FileName))
                    {
                        RestartUtil.ExitWindows(RestartOptions.Reboot, true);
                    }
                    else
                    {
                        if (!string.IsNullOrWhiteSpace(commandInfo.Startpath))
                        {
                            dstPath = Path.Combine(dstPath, commandInfo.Startpath);
                        }

                        RestartUtil.ExecApp(commandInfo.FileName, commandInfo.Param, dstPath);
                    }
                }
                catch
                {
                }
            }

        }

        private static UpdateConfig LoadConfig(string file)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(UpdateConfig));
                using (StreamReader sr = new StreamReader(file))
                {
                    UpdateConfig config = xs.Deserialize(sr) as UpdateConfig;
                    return config;
                }
            }
            catch
            {
                return null;
            }
        }


    }
}
