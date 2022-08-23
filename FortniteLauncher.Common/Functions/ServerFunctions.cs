using ModernWpf.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FortniteLauncher.Common.Functions
{
    public class ServerFunctions
    {
        public static class Parties
        {
            public static bool EnableParties()
            {
                if (!File.Exists("LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini"))
                {
                    dialog.ShowDialog("Error", "You must install LawinServer first!", "OK");
                    return false;
                }
                else if (File.Exists("LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini"))
                {
                    File.Move("LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini", "LauncherData/LawinServer/Original.ini");
                    File.Move(Strings.PartiesXMPP, "LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini");
                    return true;
                }
                return false;
            }
            public static bool DisableParties()
            {
                if (!File.Exists("LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini"))
                {
                    dialog.ShowDialog("Error", "You must install LawinServer first!", "OK");
                    return false;
                }
                else if (File.Exists("LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini"))
                {
                    File.Move("LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini", "LauncherData/LawinServer/PartiesXMPP.ini");
                    File.Move("LauncherData/LawinServer/Original.ini", "LauncherData/LawinServer/LawinServer-main/CloudStorage/DefaultEngine.ini");
                    return true;
                }
                return false;
            }
        }
        public static void DeleteServer()
        {
            if (!Directory.Exists("LauncherData/LawinServer/LawinServer-main"))
            {
                dialog.ShowDialog("Error", "LawinServer isn't installed!", "OK");
            }
            else if (Directory.Exists("LauncherData/LawinServer/LawinServer-main"))
            {
                Directory.Delete("LauncherData/LawinServer/LawinServer-main", true);
            }
        }

        public static void DownloadServer()
        {
            WebClient wc = new WebClient();
            wc.DownloadProgressChanged += wc_DownloadProgressChanged;
            wc.DownloadFile(Strings.LawinGit, Strings.LauncherTemp);
            Global.ExtractZIP(Strings.LauncherTemp, Strings.LawinServerDefaultDir);
        }

        public static void InstallAllDependencies()
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.Verb = "runas";
            p.StartInfo.Arguments = "/C cd LauncherData/LawinServer/LawinServer-main && install_packages.ba";
            p.Start();
        }

        public static void PrepServerInstall()
        {
            if (Directory.Exists("LauncherData/LawinServer/LawinServer-main"))
            {
                dialog.ShowDialog("Error", "LawinServer is already Installed!", "OK");
            }
            else if (!Directory.Exists("LauncherData/LawinServer/LawinServer-main"))
            {
                DownloadServer();
            }
        }

        public void Reinstall()
        {
            if (!Directory.Exists("LauncherData/LawinServer/LawinServer-main"))
            {
                dialog.ShowDialog("Error", "LawinServer is not installed", "OK");
            }
            else if (Directory.Exists("LauncherData/LawinServer/LawinServer-main"))
            {
                DeleteServer();
                PrepServerInstall();
            }
        }

        public static void FixPort80()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.Verb = "runas";
            cmd.StartInfo.Arguments = "/C net stop http";
            cmd.Start();
        }

        static void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

        }
    }
}
