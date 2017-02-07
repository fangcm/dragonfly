using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using Dragonfly.Common.Plugin;
using Dragonfly.Common.Utils;

namespace Dragonfly.Main
{
    public class PluginManager
    {
        private string sSettingsFileName;

        private List<IPlugIn> plugInList = new List<IPlugIn>();

        public PluginManager()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = appDataPath + "\\fangcm\\";
            DirectoryUtils.CreateDirectory(path);
            sSettingsFileName = path + "PlugInsSettings.xml";

            plugInList.Clear();
            LoadPlugIns();
        }

        public IPlugIn[] PlugIns
        {
            get { return plugInList.ToArray(); }
        }


        private void LoadLocalPlugIns()
        {
            IPlugIn ipi;
            try
            {
                Type[] types = Assembly.GetExecutingAssembly().GetTypes();

                foreach (Type t in types)
                {
                    if (t.IsPublic && (!t.IsAbstract))
                    {
                        Type typeInterface = t.GetInterface("Dragonfly.Common.Plugin.IPlugIn", true);

                        if (typeInterface != null)
                        {
                            ipi = (IPlugIn)Activator.CreateInstance(t);
                            plugInList.Add(ipi);
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void LoadPlugIns()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            if (!Directory.Exists(path))
                return;

            string[] plugIns = Directory.GetFiles(path);
            foreach (string s in plugIns)
            {
                FileInfo file = new FileInfo(s);
                if (file.Extension.ToLower() != ".dll" && file.Extension.ToLower() != ".exe")
                {
                    continue;
                }
                string dll = file.FullName;

                IPlugIn ipi;
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
                                ipi = (IPlugIn)Activator.CreateInstance(t);
                                plugInList.Add(ipi);
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
            foreach (IPlugIn pluginOn in plugInList)
            {
                pluginOn.Dispose();
            }

            plugInList.Clear();
        }


        public bool LoadSettings()
        {
            XmlDocument xmlDocument = XmlHelper.Load(sSettingsFileName);

            foreach (IPlugIn pluginOn in plugInList)
            {
                if (xmlDocument == null)
                {
                    pluginOn.Initialize(null);
                }
                else
                {
                    XmlNode node = xmlDocument.SelectSingleNode("/PlugIns/" + pluginOn.Name);
                    pluginOn.Initialize(node);
                }
            }

            return true;
        }


        public bool SaveSettings()
        {
            XmlDocument xmlDocument = XmlHelper.Load(sSettingsFileName);
            if (xmlDocument == null)
            {
                xmlDocument = new XmlDocument();
                XmlDeclaration xmldecl = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = xmlDocument.DocumentElement;
                xmlDocument.AppendChild(xmldecl);

                XmlNode node = xmlDocument.CreateNode("element", "PlugIns", "");
                xmlDocument.AppendChild(node);

            }

            XmlNode xmlRoot = xmlDocument.SelectSingleNode("/PlugIns");
            xmlRoot.RemoveAll();

            foreach (IPlugIn pluginOn in plugInList)
            {
                XmlNode xmlNode = pluginOn.GetOptionSettings(xmlDocument);
                if(xmlNode != null)
                    xmlRoot.AppendChild(xmlNode);
            }
            return XmlHelper.Save(sSettingsFileName, xmlDocument);
        }


        public UserControl[] GetOptionPanels()
        {
            List<UserControl> optionPages = new List<UserControl>();

            foreach (IPlugIn ipi in plugInList)
            {
                UserControl page = ipi.OptionPanel;
                if (page != null)
                    optionPages.Add(page);
            }

            return optionPages.ToArray();
        }


    }
}
