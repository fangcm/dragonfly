﻿using Dragonfly.Common.Utils;
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
            AppDomain.CurrentDomain.AssemblyResolve += PluginManager.AssemblyResolve;
            LoadPlugIns();
            AppDomain.CurrentDomain.AssemblyResolve -= PluginManager.AssemblyResolve;
        }

        public IPlugin[] PlugIns
        {
            get { return plugInList.ToArray(); }
        }


        private void LoadPlugIns()
        {
            plugInList.Clear();

            List<string> plugIns = new List<string>();
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
#else
            try
            {
                string pluginPath = AppConfig.PluginsPath;
                string[] plugInsInDataPath = Directory.GetFiles(pluginPath, "*.dll", SearchOption.AllDirectories);
                plugIns.AddRange(plugInsInDataPath);
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
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e);
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
                                catch (Exception e)
                                {
                                    System.Diagnostics.Debug.WriteLine(e);
                                }
                            }
                        }
                    }
                }
                catch (ReflectionTypeLoadException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
                catch
                {
                }
            }
        }

        private static Assembly AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var assemblyPath = Path.Combine(AppConfig.PluginsPath, new AssemblyName(args.Name).Name + ".dll");
            return !File.Exists(assemblyPath) ? null : Assembly.LoadFrom(assemblyPath);
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
