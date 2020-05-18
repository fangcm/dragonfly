﻿using Dragonfly.Common.Plugin;
using Dragonfly.Plugin.GridTrading.Utils;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Dragonfly.Plugin.GridTrading
{

    public class GridTradingPlugin : IPlugin
    {
        private GridTradingMainPanel mainPanel = null;

        private static object LockObject = new Object();
        private static int CheckUpDataLock = 0;
        private static int elapsedCounter = 0;
        private BackgroundWorker bgWorker;
        private System.Timers.Timer timer;


        public GridTradingPlugin()
        {

        }
        ~GridTradingPlugin()
        {
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
            timer.Enabled = false;

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
            lock (LockObject)
            {
                if (CheckUpDataLock == 0) CheckUpDataLock = 1;
                else return;
            }

            StartWorker();

            // 解锁更新检查锁
            lock (LockObject)
            {
                CheckUpDataLock = 0;
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
