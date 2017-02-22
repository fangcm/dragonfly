using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Dragonfly.Task.Notify.Common
{
    public class LockScreenForm : Form
    {
        private System.ComponentModel.IContainer components = null;
        private UserActivityHook globalHooks;
        private Timer timerTick;
        private DateTime endDateTime;

        public int IntervalSeconds { get; set; }
        public virtual string Description { get; set; }
        public virtual string ClockText { get; set; }

        public LockScreenForm()
        {
            InitializeComponent();

            IntervalSeconds = 30;
            base.Location = new Point(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y);
            base.Width = Screen.PrimaryScreen.Bounds.Width;
            base.Height = Screen.PrimaryScreen.Bounds.Height;

#if DEBUG
            this.ControlBox = true;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
#endif

            globalHooks = new UserActivityHook(false, true);
            globalHooks.KeyDown += new KeyEventHandler(GlobalHooks_KeyDown);

            endDateTime = DateTime.Now + TimeSpan.FromSeconds(IntervalSeconds);


        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerTick = new Timer(this.components);
            this.SuspendLayout();
            // 
            // timerTick
            // 
            this.timerTick.Enabled = true;
            this.timerTick.Interval = 1;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // LockScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LockScreenForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Deactivate += new System.EventHandler(this.LockScreenForm_Deactivate);
            this.ResumeLayout(false);

        }

        protected override void Dispose(bool disposing)
        {
            globalHooks.Stop(false, true, false);
            timerTick.Stop();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void LockScreenForm_Deactivate(object sender, EventArgs e)
        {
            this.Activate();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if ((m.Msg == 0x84) && (m.Result == ((IntPtr)2)))
            {
                m.Result = (IntPtr)1;
            }
            if (m.Msg == 0xa3)
            {
                m.WParam = IntPtr.Zero;
            }
        }

        private void GlobalHooks_KeyDown(object sender, KeyEventArgs e)
        {
            Keys vkCode = e.KeyData;

            switch (vkCode)
            {
                case Keys.LWin:
                case Keys.RWin:
                //case Keys.Delete:
                case Keys.Tab:
                case Keys.Escape:
                case Keys.F4:
                //case Keys.Shift:
                case Keys.Control:
                case Keys.Alt:
                    e.Handled = true;
                    break;

                case Keys.Enter:
                    e.Handled = true;
                    break;

                default:
                    e.Handled = false;
                    break;
            }
        }

        private void KillTaskmgr()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                try
                {
                    if (process.ProcessName.ToLower().Trim() == "taskmgr")
                    {
                        process.Kill();
                        break;
                    }
                }
                catch
                {
                    break;
                }
            }
        }

        [DllImport("user32")]
        public static extern bool SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, uint wFlags);

        private void timerTick_Tick(object sender, EventArgs e)
        {
            if (endDateTime <= DateTime.Now)
            {
                this.Close();
                return;
            }

            KillTaskmgr();

            int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
            int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;

            SetWindowPos(base.Handle.ToInt32(), -1, 0, 0, iActulaWidth, iActulaHeight, 1);

            TimeSpan leftTime = endDateTime - DateTime.Now;


            string time = string.Format("{0}:{1}:{2}", leftTime.Hours.ToString("00"), leftTime.Minutes.ToString("00"), leftTime.Seconds.ToString("00"));

            ClockText = time;
        }
    }
}
