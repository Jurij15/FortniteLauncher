using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FortniteLauncher.Cores;
using System.IO;
using System.Windows;

namespace FortniteLauncher.Server
{
    public class PartiesXMPP
    {
        public void EnableParties()
        {
            if (!File.Exists("LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini"))
            {
                MessageBox.Show("Install/Reinstall LawinServer first!");
            }
            else if (File.Exists("LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini"))
            {
                File.Move("LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini", "LauncherData/LawinServer/Original.ini");
                File.Move(AppPaths.PartiesXMPP, "LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini");
            }
        }
        public void DisableParties()
        {
            if (!File.Exists("LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini"))
            {
                MessageBox.Show("Install/Reinstall LawinServer first!");
            }
            else if (File.Exists("LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini"))
            {
                File.Move("LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini", "LauncherData/LawinServer/PartiesXMPP.ini");
                File.Move("LauncherData/LawinServer/Original.ini", "LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini");
            }
        }
    }
}
