using System;
using System.Windows.Forms;

namespace Dragonfly.Common.Plugin
{
    public partial class PlugInOptionPanel : UserControl
    {
        public delegate void EventHandleOptionsChanged(PlugInOptionPanel sender, EventArgs e);

        public event EventHandleOptionsChanged OptionsChanged;
        private bool bOptionsUpdated;


        public PlugInOptionPanel()
        {
            InitializeComponent();
        }

        protected void OnOptionsChanged()
        {
            if (OptionsChanged != null)
            {
                OptionsChanged(this, EventArgs.Empty);
            }
        }

        public bool OptionsUpdated
        {
            get
            {
                return bOptionsUpdated;
            }
            set
            {
                bOptionsUpdated = value;

                if (bOptionsUpdated)
                {
                    OnOptionsChanged();
                }
            }
        }
    }
}
