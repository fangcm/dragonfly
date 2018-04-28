using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace Dragonfly.Service
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        private const string DefaultServiceName = "DS Manager";
        private const string ServiceNameSwitch = "ServiceName";
        private ServiceProcessInstaller serviceProcessInstaller;
        private ServiceInstaller serviceInstaller;

        public ProjectInstaller()
        {
            InitializeComponent();

            serviceProcessInstaller = new ServiceProcessInstaller();
            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;

            serviceInstaller = new ServiceInstaller();
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            SetServiceName(DefaultServiceName);

            Installers.AddRange(new Installer[]
                {
                    serviceProcessInstaller,
                    serviceInstaller
                });

        }

        protected override void OnBeforeInstall(IDictionary stateSaver)
        {
            string serviceName = ServiceName(stateSaver);
            stateSaver[ServiceNameSwitch] = serviceName;
            SetServiceName(serviceName);
            base.OnBeforeInstall(stateSaver);
        }

        protected override void OnBeforeUninstall(IDictionary savedState)
        {
            if (savedState != null)
            {
                SetServiceName(ServiceName(savedState));
            }
            base.OnBeforeUninstall(savedState);
        }

        private string ServiceName(IDictionary savedState)
        {
            if (Context.Parameters.ContainsKey(ServiceNameSwitch))
            {
                return Context.Parameters[ServiceNameSwitch];
            }
            else if (savedState.Contains(ServiceNameSwitch))
            {
                return savedState[ServiceNameSwitch].ToString();
            }
            return DefaultServiceName;
        }

        private void SetServiceName(string serviceName)
        {
            serviceInstaller.DisplayName = serviceName;
            serviceInstaller.ServiceName = serviceName;
        }

    }
}
