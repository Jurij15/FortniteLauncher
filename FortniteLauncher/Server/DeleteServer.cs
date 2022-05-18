using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace FortniteLauncher.Server
{
    public class DeleteServer
    {
        public void DeleteSRV()
        {
            if (!Directory.Exists("LauncherData/LawinServer/LawinServer-main"))
            {
                MessageBox.Show("LawinServer is not installed! Try clicking Install button");
            }
            else if (Directory.Exists("LauncherData/LawinServer/LawinServer-main"))
            {
                Directory.Delete("LauncherData/LawinServer/LawinServer-main", true);
            }
        }
    }
}
