using System.IO;

namespace Dragonfly.Plugin.Task
{
    internal class Util
    {
        public static bool CreateDirectory(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

}
