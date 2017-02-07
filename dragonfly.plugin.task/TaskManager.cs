using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using Dragonfly.Common.Plugin;
using Dragonfly.Common.Utils;

namespace Dragonfly.Plugin.Task
{

    public class TaskManager : IPlugIn
    {
        private string sSettingsFileName;
        private TaskCenter taskCenter;

        public Font defaultFont = new Font("SimSun", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
        public Color colorText = Color.Black;

        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNewTask;

        private TaskMainPanel mainPanel;

        public TaskManager()
        {
            this.taskCenter = new TaskCenter(this);

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = appDataPath + "\\fangcm\\";
            DirectoryUtils.CreateDirectory(path);
            this.sSettingsFileName = path + "TaskSettings.xml";

            this.toolStripMenuNotifyIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuNewTask = new System.Windows.Forms.ToolStripMenuItem();

            // 
            // toolStripMenuNotifyIcon
            // 
            this.toolStripMenuNotifyIcon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuNewTask});
            this.toolStripMenuNotifyIcon.Name = "toolStripMenuNotifyIcon";
            this.toolStripMenuNotifyIcon.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuNotifyIcon.Text = "提醒";
            // 
            // toolStripMenuNewTask
            // 
            this.toolStripMenuNewTask.Image = global::Dragonfly.Plugin.Task.Properties.Resources.addnote;
            this.toolStripMenuNewTask.ImageTransparentColor = System.Drawing.Color.Teal;
            this.toolStripMenuNewTask.Name = "toolStripMenuNewTask";
            this.toolStripMenuNewTask.Size = new System.Drawing.Size(148, 22);
            this.toolStripMenuNewTask.Text = "新建提醒";
            this.toolStripMenuNewTask.Click += new System.EventHandler(this.toolStripMenuNewTask_Click);

        }

        ~TaskManager()
        {

        }

        public void RemoveTask(Task task)
        {
            if (taskCenter.Tasks.Contains(task))
            {
                taskCenter.DelTask(task);
                SaveTaskSettings();
            }
        }

        private void toolStripMenuNewTask_Click(object sender, EventArgs e)
        {
            if (taskCenter.AddTask() != null)
            {
                SaveTaskSettings();
            }
        }

        private bool LoadTaskSettings()
        {
            XmlDocument xmlDocument = XmlHelper.Load(sSettingsFileName);
            if (xmlDocument == null)
            {
                return false;
            }

            XmlNodeList xmlNodelist = xmlDocument.SelectNodes("/TaskSettings/Task");
            foreach (XmlNode xmlNode in xmlNodelist)
            {
                Hashtable param = new Hashtable();
                param["Title"] = XmlHelper.GetElementText(xmlNode, "Title");
                param["Description"] = XmlHelper.GetElementText(xmlNode, "Description");

                param["TriggerType"] = XmlHelper.GetParamValue(xmlNode, "TriggerType", 1);
                param["BeginTime"] = (DateTime)XmlHelper.GetParamValue(xmlNode, "BeginTime", DateTime.Now);
                param["IsInterval"] = XmlHelper.GetParamValue(xmlNode, "IsInterval", false);
                param["Interval"] = XmlHelper.GetParamValue(xmlNode, "Interval", (int)EnumInterval.Interval30Mins);
                param["DaysOfTheWeek"] = XmlHelper.GetParamValue(xmlNode, "DaysOfTheWeek", (int)DaysOfTheWeek.None);

                param["IsNotifyShowMessage"] = XmlHelper.GetParamValue(xmlNode, "IsNotifyShowMessage", true);
                param["IsNotifyShowAnimation"] = XmlHelper.GetParamValue(xmlNode, "IsNotifyShowAnimation", true);
                param["IsNotifyInternal"] = XmlHelper.GetParamValue(xmlNode, "IsNotifyInternal", true);
                param["NotifyInternalType"] = XmlHelper.GetParamValue(xmlNode, "NotifyInternalType", (int)NotifyInternalType.LockScreen);
                param["LockScreenSeconds"] = XmlHelper.GetParamValue(xmlNode, "LockScreenSeconds", 30);
                param["IsNotifyRunApp"] = XmlHelper.GetParamValue(xmlNode, "IsNotifyRunApp", false);
                param["NotifyRunApp"] = XmlHelper.GetParamValue(xmlNode, "NotifyRunApp", string.Empty);
                param["NotifyRunAppParam"] = XmlHelper.GetParamValue(xmlNode, "NotifyRunAppParam", string.Empty);
                param["NotifyRunAppStartpath"] = XmlHelper.GetParamValue(xmlNode, "NotifyRunAppStartpath", string.Empty);
                param["TriggerCron"] = XmlHelper.GetElementText(xmlNode, "TriggerCron");

                taskCenter.AddTask(param);
            }


            return true;
        }


