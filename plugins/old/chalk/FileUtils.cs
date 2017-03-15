using System.IO;

namespace Dragonfly.Chalk
{
    internal static class FileUtils
    {
        public static bool CreateDirectory(string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path.Trim()))
                {
                    return false;
                }

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
