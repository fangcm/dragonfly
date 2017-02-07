using System;
using System.IO;
using Ionic.Zip;

namespace Dragonfly.Chalk
{
    internal static class ZipUtils
    {
        public static bool ZipDir(string zipFileToCreate, string directoryToZip)
        {
            if (!System.IO.Directory.Exists(directoryToZip))
            {
                return false;
            }
            if (System.IO.File.Exists(zipFileToCreate))
            {
                return false;
            }

            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddDirectory(directoryToZip);
                    zip.Save(zipFileToCreate);

                    return true;
                }
            }
            catch
            {
                return false;
            }

        }

        public static bool ZipDir(FileStream zipFileStreamToCreate, string directoryToZip)
        {
            if (!System.IO.Directory.Exists(directoryToZip))
            {
                return false;
            }

            try
            {
                using (ZipFile zip = new ZipFile())
                {
                    zip.AddDirectory(directoryToZip);
                    zip.Save(zipFileStreamToCreate);

                    return true;
                }
            }
            catch
            {
                return false;
            }

        }
    }
}
