﻿using System.IO;
using System.Reflection;
using System.Threading;

namespace Dragonfly.Chalk
{
    internal static class SingleApplication
    {
        public static bool IsAlreadyRunning()
        {
            string strLoc = Assembly.GetExecutingAssembly().Location;
            FileSystemInfo fileInfo = new FileInfo(strLoc);
            string sExeName = fileInfo.Name;
            bool bCreatedNew;

            mutex = new Mutex(true, "Global\\" + sExeName, out bCreatedNew);
            if (bCreatedNew)
                mutex.ReleaseMutex();

            return !bCreatedNew;
        }

        static Mutex mutex;
    }
}
