using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace FortniteLauncher.Cores
{
    public static class Downloader
    {
        public static void StartDownloader(string adress, string wheretodownload)
        {
            WebClient wc = new WebClient();
            wc.DownloadFile(adress, wheretodownload);
        }
    }
}
