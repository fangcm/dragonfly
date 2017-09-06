using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Dragonfly.Task.Core
{
    public class LockScreenForm : Form
    {
        private Timer timerTick = null;
        private bool designMode = false;

        private UserActivityHook globalHooks = null;
        private NotifySetting notifySetting;

        public int IntervalSeconds { get; set; }
        public virtual string Description { get; set; }
        public virtual string ClockText { get; set; }

        public bool IsDebugMode { get; set; }

        public virtual DateTime AddIntervalSeconds(int addSeconds)
        {
            Logger.info("LockScreenForm", "AddIntervalSeconds:", addSeconds);
            notifySetting.EndTriggerTime += TimeSpan.FromSeconds(addSeconds);
            NotifySetting.SaveToFile(notifySetting);
            return notifySetting.EndTriggerTime;
        }

        public LockScreenForm()
        {
            designMode = (this.GetService(typeof(System.ComponentModel.Design.IDesignerHost)) != null || LicenseManager.UsageMode == LicenseUsageMode.Designtime);
            IsDebugMode = false;
            IntervalSeconds = 10;

            Initialize();

            notifySetting = new NotifySetting();
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
            this.ClientSize = Screen.PrimaryScreen.Bounds.Size;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LockScreenForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = designMode ? false : true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LockScreenForm_Load);
            this.ResumeLayout(false);
        }

        private void LockScreenForm_Load(object sender, EventArgs e)
        {
            if (IsDebugMode)
            {
                this.TopMost = false;
                this.ControlBox = true;
                this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            }
            else
            {
                WinApi.SetWindowToolwindowAndTopMost(this.Handle);
            }

            Logger.info("LockScreenForm", "Start Lock ! interval seconds:", IntervalSeconds);

            notifySetting.LastTriggerTime = DateTime.Now;
            notifySetting.EndTriggerTime = DateTime.Now + TimeSpan.FromSeconds(IntervalSeconds);
            NotifySetting.SaveToFile(notifySetting);

            if (!designMode)
            {
                this.Deactivate += new System.EventHandler(this.LockScreenForm_Deactivate);

                this.timerTick = new Timer();
                this.timerTick.Enabled = false;
                this.timerTick.Interval = 100;
                this.timerTick.Tick += new EventHandler(this.timerTick_Elapsed);
                this.timerTick.Start();

                if (!IsDebugMode)
                {
                    globalHooks = new UserActivityHook(false, true);
                    globalHooks.KeyDown += new KeyEventHandler(GlobalHooks_KeyDown);
                }
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
            if (notifySetting.EndTriggerTime <= DateTime.Now)
            {
                notifySetting.EndTriggerTime = DateTime.Now;
                NotifySetting.SaveToFile(notifySetting);
                this.Close();
                return;
            }

            if (!IsDebugMode)
            {
                WinApi.ControllingProcess(this.Handle);
            }

            TimeSpan leftTime = notifySetting.EndTriggerTime - DateTime.Now;
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
            Logger.info("LockScreenForm", "Dispose, disposing:", disposing);

            base.Dispose(disposing);
        }


        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (!designMode)
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

        private void GlobalHooks_KeyDown(object sender, KeyEventArgs e)
        {
            Keys vkCode = e.KeyData;

            switch (vkCode)
            {
                case Keys.LWin:
                case Keys.RWin:
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
            if (vkCode >= Keys.F1 && vkCode >= Keys.F15)
            {
                e.Handled = true;
            }
        }

    }
}
