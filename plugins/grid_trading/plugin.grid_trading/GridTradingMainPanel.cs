using Dragonfly.Plugin.GridTrading.Strategy;
using Dragonfly.Plugin.GridTrading.Trade;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dragonfly.Plugin.GridTrading
{
    public partial class GridTradingMainPanel : UserControl
    {
        private GridTradingPlugin gridTradingPlugin;

        public GridTradingMainPanel()
        {
            InitializeComponent();
        }

        internal GridTradingPlugin GridTradingPlugin
        {
            get { return this.gridTradingPlugin; }
            set { this.gridTradingPlugin = value; }
        }

        private void GridTradingMainPanel_Load(object sender, System.EventArgs e)
        {
            listViewMain.Columns.Clear();
            listViewMain.Columns.Add("时间", 150, HorizontalAlignment.Left);
            listViewMain.Columns.Add("描述", 450, HorizontalAlignment.Left);

            toolStripButtonInit.Checked = gridTradingPlugin.TraderReady;
            toolStripButtonStop.Checked = !gridTradingPlugin.TraderReady;
        }

        private delegate void InsertLineDelegate(DateTime date, Color foreColor, string desc);

        public void InsertLine(DateTime date, Color foreColor, string desc)
        {
            if (this.listViewMain.InvokeRequired == false)
            {
                //如果调用该函数的线程和控件lstMain位于同一个线程内
                ListViewItem lvi = listViewMain.Items.Add(date.ToString("yyyy年MM月dd日 HH:mm:ss"));
                lvi.ForeColor = foreColor;
                lvi.SubItems.Add(desc);
                listViewMain.Items[listViewMain.Items.Count - 1].EnsureVisible();
            }
            else
            {
                //如果调用该函数的线程和控件lstMain不在同一个线程
                //通过使用Invoke的方法，让子线程告诉窗体线程来完成相应的控件操作
                InsertLineDelegate insertLineDelegate = new InsertLineDelegate(InsertLine);

                //使用控件lstMain的Invoke方法执行DMSGD代理(其类型是DispMSGDelegate)
                this.listViewMain.Invoke(insertLineDelegate, date, foreColor, desc);

            }
        }

        private void toolStripButtonSetting_Click(object sender, EventArgs e)
        {
            GridSettingForm settingForm = new GridSettingForm();
            settingForm.ShowDialog();
        }

        private void toolStripButtonOrder_Click(object sender, EventArgs e)
        {
            TradingForm form = new TradingForm();
            form.ShowDialog();
        }

        private void toolStripButtonInit_Click(object sender, EventArgs e)
        {
            if (GridTradingPlugin.TimerEnabled)
                return;

            SetAutoTraderFlag(true);
        }

        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            if (!GridTradingPlugin.TimerEnabled)
                return;

            SetAutoTraderFlag(false);
        }

        private void SetAutoTraderFlag(bool enable)
        {
            if (gridTradingPlugin == null)
                return;

            if (enable)
            {
                gridTradingPlugin.TraderReady = TraderHelper.Instance.Init();
            }
            toolStripButtonInit.Checked = enable;
            toolStripButtonStop.Checked = !enable;

            gridTradingPlugin.SetAutoTraderFlag(enable);
        }
    }

}
