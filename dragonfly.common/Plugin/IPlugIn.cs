using System;
using System.Windows.Forms;

namespace Dragonfly.Common.Plugin
{
    public interface IPlugin : IDisposable
    {
        void Initialize();

        string Name { get; }
        string Caption { get; }
        string Version { get; }

        UserControl PluginPanel { get; }
    }
}
