using System.IO;
using System.Reflection;
using System.Threading;

namespace Dragonfly.Main
{

    public class SingleApplication
	{
        private static Mutex mutex;

        public static bool IsAlreadyRunning()
		{
			string sAssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
			bool bCreatedNew;

			mutex = new Mutex(true, "Global\\"+ sAssemblyName, out bCreatedNew);
			if (bCreatedNew)
				mutex.ReleaseMutex();

			return !bCreatedNew;
		}

	}
}
