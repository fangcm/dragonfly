using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
            if (worker != null)
            {
                worker.CancelAsync();
            }
            while (true)
            {
                if (!worker.IsBusy)
                    break;
            }
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
            ticks++;

            BackgroundWorker localWorker = sender as BackgroundWorker;
            if (localWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }


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
            catch (Exception)
            {
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
            string dragonfly = Path.Combine(appDataPath, "dragonfly", "plugins", "dragonfly.main.exe");
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
            ProcessStarter starter = new ProcessStarter(dragonfly);
            starter.Run();
            return true;
        }

        private bool RunNotifyProcess(string appDataPath)
        {
            string notify = Path.Combine(appDataPath, "dragonfly", "plugins", "simple.notify.exe");
            if (!File.Exists(notify))
            {
                return false;
            }
            ProcessStarter starter = new ProcessStarter(notify, "-lockminutes 10");
            starter.Run();
            return true;
        }
    }
}