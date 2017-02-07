using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Dragonfly.Common.Controls
{
	/// <summary>
	/// Handles a System Hotkey
	/// </summary>
	public class SystemHotkey : System.ComponentModel.Component,IDisposable
	{
		private System.ComponentModel.Container components = null;
		protected DummyWindowWithEvent m_Window=new DummyWindowWithEvent();	//window for WM_Hotkey Messages
        private Keys _hotkey = Keys.None;
        private Keys _modifiers = Keys.None;
        protected bool isRegistered = false;
		public event System.EventHandler Pressed;
		public event System.EventHandler Error;

		public SystemHotkey(System.ComponentModel.IContainer container)
		{
			container.Add(this);
			InitializeComponent();
			m_Window.ProcessMessage+=new MessageEventHandler(MessageEvent);
		}

		public SystemHotkey()
		{
			InitializeComponent();
			if (!DesignMode)
			{
				m_Window.ProcessMessage+=new MessageEventHandler(MessageEvent);
			}
		}

		public new void Dispose()
		{
			if (isRegistered)
			{
				if (UnregisterHotkey())
					System.Diagnostics.Debug.WriteLine("Unreg: OK");
			}
			System.Diagnostics.Debug.WriteLine("Disposed");
		}
	#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion

		protected void MessageEvent(object sender,ref Message m,ref bool Handled)
		{	//Handle WM_Hotkey event
			if ((m.Msg==WM_HOTKEY)&&(m.WParam==(IntPtr)this.GetType().GetHashCode()))
			{
				Handled=true;
				System.Diagnostics.Debug.WriteLine("HOTKEY pressed!");
				if (Pressed!=null) Pressed(this,EventArgs.Empty);
			}
		}
	
		protected bool UnregisterHotkey()
		{	//unregister hotkey
			return UnregisterHotKey(m_Window.Handle,this.GetType().GetHashCode());
		}

        protected bool RegisterHotkey(Keys modifiers, Keys key)
		{
			int mod=0;

            if (((int)modifiers & (int)Keys.Alt)==(int)Keys.Alt) {mod+=(int)Modifiers.MOD_ALT;}
			if (((int)modifiers & (int)Keys.Shift)==(int)Keys.Shift) {mod+=(int)Modifiers.MOD_SHIFT;}
			if (((int)modifiers & (int)Keys.Control)==(int)Keys.Control) {mod+=(int)Modifiers.MOD_CONTROL;}

            System.Diagnostics.Debug.Write(modifiers.ToString() + " ");
            System.Diagnostics.Debug.WriteLine(key.ToString());

            return RegisterHotKey(m_Window.Handle, this.GetType().GetHashCode(), mod, (int)key);
		}

		public bool IsRegistered
		{
			get{return isRegistered;}
		}


        public Keys Hotkey
        {
            get
            {
                return this._hotkey;
            }
        }

        /// <summary>
        /// Used to get/set the modifier keys (e.g. Keys.Alt | Keys.Control)
        /// </summary>
        public Keys HotkeyModifiers
        {
            get
            {
                return this._modifiers;
            }
        }

        public bool SetHotkey(Keys modifiers, Keys key)
        {
            if (DesignMode)
            {
                this._hotkey = key;
                this._modifiers = modifiers;
                return true;
            }
            if ((isRegistered) && !((this._hotkey == key) && (this._modifiers == modifiers)))
            {
                if (UnregisterHotkey())
                {
                    System.Diagnostics.Debug.WriteLine("Unreg: OK");
                    isRegistered = false;
                }
                else
                {
                    if (Error != null) Error(this, EventArgs.Empty);
                    System.Diagnostics.Debug.WriteLine("Unreg: ERR");
                }
            }
            if (key == Keys.None)
            {
                this._hotkey = key;
                this._modifiers = modifiers;
                return true;
            }
            if (RegisterHotkey(modifiers, key))	//Register new Hotkey
            {
                System.Diagnostics.Debug.WriteLine("Reg: OK");
                isRegistered = true;
            }
            else
            {
                if (Error != null) Error(this, EventArgs.Empty);
                System.Diagnostics.Debug.WriteLine("Reg: ERR");
            }
            this._hotkey = key;
            this._modifiers = modifiers;

            return true;
        }

        private const int WM_HOTKEY = 0x0312;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private enum Modifiers { MOD_ALT = 0x0001, MOD_CONTROL = 0x0002, MOD_SHIFT = 0x0004, MOD_WIN = 0x0008 }

        /// <summary>
        /// Defines a delegate for Message handling
        /// </summary>
        public delegate void MessageEventHandler(object Sender, ref Message msg, ref bool Handled);

        /// <summary>
        /// Inherits from System.Windows.Form.NativeWindow. Provides an Event for Message handling
        /// </summary>
        public class NativeWindowWithEvent : System.Windows.Forms.NativeWindow
        {
            public event MessageEventHandler ProcessMessage;
            protected override void WndProc(ref Message m)
            {
                if (ProcessMessage != null)
                {
                    bool Handled = false;
                    ProcessMessage(this, ref m, ref Handled);
                    if (!Handled) base.WndProc(ref m);
                }
                else base.WndProc(ref m);
            }
        }

        /// <summary>
        /// Inherits from NativeWindowWithEvent and automatic creates/destroys of a dummy window
        /// </summary>
        public class DummyWindowWithEvent : NativeWindowWithEvent, IDisposable
        {
            public DummyWindowWithEvent()
            {
                CreateParams parms = new CreateParams();
                this.CreateHandle(parms);
            }
            public void Dispose()
            {
                if (this.Handle != (IntPtr)0)
                {
                    this.DestroyHandle();
                }
            }
        }
    }
}
