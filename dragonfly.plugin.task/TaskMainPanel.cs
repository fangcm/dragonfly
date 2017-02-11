using System.Collections;
using System.Windows.Forms;
using Dragonfly.Common.Plugin;
using System;

namespace Dragonfly.Plugin.Task
{
    public partial class TaskMainPanel : UserControl
    {
        public TaskMainPanel()
        {
            InitializeComponent();
        }

        private void TaskMainPanel_Load(object sender, System.EventArgs e)
        {
            listViewMain.Columns.Clear();
            listViewMain.Columns.Add("时间", 150, HorizontalAlignment.Left);
            listViewMain.Columns.Add("事件", 150, HorizontalAlignment.Left);
            listViewMain.Columns.Add("描述", 400, HorizontalAlignment.Left);

            RefreshTasks();

        }

        private void toolStripButtonRefresh_Click(object sender, System.EventArgs e)
        {
            RefreshTasks();

        }

        private void RefreshTasks()
        {
            this.listViewMain.Items.Clear();

        }

        private void toolStripButtonSetting_Click(object sender, EventArgs e)
        {
            JobSettingForm settingForm = new JobSettingForm();
            settingForm.ShowDialog();
        }

        private delegate void InsertLineDelegate(int index, DateTime date, string type, string desc);

        public void InsertLine(int index, DateTime date, string type, string desc)
        {
            if (this.listViewMain.InvokeRequired == false)
            {
                //如果调用该函数的线程和控件lstMain位于同一个线程内
                ListViewItem lvi = new ListViewItem();
                lvi.SubItems[0].Text = date.ToString("yyyy年MM月dd日 HH:mm:ss");
                lvi.SubItems.AddRange(new string[] { type, desc });
                this.listViewMain.Items.Insert(index, lvi);
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
