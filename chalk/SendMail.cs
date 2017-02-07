using System;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Dragonfly.Chalk
{
    internal class SendMail
    {
        private static Thread workerThread = null;

        public static bool IsBusy()
        {
            if (workerThread != null && workerThread.IsAlive)
                return true;
            else
                return false;
        }

        public static void SendPathToGmail(string basePath, string sNeedToSendPath,
            string account, string password, string from, string to,
            string subject, string body, string host, int port, bool bSsl)
        {
            if (workerThread != null && workerThread.IsAlive)
                return;

            SendMail worker = new SendMail();

            worker.basePath = basePath;
            worker.sNeedToSendPath = sNeedToSendPath;

            worker.account = account;
            worker.password = password;
            worker.from = from;
            worker.to = to;
            worker.subject = subject;
            worker.body = body;
            worker.host = host;
            worker.port = port;
            worker.bSsl = bSsl;

            workerThread = new Thread(worker.DoWork);
            workerThread.Start();
        }

        private void DoWork()
        {
            string tempFilename = string.Empty;
            bool bOK = false;
            try
            {
                tempFilename = System.IO.Path.GetTempFileName();
                using (FileStream fs = new FileStream(tempFilename, FileMode.Open))
                {
                    string path = basePath + sNeedToSendPath;
                    bOK = ZipUtils.ZipDir(fs, path);
                    fs.Close();

                    if (bOK)
                    {
                        if (SendMail.Sendmail(account, password, from, to, subject, body, tempFilename, host, port, bSsl))
                        {
                            System.IO.Directory.Delete(path, true);
                            Logger.ConfigSetSendedPathState(sNeedToSendPath);
                        }
                    }
                    else
                    {
                        if (!Directory.Exists(path))
                        {
                            Logger.ConfigSetSendedPathState(sNeedToSendPath);
                        }
                    }
                }

            }
            catch (Exception) { }
            finally
            {
                try
                {
                    if (tempFilename != null && tempFilename != String.Empty)
                    {
                        if (File.Exists(tempFilename))
                        {
                            System.IO.File.Delete(tempFilename);
                        }
                    }
                }
                catch (Exception e) 
                {
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        private static bool Sendmail(string account, string password, string from, string to, string subject, string body, string fileAttachments, string host, int port, bool bSsl)
        {
            Attachment data = null;
            try
            {

                MailMessage mailMsg = new MailMessage();

                // To
                mailMsg.To.Add(to);
                // From
                MailAddress mailAddress = new MailAddress(from);
                mailMsg.From = mailAddress;

                // Subject and Body
                mailMsg.Subject = subject;
                mailMsg.Body = body;

                // Attachment
                data = new Attachment(fileAttachments, MediaTypeNames.Application.Zip);
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(fileAttachments);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(fileAttachments);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(fileAttachments);
                mailMsg.Attachments.Add(data);

                NetworkCredential credentials = new NetworkCredential(account, password);

                // Init SmtpClient and send
                SmtpClient smtpClient = new SmtpClient(host, port);
                smtpClient.EnableSsl = bSsl;
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);

                return true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                return false;
            }
            finally
            {
                if (data != null)
                    data.Dispose();
            }
        }


        private string sNeedToSendPath;
        private string basePath;

        private string account;
        private string password;
        private string from;
        private string to;
        private string subject;
        private string body;
        private string host;
        private int port;
        private bool bSsl;
    }
}
