using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using FortniteLauncher.Cores;

namespace FortniteLauncher.Server
{
    public class InstallDependencies
    {
        public void Packages()
        {
            UpdateStatus.UpdateCurrentStatus("Installing dependencies...");
            Process p = new Process();
            p.StartInfo.FileName = AppPaths.Depencencies;
            p.Start();
            UpdateStatus.UpdateCurrentStatus("Ready to start!");
        }
    }
}
