using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace FortniteLauncher.Server
{
    public class InstallServer
    {
        public void Install()
        {
            if (Directory.Exists("LauncherData/LawinServer/LawinServer-main"))
            {
                MessageBox.Show("LawinServer already installed! Try Reinstall/Update");
            }
            else if (!Directory.Exists("LauncherData/LawinServer/LawinServer-main"))
            {
                DownloadServer downloadServer = new DownloadServer();
                downloadServer.DownloadGit();
            }
        }
    }
}
