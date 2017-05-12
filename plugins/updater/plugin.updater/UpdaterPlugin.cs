using Dragonfly.Common.Plugin;
using Dragonfly.Common.Utils;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Dragonfly.Plugin.Updater
{
    public class UpdaterPlugin : IPlugin
    {
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
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string updateConfig = Path.Combine(appDataPath, "dragonfly", "update", "config.xml");
            if (!File.Exists(updateConfig))
            {
                return;
            }
            Logger.info("UpdaterPlugin","Found update config file.");

            string pluginPath = Path.Combine(appDataPath, "dragonfly", "plugins");

            Process.Start(
                Path.Combine(pluginPath, "autoupdater.exe"),
                String.Format("{0} \"{1}\"", Process.GetCurrentProcess().Id, Process.GetCurrentProcess().MainModule.FileName));
        }


    }
}
