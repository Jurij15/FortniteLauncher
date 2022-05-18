using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using FortniteLauncher.Cores;
using System.Windows;

namespace FortniteLauncher.Server
{
    public class InstallDependencies
    {
        public void Packages()
        {
            UpdateStatus.UpdateCurrentStatus("Installing dependencies...");
            //Process.Start("LauncherData/LawinServer-main/install_packages.bat");
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Verb = "runas";
            p.StartInfo.Arguments = "/C cd LauncherData/LawinServer/LawinServer-main && install_packages.bat";
            p.Start();
            UpdateStatus.UpdateCurrentStatus("Ready to start!");
        }
    }
}
