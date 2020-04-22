using System.Windows.Forms;

namespace Dragonfly.Common.Plugin
{
    public interface IPlugin
    {
        void Initialize();
        void Dispose();

        UserControl PluginPanel { get; }

        string Name { get; }
        string Caption { get; }
        string Version { get; }
    }
}
