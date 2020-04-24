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

            TraderHelper.Instance.Init();

        }

        private void toolStripButtonSetting_Click(object sender, EventArgs e)
        {
            /*
            JobSettingForm settingForm = new JobSettingForm();
            if(settingForm.ShowDialog() == DialogResult.OK)
            {
                if (settingForm.bDataChanged)
                {
                    //this.gridTradingPlugin.StartGridTrading();
                }
            }
            */
        }

        private delegate void InsertLineDelegate(int index, DateTime date, Color foreColor, string desc);

        public void InsertLine(int index, DateTime date, System.Drawing.Color foreColor, string desc)
        {
            if (this.listViewMain.InvokeRequired == false)
            {
                //如果调用该函数的线程和控件lstMain位于同一个线程内
                ListViewItem lvi = listViewMain.Items.Add(date.ToString("yyyy年MM月dd日 HH:mm:ss"));
                lvi.ForeColor = foreColor;
                lvi.SubItems.Add(desc);
            }
            else
            {
                //如果调用该函数的线程和控件lstMain不在同一个线程
                //通过使用Invoke的方法，让子线程告诉窗体线程来完成相应的控件操作
                InsertLineDelegate insertLineDelegate = new InsertLineDelegate(InsertLine);

                //使用控件lstMain的Invoke方法执行DMSGD代理(其类型是DispMSGDelegate)
                this.listViewMain.Invoke(insertLineDelegate, index, date, foreColor, desc);

            }
        }

        public void InsertLine(DateTime date, Color foreColor, string desc)
        {
            InsertLine(0, date, foreColor, desc);
        }

        private void toolStripButtonInit_Click(object sender, EventArgs e)
        {
            TraderHelper.Instance.Init();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            TraderHelper.Instance.BuyStock("300498", 10.012f, 100);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            TraderHelper.Instance.SellStock("300498", 10.012f, 100);
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            TraderHelper.Instance.CancelStock("300498", 10.012f, 100);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }
    }

}
