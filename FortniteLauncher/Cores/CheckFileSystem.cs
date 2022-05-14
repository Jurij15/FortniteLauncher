using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FortniteLauncher.Cores
{
    public class CheckFileSystem
    {
        public void CheckFS()
        {
            MainWindow main = new MainWindow();
            if (!Directory.Exists(AppPaths.LawinServerDefaultDir))
            {
                main.ISfsOK = "true";
            }
            else
            {
                main.ISfsOK= "false";
            }
        }
    }
}
