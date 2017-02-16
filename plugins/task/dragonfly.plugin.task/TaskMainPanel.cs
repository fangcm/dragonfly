using System;
using System.Windows.Forms;

namespace Dragonfly.Plugin.Task
{
    public partial class TaskMainPanel : UserControl
    {
        private TaskPlugin taskPlugin;

        public TaskMainPanel()
        {
            InitializeComponent();
        }

        internal TaskPlugin TaskPlugin
        {
            get { return this.taskPlugin; }
            set { this.taskPlugin = value; }
        }

        private void TaskMainPanel_Load(object sender, System.EventArgs e)
        {
            listViewMain.Columns.Clear();
            listViewMain.Columns.Add("时间", 150, HorizontalAlignment.Left);
            listViewMain.Columns.Add("事件", 40, HorizontalAlignment.Left);
            listViewMain.Columns.Add("描述", 300, HorizontalAlignment.Left);

        }

        private void toolStripButtonSetting_Click(object sender, EventArgs e)
        {
            JobSettingForm settingForm = new JobSettingForm();
            if(settingForm.ShowDialog() == DialogResult.OK)
            {
                if (settingForm.bDataChanged)
                {
                    this.taskPlugin.StartTask();
                }
            }
        }

        private delegate void InsertLineDelegate(int index, DateTime date, string type, string desc);

        public void InsertLine(int index, DateTime date, string type, string desc)
        {
            if (this.listViewMain.InvokeRequired == false)
            {
                //如果调用该函数的线程和控件lstMain位于同一个线程内
                ListViewItem lvi = listViewMain.Items.Add(date.ToString("yyyy年MM月dd日 HH:mm:ss"));
                lvi.SubItems.Add(type);
                lvi.SubItems.Add(desc);
            }
            else
            {
                //如果调用该函数的线程和控件lstMain不在同一个线程
                //通过使用Invoke的方法，让子线程告诉窗体线程来完成相应的控件操作
                InsertLineDelegate insertLineDelegate = new InsertLineDelegate(InsertLine);

                //使用控件lstMain的Invoke方法执行DMSGD代理(其类型是DispMSGDelegate)
                this.listViewMain.Invoke(insertLineDelegate, index, date, type, desc);

            }
        }

        public void InsertLine(DateTime date, string type, string desc)
        {
            InsertLine(0, date, type, desc);
        }
    }

}
