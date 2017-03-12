using Dragonfly.Common.Plugin;
using Dragonfly.Common.Utils;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Dragonfly.Plugin.Chalk
{
    class ChalkPlugin : IPlugin
    {
        private static object LockObject = new Object();
        private static int CheckUpDateLock = 0;
        private BackgroundWorker bgWorker;
        private System.Timers.Timer timer;
        private string ChalkPath { set; get; }

        public string Name { get { return "DragonflyChalk"; } }
        public string Caption { get { return "粉笔"; } }
        public string Version { get { return "1.0.0"; } }

        public UserControl PluginPanel { get { return null; } }

        public void Initialize()
        {
            ChalkPath = Path.Combine(AppConfig.WorkingPath, "chalk");
            if (!Directory.Exists(ChalkPath))
            {
                try
                {
                    Directory.CreateDirectory(ChalkPath);
                }
                catch (Exception e)
                {
                    TraceLog.error(e.Message);
                    ChalkPath = AppConfig.WorkingPath;
                }
            }

            this.bgWorker = new BackgroundWorker();
            this.bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);

            timer = new System.Timers.Timer(60000);
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
            Logger.logScreen();
        }


    }
}
