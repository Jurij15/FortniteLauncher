using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using ModernWpf.Controls;

namespace FortniteLauncher.Server
{
    public class Start
    {
        public void StartServer()
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
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "/C cd LauncherData/LawinServer/LawinServer-main && start.bat";
                p.StartInfo.Verb = "runas";
                p.Start();
            }
            //Process.Start("LauncherData/LawinServer-main/start.bat");
        }
    }
}
