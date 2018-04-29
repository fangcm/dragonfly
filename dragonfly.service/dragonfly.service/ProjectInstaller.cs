using System.ComponentModel;
using System.Configuration.Install;

namespace Dragonfly.Service
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {

        public ProjectInstaller()
        {
            InitializeComponent();

        }

    }
}
