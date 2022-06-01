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
            if (!Directory.Exists("LauncherData/LawinServer/LawinServer-main"))
            {
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Error";
                dialog.Content = "LawinServer is not installed! Try clicking Install button";
                dialog.CloseButtonText = "OK";
                dialog.ShowAsync();
            }
            else if (Directory.Exists("LauncherData/LawinServer/LawinServer-main"))
            {
                Directory.Delete("LauncherData/LawinServer/LawinServer-main", true);
            }
        }
    }
}
