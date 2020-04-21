﻿using Dragonfly.Common.Plugin;
using Dragonfly.Common.Utils;
using Dragonfly.Plugin.GridTrading.Utils;
using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace Dragonfly.Plugin.GridTrading
{

    public class GridTradingPlugin : IPlugin
    {
        private GridTradingMainPanel mainPanel = null;

        private PowerModeChangedEventHandler pmceh;
        private SessionEndedEventHandler seeh;

        public GridTradingPlugin()
        {

        }
        ~GridTradingPlugin()
        {
        }

        public string Name { get { return "DragonflyGridTrading"; } }
        public string Caption { get { return "网格交易"; } }
        public string Version { get { return "1.0.0"; } }

        public void Initialize()
        {
            if (mainPanel == null)
            {
                //为了初始化
                UserControl m = PluginPanel;
            }
            LoggerUtil.Init(mainPanel);
            LoggerUtil.Log(LoggType.Resume, "启动初始化");
            Logger.info("GridTradingPlugin", "Initialize");
            pmceh = new PowerModeChangedEventHandler(SystemEvents_PowerModeChanged);
            seeh = new SessionEndedEventHandler(SystemEvents_SessionEnded);

            SystemEvents.SessionEnded += seeh;
            SystemEvents.PowerModeChanged += pmceh;

        }

        private void detachEventsHandlers()
        {
            if (pmceh != null) SystemEvents.PowerModeChanged -= this.pmceh;
            if (seeh != null) SystemEvents.SessionEnded -= this.seeh;
        }

        public void Dispose()
        {
            detachEventsHandlers();
            Logger.info("GridTradingPlugin", "Dispose");
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


        private void SystemEvents_PowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Suspend)
            {
                LoggerUtil.Log(LoggType.Suspend, "休眠");
                Logger.info("GridTradingPlugin", "休眠");
            }
            else if (e.Mode == PowerModes.Resume)
            {
                LoggerUtil.Log(LoggType.Resume, "唤醒");
                Logger.info("GridTradingPlugin", "唤醒");
            }
        }

        private void SystemEvents_SessionEnded(object sender, SessionEndedEventArgs e)
        {
            if (e.Reason == SessionEndReasons.Logoff)
            {
                LoggerUtil.Log(LoggType.Suspend, "注销登录");
                Logger.info("GridTradingPlugin", "注销登录");
            }
            else if (e.Reason == SessionEndReasons.SystemShutdown)
            {
                LoggerUtil.Log(LoggType.Suspend, "关机");
                Logger.info("GridTradingPlugin", "关机");
            }
        }



    }
}
