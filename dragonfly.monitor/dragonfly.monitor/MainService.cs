using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Dragonfly.Service
{
    public class MainService : ServiceBase
    {
        private readonly Timer timer = new Timer();
        private readonly BackgroundWorker worker = new BackgroundWorker();

        public MainService()
        {
            InitializeComponent();

        }

        private void InitializeComponent()
        {
            this.ServiceName = "MainService";
            this.CanShutdown = true;
            this.CanStop = true;

            timer.Interval = 2000;
            timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);

            worker.WorkerSupportsCancellation = true;
            worker.WorkerReportsProgress = false;
            worker.DoWork += new DoWorkEventHandler(Worker_DoWork);
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
            if (worker != null) { 
                worker.CancelAsync();
            }
            while (true)
            {
                if (!worker.IsBusy)
                    break;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (worker != null)
            {
                worker.CancelAsync();
            }
            if (disposing)
            {
                timer.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
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
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string appDataPath1 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                string appDataPath2 = (Environment.UserName);
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
