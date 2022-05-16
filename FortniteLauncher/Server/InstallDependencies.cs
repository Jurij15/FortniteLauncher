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
            /*
            Process p = new Process();
            p.StartInfo.FileName = AppPaths.Depencencies;
            p.Start();
            */
            MessageBox.Show(AppPaths.Depencencies);
            //Process.Start("C:/Users/Jurij15/source/repos/FortniteLauncher/FortniteLauncher/bin/Debug/net6.0-windows10.0.18362.0/LauncherData/LawinServer-main/install_packages.bat");
            //above stuff didn't work properly, trying this now
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.ArgumentList.Add("/c");
            p.StartInfo.ArgumentList.Add("cd LauncherData/LawinServer-main/");
            p.StartInfo.ArgumentList.Add("install_packages.bat");
            p.Start();
            UpdateStatus.UpdateCurrentStatus("Ready to start!");
        }
    }
}
