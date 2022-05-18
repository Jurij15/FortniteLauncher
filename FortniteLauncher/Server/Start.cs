using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace FortniteLauncher.Server
{
    public class Start
    {
        public void StartServer()
        {
            //Process.Start("LauncherData/LawinServer-main/start.bat");
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Arguments = "/C cd LauncherData/LawinServer/LawinServer-main && start.bat";
            p.StartInfo.Verb = "runas";
            p.Start();
            
        }
    }
}
