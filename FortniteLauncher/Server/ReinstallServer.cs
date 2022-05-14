using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteLauncher.Server
{
    public class ReinstallServer
    {
        public void Reinstall() 
        { 
            DeleteServer deleteServer = new DeleteServer();
            deleteServer.DeleteSRV();
            UpdateStatus.UpdateCurrentStatus("Deleted current installation!...");
            DownloadServer downloadServer = new DownloadServer();
            downloadServer.DownloadGit();
        }
    }
}
