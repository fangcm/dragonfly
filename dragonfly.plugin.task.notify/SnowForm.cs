using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Dragonfly.Plugin.Task.Notify
{
    public partial class SnowForm : Form
    {
        #region SnowFlake类

        private class SnowFlake
        {
            public float Rotation;
            public float RotVelocity;
            public float Scale;
            public float X;
            public float XVelocity;
            public float Y;
            public float YVelocity;
        }

        #endregion

        #region 属性

        private Bitmap m_Snow;

        /// <summary>
        /// The (cached) Image of a 32x32 snowflake
        /// </summary>
        private Bitmap Snow
        {
            get
            {
                if (m_Snow == null)
                {
                    ///First Time - Create Image
                    m_Snow = new Bitmap(32, 32);

                    using (Graphics g = Graphics.FromImage(m_Snow))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.Clear(Color.Transparent);

                        g.TranslateTransform(16, 16, MatrixOrder.Append);

                        Color black = Color.FromArgb(1, 1, 1);
                        Color white = Color.FromArgb(255, 255, 255);

                        DrawSnow(g, new SolidBrush(black), new Pen(black, 3f));
                        DrawSnow(g, new SolidBrush(white), new Pen(white, 2f));

                        g.Save();
                    }
                }

                return m_Snow;
            }
        }

        #endregion

        private static readonly Random Random = new Random();

        /// <summary>
        /// 当前活动的雪花对象集合。
        /// </summary>
        private readonly List<SnowFlake> SnowFlakes = new List<SnowFlake>();

        private int Tick = 0;

        public SnowForm()
        {
            InitializeComponent();

            //开启双缓冲自定义窗体样式。
            SetStyle(
                ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint |
                ControlStyles.DoubleBuffer, true);

            Location = new Point(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y);
            Width = Screen.PrimaryScreen.Bounds.Width;
            Height = Screen.PrimaryScreen.Bounds.Height;
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

        private void SnowForm_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 20;
            timer.Tick += OnTick;
            timer.Start();

            this.tmrStop.Start();
        }

        private void OnTick(object sender, EventArgs args)
        {
            Tick++;

            //衍生新的雪花
            if (Tick % 3 == 0 && Random.NextDouble() < 0.70)
            {
                SnowFlake s = new SnowFlake();
                s.X = Random.Next(-50, Width + 50);
                s.Y = Random.Next(-20, -7);
                s.XVelocity = (float)(Random.NextDouble() - 0.5f) * 2f;
                s.YVelocity = (float)(Random.NextDouble() * 3) + 1f;
                s.Rotation = Random.Next(0, 359);
                s.RotVelocity = Random.Next(-3, 3) * 2;

                if (s.RotVelocity == 0)
                {
                    s.RotVelocity = 3;
                }

                s.Scale = (float)(Random.NextDouble() / 2) + 0.75f;
                SnowFlakes.Add(s);
            }

            //需要移除的雪花。
            List<SnowFlake> del = new List<SnowFlake>();
            foreach (SnowFlake s in SnowFlakes)
            {
                s.X += s.XVelocity;
                s.Y += s.YVelocity;
                s.Rotation += s.RotVelocity;

                s.XVelocity += ((float)Random.NextDouble() - 0.5f) * 0.7f;
                s.XVelocity = Math.Max(s.XVelocity, -2f);
                s.XVelocity = Math.Min(s.XVelocity, +2f);

                if (s.YVelocity > Height + 10)
                {
                    del.Add(s);
                }
            }

            //删除
            foreach (SnowFlake s in del)
            {
                SnowFlakes.Remove(s);
            }

            //刷新
            Refresh();
        }

        private void SnowForm_Paint(object sender, PaintEventArgs e)
        {
            // 绘制满天飞舞的雪花。
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;  //高速绘制，可以视硬件情况改为高质量绘图。

            foreach (SnowFlake s in SnowFlakes)
            {
                g.ResetTransform();
                g.TranslateTransform(-16, -16, MatrixOrder.Append); //平移
                g.ScaleTransform(s.Scale, s.Scale, MatrixOrder.Append); //缩放
                g.RotateTransform(s.Rotation, MatrixOrder.Append); //旋转
                g.TranslateTransform(s.X, s.Y, MatrixOrder.Append); //平移
                g.DrawImage(Snow, 0, 0); //绘制
            }

        }
    
        private static void DrawSnow(Graphics g, Brush b, Pen p)
        {
            const int a = 6;
            const int a2 = a + 2;
            const int r = 2;

            g.DrawLine(p, -a, -a, +a, +a);
            g.DrawLine(p, -a, +a, +a, -a);

            g.DrawLine(p, -a2, 0, +a2, 0);
            g.DrawLine(p, 0, -a2, 0, +a2);

            g.FillEllipse(b, -r, -r, r * 2, r * 2);
        }

        private void tmrStop_Tick(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
