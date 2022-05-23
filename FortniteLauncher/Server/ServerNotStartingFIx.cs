using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FortniteLauncher.Server
{
    public class ServerNotStartingFIx
    {
        public void FIX()
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Verb = "runas";
            p.StartInfo.Arguments = "/C net stop http";
            p.Start();
        }
    }
}
