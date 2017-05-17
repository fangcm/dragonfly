using Dragonfly.Common.Plugin;
using Dragonfly.Common.Utils;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Windows.Forms;

namespace Dragonfly.Plugin.Updater
{
    public class UpdaterPlugin : IPlugin
    {
        private readonly string downloadPrefix = @"https://github.com/fangcm/dragonfly/raw/master/Setup/deploy/";
        private static object LockObject = new Object();
        private static int CheckUpDateLock = 0;
        private BackgroundWorker bgWorker;
        private System.Timers.Timer timer;

        public string Name { get { return "DragonflyUpdater"; } }
        public string Caption { get { return "升级器"; } }
        public string Version { get { return "1.0.0"; } }

        public UserControl PluginPanel { get { return null; } }

        public void Initialize()
        {
            this.bgWorker = new BackgroundWorker();
            this.bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);

            timer = new System.Timers.Timer(300000);
#if DEBUG
            timer.Interval = 3000;
#endif
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void Dispose()
        {
            timer.Enabled = false;
            this.bgWorker.Dispose();
        }

        private void Timer_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            lock (LockObject)
            {
                if (CheckUpDateLock == 0) CheckUpDateLock = 1;
                else return;
            }

            Start();
            // 解锁更新检查锁
            lock (LockObject)
            {
                CheckUpDateLock = 0;
            }
        }

        private void Start()
        {
            if (!this.bgWorker.IsBusy)
            {
                this.bgWorker.RunWorkerAsync();
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            processDeployUpdate();
            processAutoUpdate();
        }

        private void processAutoUpdate()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string updateConfig = Path.Combine(appDataPath, "dragonfly", "update", "config.xml");
            if (!File.Exists(updateConfig))
            {
                return;
            }
            Logger.info("UpdaterPlugin", "Found update config file.");

            string pluginPath = Path.Combine(appDataPath, "dragonfly", "plugins");

            Process.Start(
                Path.Combine(pluginPath, "autoupdater.exe"),
                string.Format("{0} \"{1}\"", Process.GetCurrentProcess().Id, Process.GetCurrentProcess().MainModule.FileName));

        }

        private void processDeployUpdate()
        {
            string deployDesc = Downloader.DownloadToString(downloadPrefix + "deploy.xml");
            Logger.info("deployDesc", deployDesc);
            DeployConfig deployConfig = XmlHelper.LoadFromString(deployDesc, typeof(DeployConfig)) as DeployConfig;
            if (deployConfig == null)
            {
                return;
            }

            DateTime lastDeployTime = DateTime.MinValue;
            DeployConfig savedConfig = XmlHelper.LoadFromFile(deployDesc, typeof(DeployConfig)) as DeployConfig;
            if (savedConfig != null)
            {
                lastDeployTime = savedConfig.LastDeployTime;
            }

            if (lastDeployTime.CompareTo(deployConfig.LastDeployTime) >= 0)
            {
                return;
            }

            string localFile = Path.Combine(AppConfig.WorkingPath, "update", deployConfig.LastDeployFileName);
            if (Downloader.DownloadFileToLocal(downloadPrefix + deployConfig.LastDeployFileName, localFile))
            {
                ExtractToDirectory(localFile, Path.Combine(AppConfig.WorkingPath, "update"));
            }

        }

        private void ExtractToDirectory(string zipFile, string extractPath)
        {
            using (ZipArchive Archive = ZipFile.Open(zipFile, ZipArchiveMode.Read))
            {
                Archive.ExtractToDirectory(extractPath);
            }
        }
    }
}
