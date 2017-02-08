using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Dragonfly.Common.Plugin
{
    public class PluginManager
    {
        private List<IPlugin> plugInList = new List<IPlugin>();

        public PluginManager()
        {
            LoadPlugIns();
        }

        public IPlugin[] PlugIns
        {
            get { return plugInList.ToArray(); }
        }


        private void LoadPlugIns()
        {
            plugInList.Clear();

            string[] plugIns = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.AllDirectories);
            foreach (string dll in plugIns)
            {
                try
                {
                    Assembly asm = Assembly.LoadFile(dll);
                    if (asm == null)
                        continue;

                    Type[] types = asm.GetTypes();
                    foreach (Type t in types)
                    {
                        if (t.IsPublic && (!t.IsAbstract))
                        {
                            Type typeInterface = t.GetInterface("Dragonfly.Common.Plugin.IPlugIn", true);

                            if (typeInterface != null)
                            {
                                IPlugin plugin = (IPlugin)Activator.CreateInstance(t);
                                plugInList.Add(plugin);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public void ClosePlugins()
        {
            foreach (IPlugin pluginOn in plugInList)
            {
                pluginOn.Dispose();
            }

            plugInList.Clear();
        }

    }
}
