using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.IO.Compression;
using ModernWpf;
using ModernWpf.Controls;

namespace FortniteLauncher.Cores.RaiderGameserver
{
    public class Download_UpdateDLL
    {
        public void DownloadDLL()
        {
            try
            {
                if (!File.Exists(AppPaths.RaiderDeleteDLLLocation))
                {
                    WebClient wc = new WebClient();
                    wc.DownloadFile(AppPaths.RaiderGitMSBUILD, AppPaths.RaiderTemp);
                    ZipFile.ExtractToDirectory(AppPaths.RaiderTemp, AppPaths.RaiderDLL);
                    File.Delete(AppPaths.RaiderPDB);
                    ContentDialog proxywarningdialog = new ContentDialog();
                    proxywarningdialog.Title = "Done";
                    proxywarningdialog.Content = "DLL has been succesfully updated!";
                    proxywarningdialog.CloseButtonText = "OK";
                    proxywarningdialog.ShowAsync();
                }
                else if (File.Exists(AppPaths.RaiderDeleteDLLLocation))
                {
                    File.Delete(AppPaths.RaiderDeleteDLLLocation);
                    File.Delete(AppPaths.RaiderPDB);
                    WebClient wc = new WebClient();
                    wc.DownloadFile(AppPaths.RaiderGitMSBUILD, AppPaths.RaiderTemp);
                    ZipFile.ExtractToDirectory(AppPaths.RaiderTemp, AppPaths.RaiderDLL);
                    File.Delete(AppPaths.RaiderPDB);
                    ContentDialog proxywarningdialog = new ContentDialog();
                    proxywarningdialog.Title = "Done";
                    proxywarningdialog.Content = "DLL has been succesfully updated!";
                    proxywarningdialog.CloseButtonText = "OK";
                    proxywarningdialog.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                ContentDialog proxywarningdialog = new ContentDialog();
                proxywarningdialog.Title = "Error";
                proxywarningdialog.Content = "Cannot download raider from GitHub!" + ex.Message + ex.InnerException;
                proxywarningdialog.CloseButtonText = "OK";
                proxywarningdialog.ShowAsync();
            }
        }
    }
}
