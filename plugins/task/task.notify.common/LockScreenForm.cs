using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Dragonfly.Task.Notify.Common
{
    public class LockScreenForm : Form
    {
        private Timer timerTick = null;

        private UserActivityHook globalHooks = null;
        private DateTime endDateTime;

        public int IntervalSeconds { get; set; }
        public virtual string Description { get; set; }
        public virtual string ClockText { get; set; }

        private bool IsDesignMode { get; set; }

        public virtual DateTime AddIntervalSeconds(int addSeconds)
        {
            endDateTime += TimeSpan.FromSeconds(IntervalSeconds);
            return endDateTime;
        }

        public LockScreenForm()
        {
            IsDesignMode = (this.GetService(typeof(System.ComponentModel.Design.IDesignerHost)) != null || LicenseManager.UsageMode == LicenseUsageMode.Designtime);

            Initialize();

#if DEBUG
            this.ControlBox = true;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
#endif

            IntervalSeconds = 30;
            endDateTime = DateTime.Now + TimeSpan.FromSeconds(IntervalSeconds);

            if (!IsDesignMode)
            {
                this.Deactivate += new System.EventHandler(this.LockScreenForm_Deactivate);

                this.timerTick = new Timer();
                this.timerTick.Enabled = false;
                this.timerTick.Interval = 100;
                this.timerTick.Tick += new EventHandler(this.timerTick_Elapsed);

                globalHooks = new UserActivityHook(false, true);
                globalHooks.KeyDown += new KeyEventHandler(GlobalHooks_KeyDown);
            }
        }

        ~LockScreenForm()
        {
            Dispose(false);
        }

        private void Initialize()
        {
            this.SuspendLayout();
            // 
            // LockScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            //this.ClientSize = new System.Drawing.Size(450, 300);
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LockScreenForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = IsDesignMode ? false : true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LockScreenForm_Load);
            this.ResumeLayout(false);
        }

        private void LockScreenForm_Load(object sender, EventArgs e)
        {
            endDateTime = DateTime.Now + TimeSpan.FromSeconds(IntervalSeconds);
            if (timerTick != null)
            {
                timerTick.Start();
            }
        }

        private void LockScreenForm_Deactivate(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void timerTick_Elapsed(object sender, EventArgs e)
        {
            RefreshScreen();
        }

        private void RefreshScreen()
        {
            if (endDateTime <= DateTime.Now)
            {
                this.Close();
                return;
            }

            KillTaskmgr();

            int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
            int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;
            SetWindowPos(base.Handle.ToInt32(), -1, 0, 0, iActulaWidth, iActulaHeight, 0);

            TimeSpan leftTime = endDateTime - DateTime.Now;
            string time = string.Format("{0}:{1}:{2}", leftTime.Hours.ToString("00"), leftTime.Minutes.ToString("00"), leftTime.Seconds.ToString("00"));
            ClockText = time;
        }

        protected override void Dispose(bool disposing)
        {
            if (timerTick != null)
            {
                timerTick.Stop();
                timerTick.Dispose();
                timerTick = null;
            }

            if (globalHooks != null)
            {
                globalHooks.KeyDown -= new KeyEventHandler(GlobalHooks_KeyDown);
                globalHooks.Stop(false, true, false);
                globalHooks = null;
            }

            base.Dispose(disposing);
        }


        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (!IsDesignMode)
            {
                if ((m.Msg == 0x84) && (m.Result == ((IntPtr)2)))
                {
                    m.Result = (IntPtr)1;
                }
                if (m.Msg == 0xa3)
                {
                    m.WParam = IntPtr.Zero;
                }
            }
        }

        #region win_api

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

        #endregion



    }
}
