using System;
using System.ComponentModel;
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
            Logger.info("Service", "Worker_DoWork");
            BackgroundWorker localWorker = sender as BackgroundWorker;
            if (localWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }


            try
            {
                string appDataPath = WinApi.GetCurrentUserApplicationDataFolderPath();
                string a = "";
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }

        }
    }
}
