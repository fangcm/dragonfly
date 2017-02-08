using System.Management;
using System.Runtime.InteropServices;

namespace Dragonfly.Chalk
{
    internal static class NetworkUtils
    {
        public static bool IsNetworkConnected()
        {
            System.Int32 dwFlag = new int();
            if (InternetGetConnectedState(ref dwFlag, 0))
                return true;
            else
                return false;
        }

        public static string GetNetCardMAC()
        {
            try
            {
                string stringMAC = "";
                ManagementClass MC = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection MOC = MC.GetInstances();

                foreach (ManagementObject MO in MOC)
                {
                    if ((bool)MO["IPEnabled"] == true)
                    {
                        stringMAC += MO["MACAddress"].ToString();
                    }
                }
                return stringMAC;
            }
            catch
            {
                return "";
            }
        }

        [DllImport("winInet.dll")]
        private static extern bool InternetGetConnectedState(ref int dwFlag, int dwReserved);
    }
}
