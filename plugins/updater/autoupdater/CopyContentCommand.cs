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

            try
            {

                if (!File.Exists(updateConfig))
                {
                    return;
                }

                string pluginPath = Path.Combine(WorkingPath, "plugins");
                UpdateConfig config = LoadConfig(updateConfig);
                if (config == null)
                    return;

                foreach (FileInfo fileInfo in config.CopyFiles)
                {
                    string dstPath = pluginPath;
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

                foreach (FileInfo fileInfo in config.DeleteFiles)
                {
                    string dstPath = pluginPath;
                    if (!string.IsNullOrWhiteSpace(fileInfo.PublishPath))
                    {
                        dstPath = Path.Combine(dstPath, fileInfo.PublishPath);
                    }

                    var dstFile = Path.Combine(dstPath, fileInfo.FileName);
                    File.SetAttributes(dstFile, FileAttributes.Normal);
                    File.Delete(dstFile);
                }


            }
            catch
            {

            }
            finally
            {
                File.Delete(updateConfig);
            }
        }

        private static UpdateConfig LoadConfig(string file)
        {
            XmlSerializer xs = new XmlSerializer(typeof(UpdateConfig));
            using (StreamReader sr = new StreamReader(file))
            {
                UpdateConfig config = xs.Deserialize(sr) as UpdateConfig;
                return config;
            }
        }

    }
}
