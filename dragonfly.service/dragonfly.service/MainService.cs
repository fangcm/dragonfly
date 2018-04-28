using System;
using System.Collections;
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
        public MainService()
        {
            InitializeComponent();

            this.CanShutdown = true;
            this.CanStop = true;

            timer.Interval = 2000;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

        protected override void OnStart(string[] args)
        {
            Logger.info("Service", "OnStart");
            timer.Start();
        }

        protected override void OnStop()
        {
            Logger.info("Service", "OnStop");
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
            BackgroundWorker localWorker = sender as BackgroundWorker;
            if (localWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }


            try
            {
                if(IsDragonflyMainProgramRunning())
                {
                    return;
                }

                string appDataPath = WinApi.GetCurrentUserApplicationDataFolderPath();
                string dragonfly = Path.Combine(appDataPath, "dragonfly", "plugins", "dragonfly.main.exe");
                if (!File.Exists(dragonfly))
                {
                    foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
                    {
                        Logger.error("Service", " {0} value = {1}", de.Key, de.Value);
                    }


                    string programFiles = Environment.GetEnvironmentVariable("ProgramW6432 ");
                    dragonfly = Path.Combine(programFiles, "dragonfly", "dragonfly.main.exe");
                    if (!File.Exists(dragonfly))
                    {
                        programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
                        dragonfly = Path.Combine(programFiles, "dragonfly", "dragonfly.main.exe");
                        if (!File.Exists(dragonfly))
                        {
                            return;
                        }
                    }
                }
                ProcessStarter starter = new ProcessStarter(dragonfly);
                starter.Run();
            }
            catch (Exception ex)
            {
                Logger.error("Service", "worker_DoWork error.",ex.Message);

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
                    if (process.MainModule.FileName.ToLower().EndsWith("dragonfly.main.exe"))
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

    }
}
