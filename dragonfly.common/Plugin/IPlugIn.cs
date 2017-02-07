using System;

namespace Dragonfly.Common.Plugin
{
    public interface IPlugIn
    {
        void Initialize(System.Xml.XmlNode settings);
        void Dispose();

        System.Xml.XmlNode GetOptionSettings(System.Xml.XmlDocument xmlDocument);

        PlugInMainPanel MainPanel { get; }
        PlugInOptionPanel OptionPanel { get; }

        System.Windows.Forms.ToolStripItem MainMenu { get; }
        System.Windows.Forms.ToolStripItem NotifyIconMenu { get; }
        
        string Name { get; }
        string Caption { get; }
        string Description { get; }
        string Autor { get; }
        string Version { get; }
    }
}
