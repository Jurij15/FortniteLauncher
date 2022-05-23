using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using FortniteLauncher.Cores;

namespace FortniteLauncher.Server
{
    public class OpenFSys
    {
        public void OpenFSystem()
        {
            Process p = new Process();
            p.StartInfo.Arguments = "LauncherData/LawinServer/LawinServer-main";
            p.StartInfo.FileName = "explorer.exe";
            p.Start();
        }
    }
}
