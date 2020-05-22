using Dragonfly.Common.Plugin;
using Dragonfly.Plugin.GridTrading.Utils;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Dragonfly.Plugin.GridTrading
{

    public class GridTradingPlugin : IPlugin
    {
        private static object lockObject = new Object();
        private static int checkUpDataLock = 0;
        private static int elapsedCounter = 0;
        private static bool timerEnabled = false;

        private GridTradingMainPanel mainPanel = null;
        private BackgroundWorker bgWorker;
        private System.Timers.Timer timer;


        public GridTradingPlugin()
        {

        }
        ~GridTradingPlugin()
        {
        }

        internal static bool TimerEnabled
        {
            get
            {
                return timerEnabled;
            }
        }

        public string Name { get { return "DragonflyGridTrading"; } }
        public string Caption { get { return "网格交易"; } }
        public string Version { get { return "1.0.0"; } }

        internal bool TraderReady { get; set; }

        public void Initialize()
        {
            if (mainPanel == null)
            {
                //为了初始化
                UserControl m = PluginPanel;
            }
            LoggerUtil.Init(mainPanel);
            LoggerUtil.Log(LoggType.Gray, "启动初始化");

            SqliteHelper.DataSource = AppDomain.CurrentDomain.BaseDirectory + "grid_trading.db";

            this.bgWorker = new BackgroundWorker();
            this.bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);

            timer = new System.Timers.Timer(10000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            timer.AutoReset = true;
            timer.Enabled = timerEnabled;

        }


        public void Dispose()
        {
            timer.Enabled = false;
            this.bgWorker.Dispose();
        }

        public UserControl PluginPanel
        {
            get
            {
                if (mainPanel == null || mainPanel.IsDisposed)
                {
                    this.mainPanel = new GridTradingMainPanel();
                    this.mainPanel.GridTradingPlugin = this;
                }
                return mainPanel;
            }
        }


        private void Timer_Elapsed(object source, System.Timers.ElapsedEventArgs e)
        {
            lock (lockObject)
            {
                if (checkUpDataLock == 0) checkUpDataLock = 1;
                else return;
            }

            StartWorker();

            // 解锁更新检查锁
            lock (lockObject)
            {
                checkUpDataLock = 0;
            }
        }

        private void StartWorker()
        {
            if (!TraderReady)
            {
                LoggerUtil.Log(LoggType.MediumBlue, "没有关联交易软件,不能自动交易");
                return;
            }

            elapsedCounter++;
            if (elapsedCounter % 18 != 1)
            {
                return;
            }

            if (!this.bgWorker.IsBusy)
            {
                this.bgWorker.RunWorkerAsync();
            }
        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            TradingWorker.start();
        }

        internal void SetAutoTraderFlag(bool enable)
        {
            elapsedCounter = 0;
            timerEnabled = enable;

            if (enable)
            {
                LoggerUtil.Log(LoggType.MediumBlue, "开启自动交易");
                timer.Start();
            }
            else
            {
                LoggerUtil.Log(LoggType.MediumBlue, "停止自动交易");
                timer.Stop();
            }
        }

    }
}
