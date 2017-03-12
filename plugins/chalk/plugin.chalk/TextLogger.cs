using System;
using System.IO;

namespace Dragonfly.Chalk
{
    internal static class TextLogger
    {
        public static bool WriteLog(string filename, string message, string title, bool createDirectory)
        {
            try
            {
                FileInfo fi = new FileInfo(filename);
                if (!fi.Exists)
                {
                    if (createDirectory)
                    {
                        string path = Path.GetDirectoryName(filename);
                        if (!FileUtils.CreateDirectory(path))
                            return false;
                    }
                    FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Close();
                }

                StreamWriter sw = new StreamWriter(filename, true);
                if (!string.IsNullOrEmpty(title))
                {
                    sw.Write(Environment.NewLine);
                    sw.Write(title);
                    sw.Write(Environment.NewLine);
                }
                sw.Write(message);
                sw.Flush();
                sw.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
