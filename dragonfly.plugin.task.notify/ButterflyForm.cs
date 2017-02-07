using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Dragonfly.Plugin.Task.Notify
{
    public partial class ButterflyForm : Form
    {
        private int x;
        private int y;
        public static int rx;
        public static int ry;
        private Point mouseDown;
        private bool isGoMouse = false;
        private bool isMouseDown = false;
        private bool isMsg = false;
        private int clock = 0;
        private bool isGoOn = true;
        private int screenWidth = 0;
        private int screenHeight = 0;

        public ButterflyForm()
        {
            InitializeComponent();
        }

        public int TimeInterval
        {
            get
            {
                return this.tmrStop.Interval;
            }
            set
            {
                this.tmrStop.Interval = value;
            }
        }

        private void ButterflyForm_Load(object sender, EventArgs e)
        {
            screenWidth = Screen.PrimaryScreen.Bounds.Width - 175;
            screenHeight = Screen.PrimaryScreen.Bounds.Height - 120;
            x = Location.X;
            y = Location.Y;
            this.tmr1.Start();
            this.tmrStop.Start();

        }

        private void tmr1_Tick(object sender, EventArgs e)
        {
            Point p2 = new Point(x, y);
            this.Location = p2;
            if (isGoMouse)           //是否跟随鼠标移动
            {
                if (isGoOn)         //是否继续生成新坐标
                {
                    rx = MousePosition.X - 50;
                    ry = MousePosition.Y - 50;
                    if (rx < 5)
                        rx = 5;
                    if (ry < 5)
                        ry = 5;
                    if (rx > screenWidth)
                        rx = screenWidth;
                    if (ry > screenHeight)
                        ry = screenHeight;
                    isGoOn = false;
                }
            }
            else                   //根据生成随机数移动窗体               
            {
                if (isGoOn)         //是否继续生成新坐标
                {
                    Random ran = new Random();
                    rx = ran.Next(5, screenWidth);
                    ry = ran.Next(5, screenHeight);
                    isGoOn = false;
                }
            }

            if ((x >= rx - 2 && x <= rx + 2) || (y >= ry - 2 && y <= ry + 2))
                isGoOn = true;
            if (rx < this.Location.X)
                x -= 1;
            else
                x += 1;
            if (ry < this.Location.Y)
                y -= 1;
            else
                y += 1;



            if (isMsg)                  //显示信息标签
            {
                if (clock == 50)
                {
                    if (this.lblMsg.Visible == true)
                        this.lblMsg.Visible = false;
                    else
                        this.lblMsg2.Visible = false;
                    clock = 0;
                    isMsg = false;
                }
                else
                    clock++;
            }
        }

        private void ptbImage_MouseEnter(object sender, EventArgs e)
        {
            if (this.lblMsg.Visible == false && this.lblMsg2.Visible == false)
            {
                Random r = new Random();
                if (r.Next(2) > 0)
                    this.lblMsg.Visible = true;
                else
                    this.lblMsg2.Visible = true;
                isMsg = true;
            }
            else
            {
                if (this.tmr1.Enabled == false)
                {
                    this.lblMsg.Visible = false;
                    this.lblMsg2.Visible = false;
                }
            }
        }

        private void tmrStop_Tick(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
