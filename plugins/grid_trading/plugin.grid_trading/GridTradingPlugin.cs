using Dragonfly.Common.Plugin;
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
            LoggerUtil.Log(LoggType.Gray, "启动初始化");
            Logger.info("GridTradingPlugin", "Initialize");
 
        }

 

        public void Dispose()
        {
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




    }
}
