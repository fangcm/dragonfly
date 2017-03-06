using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Dragonfly.Task.Core;

namespace Dragonfly.Simple.Notify
{
    internal partial class NomalLockScreenForm : LockScreenForm
    {
        public NomalLockScreenForm()
        {
            InitializeComponent();

        }

        public override string Description
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

        public override string ClockText
        {
            get
            {
                return this.labelClock.Text;
            }
            set
            {
                this.labelClock.Text = value;
            }
        }

    }
}
