using System;
using System.IO;

namespace Dragonfly.Common.Utils
{
    public static class DirectoryUtils
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
