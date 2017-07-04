using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Dragonfly.Task.Core;
using System.Text;

namespace Dragonfly.Simple.Notify
{
    internal partial class NomalLockScreenForm : LockScreenForm
    {
        public const int MM_MCINOTIFY = 0x3B9;  //这是声明 播完音乐 mciSendString（）向系统发送的指令

        [DllImport("winmm.dll")]
        private static extern long mciSendString(string command,
                                                    StringBuilder returnString,
                                                    int returnSize,
                                                    IntPtr hwndCallback);


        public NomalLockScreenForm()
        {
            InitializeComponent();
            PlaySong(@"lock.mp3");  // when complete callback to DefWndProc

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

        protected override void DefWndProc(ref Message m)
        {
            base.DefWndProc(ref m);

            if (m.Msg == MM_MCINOTIFY) //判断指令是不是MM_MCINOTIFY

            //当歌曲播完 mciSendString（）向系统发送的MM_MCINOTIFY指令
            {
                PlaySong(@"lock.mp3");//播完就自动播放这个。。。
            }
        }

        public void PlaySong(string file)
        {
            mciSendString("close media", null, 0, IntPtr.Zero);//关闭
            mciSendString("open \"" + file + "\" type mpegvideo alias media", null, 0, IntPtr.Zero);

            //打开  file 这个路径的歌曲 " ，type mpegvideo是文件类型  ，    alias 是将文件别名为media 
            mciSendString("play media notify", null, 0, this.Handle);//播放
        }


    }
}
