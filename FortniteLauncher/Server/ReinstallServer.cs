using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FortniteLauncher.Cores;
using ModernWpf.Controls;

namespace FortniteLauncher.Server
{
    public class ReinstallServer
    {
        public void Reinstall() 
        {
            if (!Directory.Exists("LauncherData/LawinServer/LawinServer-main"))
            {
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Error";
                dialog.Content = "LawinServer is not installed! Try clicking Install button";
                dialog.CloseButtonText = "OK";
                dialog.ShowAsync();
            }
            else if (Directory.Exists("LauncherData/LawinServer/LawinServer-main"))
            {
                DeleteServer deleteServer = new DeleteServer();
                deleteServer.DeleteSRV();
                UpdateStatus.UpdateCurrentStatus("Deleted current installation!...");
                DownloadServer downloadServer = new DownloadServer();
                downloadServer.DownloadGit();
            }
        }
    }
}
