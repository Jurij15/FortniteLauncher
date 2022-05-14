using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace FortniteLauncher.Cores
{
    public class CheckServer
    {
        //this will check if server is running
        //not using atm
        public void CServer()
        {
            MainWindow main = new MainWindow();
            Process[] processes = Process.GetProcessesByName("LawinServer");
            if (processes.Length == 0)
            {

                main.serverON = "false";
            }
            else
            {

                main.serverON = "true";
            }
        }
    }
}
