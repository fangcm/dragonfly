﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            List<string> plugIns = new List<string>();
            try
            {
                string[] plugInsInExePath = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.AllDirectories);
                plugIns.AddRange(plugInsInExePath);
            }
            catch
            {
            }
            try
            {
                string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string pluginPath = Path.Combine(appDataPath, "dragonfly", "plugins");
                string[] plugInsInDataPath = Directory.GetFiles(pluginPath, "*.dll", SearchOption.AllDirectories);
                plugIns.AddRange(plugInsInDataPath);
            }
            catch
            {
            }
#if DEBUG
            try
            {
                string debugPath = @"..\..\plugins\bin\Debug";
                string debugPluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, debugPath);
                string[] plugInsInDebugPath = Directory.GetFiles(debugPluginPath, "*.dll", SearchOption.AllDirectories);
                plugIns.AddRange(plugInsInDebugPath);
            }
            catch
            {
            }
#endif

            if (plugIns == null || plugIns.Count == 0)
            {
                return;
            }

            foreach (string dll in plugIns)
            {
                try
                {
                    Assembly asm = null;
                    try
                    {
                        asm = Assembly.LoadFile(dll);
                    }
                    catch
                    {
                        asm = null;
                    }
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
                                try
                                {
                                    IPlugin plugin = (IPlugin)Activator.CreateInstance(t);
                                    plugin.Initialize();
                                    plugInList.Add(plugin);
                                }
                                catch
                                {
                                }
                            }
                        }
                    }
                }
                catch
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
