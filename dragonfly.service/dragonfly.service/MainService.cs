using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Security.Principal;
using System.ServiceProcess;
using System.Timers;

namespace Dragonfly.Service
{
    partial class MainService : ServiceBase
    {
        private readonly Timer timer = new Timer();
        private int ticks = 0;

        public MainService()
        {
            InitializeComponent();

            this.CanShutdown = true;
            this.CanStop = true;
            timer.Interval = 60000;

            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        protected override void OnStart(string[] args)
        {
            timer.Start();
        }

        protected override void OnStop()
        {
            timer.Stop();
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
        }

        private void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker localWorker = sender as BackgroundWorker;
            try
            {
                if (IsDragonflyMainProgramRunning())
                {
                    return;
                }

                string appDataPath = WinApi.GetCurrentUserApplicationDataFolderPath();
                if (RunDragonflyMainProcess(appDataPath))
                {
                    return;
                }

                if (ticks % 60 == 40)
                {
                    RunNotifyProcess(appDataPath);
                }
            }
            catch (Exception ex)
            {
                Logger.error("worker_DoWork Exception", ex.Message);
            }

        }

        private bool IsDragonflyMainProgramRunning()
        {
            bool found = false;
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                try
                {
                    if (process.ProcessName.ToLower().EndsWith("dragonfly.main"))
                    {
                        found = true;
                        break;
                    }
                }
                catch
                {
                    continue;
                }
            }
            return found;
        }

        private bool RunDragonflyMainProcess(string appDataPath)
        {
            string pluginsPath = Path.Combine(appDataPath, "dragonfly", "plugins");
            if(!Directory.Exists(pluginsPath))
            {
                return false;
            }

            string dragonfly = Path.Combine(pluginsPath, "dragonfly.main.exe");
            if (!File.Exists(dragonfly))
            {
                string programFiles = Environment.GetEnvironmentVariable("ProgramW6432");
                dragonfly = Path.Combine(programFiles, "dragonfly", "dragonfly.main.exe");
                if (!File.Exists(dragonfly))
                {
                    programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                    dragonfly = Path.Combine(programFiles, "dragonfly", "dragonfly.main.exe");
                    if (!File.Exists(dragonfly))
                    {
                        return false;
                    }
                }
            }

            WinApi.StartProcessAndBypassUAC(dragonfly, null);
            return true;
        }

        private bool RunNotifyProcess(string appDataPath)
        {
            string notify = Path.Combine(appDataPath, "dragonfly", "plugins", "simple.notify.exe");
            if (!File.Exists(notify))
            {
                return false;
            }

            WinApi.StartProcessAndBypassUAC(notify, "-lockminutes 10");
            return true;
        }
    }
}