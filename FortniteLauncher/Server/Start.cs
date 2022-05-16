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
            Process.Start("LauncherData/LawinServer-main/start.bat");
        }
    }
}
