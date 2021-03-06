using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FortniteLauncher.Cores;
using System.IO;
using System.Windows;
using ModernWpf.Controls;

namespace FortniteLauncher.Server
{
    public class PartiesXMPP
    {
        public void EnableParties()
        {
            MainWindow main = new MainWindow();
            if (!File.Exists("LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini"))
            {
                //MessageBox.Show("Install/Reinstall LawinServer first!");
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Error";
                dialog.Content = "Install/Reinstall LawinServer first!";
                dialog.CloseButtonText = "OK";
                dialog.ShowAsync();
                main.PartiesCheckBox.IsChecked = false;
            }
            else if (File.Exists("LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini"))
            {
                File.Move("LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini", "LauncherData/LawinServer/Original.ini");
                File.Move(AppPaths.PartiesXMPP, "LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini");
            }
        }
        public void DisableParties()
        {
            MainWindow main = new MainWindow();
            if (!File.Exists("LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini"))
            {
                //MessageBox.Show("Install/Reinstall LawinServer first!");
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Error";
                dialog.Content = "Install/Reinstall LawinServer first!";
                dialog.CloseButtonText = "OK";
                dialog.ShowAsync();
                main.PartiesCheckBox.IsChecked = false;
            }
            else if (File.Exists("LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini"))
            {
                File.Move("LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini", "LauncherData/LawinServer/PartiesXMPP.ini");
                File.Move("LauncherData/LawinServer/Original.ini", "LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini");
            }
        }
    }
}
