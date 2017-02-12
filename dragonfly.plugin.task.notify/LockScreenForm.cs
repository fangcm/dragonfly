using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Dragonfly.Plugin.Task.Notify
{
    internal partial class LockScreenForm : Form
    {
        private UserActivityHook globalHooks;
        private DateTime endDateTime;

        public LockScreenForm()
        {
            InitializeComponent();

            base.Location = new Point(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y);
            base.Width = Screen.PrimaryScreen.Bounds.Width;
            base.Height = Screen.PrimaryScreen.Bounds.Height;

#if DEBUG
            this.ControlBox = true;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
#endif

        }


        public int TimeInterval
        {
            get
            {
                return this.timerBlock.Interval;
            }
            set
            {
                this.timerBlock.Interval = value;
                endDateTime = DateTime.Now + TimeSpan.FromMilliseconds(this.timerBlock.Interval);
            }
        }

        public string Description
        {
            get
            {
                return this.labelDescription.Text;
            }
            set
            {
                this.labelDescription.Text = value;
            }
        }

        private void LockScreenForm_Activated(object sender, EventArgs e)
        {

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

        private void timerBlock_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LockScreenForm_Load(object sender, EventArgs e)
        {
            globalHooks = new UserActivityHook(false, true);
            globalHooks.KeyDown += new KeyEventHandler(GlobalHooks_KeyDown);

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

        private void LockScreenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            globalHooks.Stop(false, true, false);
            timerTotopAndTaskmgr.Stop();
        }
        private void LockScreenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            globalHooks.Stop(false, true, false);
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

        private void timerTotopAndTaskmgr_Tick(object sender, EventArgs e)
        {
            KillTaskmgr();
            SetWindowPos(base.Handle.ToInt32(), -1, 0, 0, 0, 300, 1);

            TimeSpan leftTime = endDateTime - DateTime.Now;

            string time = string.Format("{0}:{1}:{2}", leftTime.TotalHours.ToString("00"), leftTime.Minutes.ToString("00"), leftTime.Seconds.ToString("00"));

            this.labelClock.Text = time;
        }
    }
}
