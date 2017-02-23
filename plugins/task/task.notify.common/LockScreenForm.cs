using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Dragonfly.Task.Notify.Common
{
    public class LockScreenForm : Form
    {
        private UserActivityHook globalHooks;
        private Timer timerTick;
        private DateTime endDateTime;

        public int IntervalSeconds { get; set; }
        public virtual string Description { get; set; }
        public virtual string ClockText { get; set; }

        public LockScreenForm()
        {
            Initialize();
#if DEBUG
            this.ControlBox = true;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
#endif

            IntervalSeconds = 30;

            globalHooks = new UserActivityHook(false, true);
            globalHooks.KeyDown += new KeyEventHandler(GlobalHooks_KeyDown);

        }

        private void Initialize()
        {
            this.timerTick = new Timer();
            this.SuspendLayout();
            // 
            // timerTick
            // 
            this.timerTick.Interval = 100;
            this.timerTick.Tick += new System.EventHandler(this.timerTick_Tick);
            // 
            // LockScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.ClientSize = new System.Drawing.Size(450, 300);
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LockScreenForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Deactivate += new System.EventHandler(this.LockScreenForm_Deactivate);
            this.Load += new System.EventHandler(this.LockScreenForm_Load);
            this.ResumeLayout(false);

        }

        private void LockScreenForm_Load(object sender, EventArgs e)
        {
            endDateTime = DateTime.Now + TimeSpan.FromSeconds(IntervalSeconds);
            this.timerTick.Start();
        }

        protected override void Dispose(bool disposing)
        {
            if (timerTick != null)
            {
                timerTick.Stop();
                timerTick.Dispose();
                timerTick = null;
            }
            globalHooks.Stop(false, true, false);

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

            SetWindowPos(base.Handle.ToInt32(), -1, 0, 0, iActulaWidth, iActulaHeight, 0);

            TimeSpan leftTime = endDateTime - DateTime.Now;


            string time = string.Format("{0}:{1}:{2}", leftTime.Hours.ToString("00"), leftTime.Minutes.ToString("00"), leftTime.Seconds.ToString("00"));

            ClockText = time;
        }

    }
}
