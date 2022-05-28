using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using ModernWpf.Controls;

namespace FortniteLauncher.Server
{
    public class InstallServer
    {
        public void Install()
        {
            if (Directory.Exists("LauncherData/LawinServer/LawinServer-main"))
            {
                
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Error";
                dialog.Content = "LawinServer already installed! Try reinstall/update!";
                dialog.CloseButtonText = "OK";
                dialog.ShowAsync();
            }
            else if (!Directory.Exists("LauncherData/LawinServer/LawinServer-main"))
            {
                DownloadServer downloadServer = new DownloadServer();
                downloadServer.DownloadGit();
            }
        }
    }
}
