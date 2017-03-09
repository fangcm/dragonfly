using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Dragonfly.Plugin.Task
{
    internal partial class AdjustmentConditionForm : Form
    {
        public bool bDataChanged = false;

        public AdjustmentCondition AdjustmentCondition { get; set; }

        public string Title
        {
            get { return this.txt_title.Text; }
            set { this.txt_title.Text = value; }
        }

        public bool Accumulated
        {
            get
            {
                if (rb_AccumulatedDelay.Checked)
                {
                    return false;
                }
                else if (rb_AccumulatedDec.Checked)
                {
                    return true;
                }
                else
                {
                    return true;
                }
            }
            set
            {
                rb_AccumulatedDec.Checked = value;
                rb_AccumulatedDelay.Checked = !value;
            }
        }

        public int ConditionType
        {
            get
            {
                if (rb_filename.Checked)
                {
                    return 0;
                }
                else if (rb_title.Checked)
                {
                    return 1;
                }
                else if (rb_processname.Checked)
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                switch (value)
                {
                    case 0:
                        rb_filename.Checked = true;
                        break;
                    case 1:
                        rb_title.Checked = true;
                        break;
                    case 2:
                        rb_processname.Checked = true;
                        break;
                    default:
                        rb_filename.Checked = true;
                        break;
                }
            }
        }

        public string ConditionValue
        {
            get { return this.txt_conditonValue.Text; }
            set { txt_conditonValue.Text = value; }
        }

        public int SpanSeconds
        {
            get { return Convert.ToInt32(num_seconds.Value); }
            set { num_seconds.Value = value; }
        }

        public AdjustmentConditionForm()
        {
            InitializeComponent();
        }

        private void AdjustmentConditionForm_Load(object sender, EventArgs e)
        {
            Title = AdjustmentCondition.Title;
            Accumulated = AdjustmentCondition.Accumulated;
            ConditionType = AdjustmentCondition.ConditionType;
            ConditionValue = AdjustmentCondition.ConditionValue;
            SpanSeconds = AdjustmentCondition.SpanSeconds;

            this.txt_title.TextChanged += new System.EventHandler(this.Data_Changed);
            this.rb_AccumulatedDelay.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.rb_AccumulatedDec.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.rb_filename.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.rb_title.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.rb_processname.CheckedChanged += new System.EventHandler(this.Data_Changed);
            this.txt_conditonValue.TextChanged += new System.EventHandler(this.Data_Changed);
            this.num_seconds.ValueChanged += new System.EventHandler(this.Data_Changed);

            bDataChanged = false;
        }

        private void Data_Changed(object sender, System.EventArgs e)
        {
            bDataChanged = true;
            System.Diagnostics.Debug.WriteLine("Data_Changed:" + sender);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (Title.Length == 0)
            {
                this.txt_title.Focus();
                MessageBox.Show(this, "请输入说明", "输入错误");
                return;
            }

            if (ConditionValue.Length == 0)
            {
                this.txt_conditonValue.Focus();
                MessageBox.Show(this, "请输入条件值", "输入错误");
                return;
            }

            if (bDataChanged)
            {
                AdjustmentCondition.Title = Title;
                AdjustmentCondition.Accumulated = Accumulated;
                AdjustmentCondition.ConditionType = ConditionType;
                AdjustmentCondition.ConditionValue = ConditionValue;
                AdjustmentCondition.SpanSeconds = SpanSeconds;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();

        }


    }
}
