namespace Dragonfly.Common.Plugin
{
    public interface IPlugin
    {
        void Initialize();
        void Dispose();

        System.Windows.Forms.UserControl PluginPanel { get; }
        
        string Name { get; }
        string Caption { get; }
        string Version { get; }
    }
}
