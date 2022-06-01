using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using ModernWpf.Controls;

namespace FortniteLauncher.Server
{
    public class DeleteServer
    {
        public void DeleteSRV()
        {
                Directory.Delete("LauncherData/LawinServer/LawinServer-main", true);
        }
    }
}
