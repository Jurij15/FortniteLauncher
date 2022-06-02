using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FortniteLauncher.Cores;
using System.IO;
using System.Net;
using System.Windows;
using System.Threading;

namespace FortniteLauncher.Server
{
    public class DownloadServer
    {
        public void DownloadGit()
        {
            
             
                UpdateStatus.UpdateCurrentStatus("Downloading server...");
                AppPaths appPaths = new AppPaths();
                WebClient wc = new WebClient();
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFile(AppPaths.LawinGit, AppPaths.LauncherTemp);
                ExtractZIP exzip = new ExtractZIP();
                exzip.ZIP();
            
            //BtnDownload_Click();
        }

        /*
        public void BtnDownload_Click()
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += wc_DownloadProgressChanged;
                wc.DownloadFileAsync(
                    // Param1 = Link of file
                    new System.Uri(AppPaths.LawinGit),
                    // Param2 = Path to save
                    AppPaths.LauncherTemp
                );
            }
            Thread.Sleep(500);
            ExtractZIP exzip = new ExtractZIP();
            exzip.ZIP();
        }
        */
        // Event to track the progress
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.LoadProgBar.Value = e.ProgressPercentage;
        }
    }
}
