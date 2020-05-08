using Dragonfly.Common.Utils;
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

            try
            {
#if DEBUG
                Logger.info("PluginManager", "DEBUG mode");
                string pluginPath = AppDomain.CurrentDomain.BaseDirectory;
#else
                Logger.info("PluginManager", "RELEASE mode");
                string pluginPath = AppConfig.PluginsPath;
#endif
                string[] plugInsInDataPath = Directory.GetFiles(pluginPath, "*.dll", SearchOption.AllDirectories);
                plugIns.AddRange(plugInsInDataPath);
            }
            catch
            {
            }

            if (plugIns == null || plugIns.Count == 0)
            {
                Logger.error("PluginManager", "没有找到plugIn");
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
                        Logger.error("PluginManager", "Load dll file error. ", e.Message);
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
                                    Logger.error("PluginManager", "Create plugin instance error. ", e.Message);
                                }
                            }
                        }
                    }
                }
                catch (ReflectionTypeLoadException ex)
                {
                    Logger.error("PluginManager", "ReflectionTypeLoadException error. ", ex.Message);
                }
                catch (Exception e)
                {
                    Logger.error("PluginManager", "Other Exception error. ", e.Message);
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
            Logger.info("PluginManager", "Close plugins");
        }

    }
}
