using Dragonfly.Common.Plugin;
using Dragonfly.Common.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Dragonfly.Plugin.Chalk
{
    public class ChalkPlugin : IPlugin
    {
        private static object LockObject = new Object();
        private static int CheckUpDateLock = 0;
        private static int elapsedCounter = 0;
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
                    Logger.error("ChalkPlugin", "Create directory", ChalkPath, e.Message);
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
            ChalkPlugin.log();

            elapsedCounter++;
            if (elapsedCounter % 60 == 0)
            {
                ChalkPlugin.ClearLog();
            }
        }


        public static void log()
        {
            string logPath = Path.Combine(AppConfig.WorkingPath, "chalk", DateTime.Now.ToString("yyyyMMdd"));
            if (!Directory.Exists(logPath))
            {
                try
                {
                    Directory.CreateDirectory(logPath);
                }
                catch (Exception e)
                {
                    Logger.error("ChalkPlugin", "CreateDirectory:", logPath, e.Message);
                    return;
                }
            }

            WindowUtils.FullForegroundWindowInfo();

            string fileName = Path.Combine(logPath, "trace.log");
            Logger.WriteLog(fileName, string.Format("{0} [{1}] [{2}]", WindowUtils.ForegroundWindowProcessName, WindowUtils.ForegroundWindowFileName, WindowUtils.ForegroundWindowTitle));

            if (!string.IsNullOrEmpty(WindowUtils.ForegroundWindowProcessName))
            {
                string pictureFilename = Path.Combine(logPath, DateTime.Now.ToString("HHmmss") + ".jpg");
                WindowUtils.DrawScreen(pictureFilename);
            }
        }

        public static void ClearLog()
        {
            string reserve = DateTime.Now.AddDays(-30).ToString("yyyyMMdd");

            string chalkPath = Path.Combine(AppConfig.WorkingPath, "chalk");
            try
            {
                DirectoryInfo dir = new DirectoryInfo(chalkPath);
                if (dir.Exists)
                {
                    DirectoryInfo[] childs = dir.GetDirectories();
                    foreach (DirectoryInfo child in childs)
                    {
                        if (reserve.CompareTo(child.Name) > 0)
                        {
                            child.Delete(true);
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Logger.error("ChalkPlugin", "DeleteDirectory, ", e.Message);
                return;
            }

        }
    }
}
