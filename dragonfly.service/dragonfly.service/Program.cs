using System.Reflection;
using System.ServiceProcess;

namespace Dragonfly.Service
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        public static void Main(string[] args)
        {
            if (args != null && args.Length == 1 && args[0].Length > 1
               && (args[0][0] == '-' || args[0][0] == '/'))
            {
                switch (args[0].Substring(1).ToLower())
                {
                    default:
                        break;
                    case "install":
                    case "i":
                        string _exePath = Assembly.GetExecutingAssembly().Location;
                        ServiceHelper.Install("dsmanager", "dsmanager", _exePath, "", ServiceStartType.Auto, ServiceAccount.LocalService, null);
                        break;
                    case "uninstall":
                    case "u":
                        ServiceHelper.Uninstall("dsmanager");
                        break;
                }
            }
            else
            {
                ServiceBase[] ServicesToRun = new ServiceBase[] { new MainService() };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
