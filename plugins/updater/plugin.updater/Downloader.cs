using System.Net;

namespace Dragonfly.Plugin.Updater
{
    internal static class Downloader
    {
        public static string DownloadToString(string link)
        {
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    return webClient.DownloadString(link);
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        public static bool DownloadFileToLocal(string link, string outputFilePath)
        {
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    webClient.DownloadFile(link, outputFilePath);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
