using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FortniteLauncher.Cores;
using System.IO;
using System.Net;
using System.Windows;

namespace FortniteLauncher.Server
{
    public class DownloadServer
    {
        public void DownloadGit()
        {
                UpdateStatus.UpdateCurrentStatus("Downloading server...");
                AppPaths appPaths = new AppPaths();
                WebClient wc = new WebClient();
                wc.DownloadFile(AppPaths.LawinGit, AppPaths.LauncherTemp);
                ExtractZIP exzip = new ExtractZIP();
                exzip.ZIP();
        }
    }
}