        public bool SaveTaskSettings()
        {
            XmlDocument xmlDocument = XmlHelper.Load(sSettingsFileName);
            if (xmlDocument == null)
            {
                xmlDocument = new XmlDocument();
                XmlDeclaration xmldecl = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = xmlDocument.DocumentElement;
                xmlDocument.AppendChild(xmldecl);

                XmlNode node = xmlDocument.CreateNode("element", "TaskSettings", "");
                xmlDocument.AppendChild(node);
            }

            XmlNode xmlRoot = xmlDocument.SelectSingleNode("/TaskSettings");
            xmlRoot.RemoveAll();

            foreach (Task task in taskCenter.Tasks)
            {
                Hashtable param = task.Params;

                XmlNode xmlNode = xmlDocument.CreateNode("element", "Task", "");

                XmlHelper.PutElementText(xmlNode, "Title", (string)param["Title"]);
                XmlHelper.PutElementText(xmlNode, "Description", (string)param["Description"]);

                XmlHelper.PutParamValue(xmlNode, "TriggerType", (int)param["TriggerType"]);
                XmlHelper.PutParamValue(xmlNode, "BeginTime", (DateTime)param["BeginTime"]);
                XmlHelper.PutParamValue(xmlNode, "IsInterval", (bool)param["IsInterval"]);
                XmlHelper.PutParamValue(xmlNode, "Interval", (int)param["Interval"]);
                XmlHelper.PutParamValue(xmlNode, "DaysOfTheWeek", (int)param["DaysOfTheWeek"]);

                XmlHelper.PutParamValue(xmlNode, "IsNotifyShowMessage", (bool)param["IsNotifyShowMessage"]);
                XmlHelper.PutParamValue(xmlNode, "IsNotifyShowAnimation", (bool)param["IsNotifyShowAnimation"]);
                XmlHelper.PutParamValue(xmlNode, "IsNotifyInternal", (bool)param["IsNotifyInternal"]);
                XmlHelper.PutParamValue(xmlNode, "NotifyInternalType", (int)param["NotifyInternalType"]);
                XmlHelper.PutParamValue(xmlNode, "LockScreenSeconds", (int)param["LockScreenSeconds"]);
                XmlHelper.PutParamValue(xmlNode, "IsNotifyRunApp", (bool)param["IsNotifyRunApp"]);
                XmlHelper.PutParamValue(xmlNode, "NotifyRunApp", (string)param["NotifyRunApp"]);
                XmlHelper.PutParamValue(xmlNode, "NotifyRunAppParam", (string)param["NotifyRunAppParam"]);
                XmlHelper.PutParamValue(xmlNode, "NotifyRunAppStartpath", (string)param["NotifyRunAppStartpath"]);
                XmlHelper.PutElementText(xmlNode, "TriggerCron", (string)param["TriggerCron"]);
                xmlRoot.AppendChild(xmlNode);
            }
            return XmlHelper.Save(sSettingsFileName, xmlDocument);
        }

        public string Name { get { return "DragonflyTask"; } }
        public string Caption { get { return "提醒"; } }
        public string Description { get { return "提醒、定时通知、任务等"; } }
        public string Autor { get { return "fangcm"; } }
        public string Version { get { return "1.0.0"; } }

        public void Initialize(XmlNode settings)
        {
            if (settings != null && settings.Name == "DragonflyTask")
            {
                XmlNode xmlDefault = settings.SelectSingleNode("default");

                this.defaultFont = XmlHelper.GetParamValue(xmlDefault, "defaultFont", this.defaultFont);
                this.colorText = XmlHelper.GetParamValue(xmlDefault, "colorText", this.colorText);

            }


            LoadTaskSettings();

            taskCenter.StartAllTask();
        }

        public void Dispose()
        {
            taskCenter.TerminateAllTask();
        }

        public XmlNode GetOptionSettings(XmlDocument xmlDocument)
        {
            if (xmlDocument == null)
                return null;

            XmlNode xmlRoot = xmlDocument.CreateNode("element", "DragonflyTask", "");

            XmlNode xmlDefault = xmlDocument.CreateNode("element", "default", "");
            XmlHelper.PutParamValue(xmlDefault, "defaultFont", this.defaultFont);
            XmlHelper.PutParamValue(xmlDefault, "colorText", this.colorText);
            xmlRoot.AppendChild(xmlDefault);

            return xmlRoot;
        }

        public PlugInOptionPanel OptionPanel
        {
            get
            {
                return null;
            }

        }


        public PlugInMainPanel MainPanel
        {
            get
            {
                if (mainPanel == null || mainPanel.IsDisposed)
                {
                    this.mainPanel = new TaskMainPanel();
                    this.mainPanel.TaskCenter = this.taskCenter;
                    this.mainPanel.TaskManager = this;
                }
                return mainPanel;
            }
        }
        public ToolStripItem MainMenu
        {
            get
            {
                return null;
            }
        }
        public ToolStripItem NotifyIconMenu
        {
            get
            {
                return this.toolStripMenuNotifyIcon;
            }
        }
    }
}
