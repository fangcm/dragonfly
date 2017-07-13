using System.Windows.Forms;

namespace Dragonfly.Task.Core
{
    public class SecondaryScreenForm : Form
    {
        public SecondaryScreenForm()
        {
            Initialize();
        }

        private void Initialize()
        {
            this.SuspendLayout();

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
            this.Name = "SecondaryScreenForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            //this.Load += new System.EventHandler(this.LockScreenForm_Load);
            this.ResumeLayout(false);
        }
/*
        private void LockScreenForm_Load(object sender, EventArgs e)
        {
            WinApi.MoveToTopMost(this.Handle);
        }
*/
    }
}
