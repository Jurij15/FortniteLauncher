using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using FortniteLauncher.Cores;
using System.Diagnostics;
using System.Windows;

namespace FortniteLauncher.Cores.FortniteLaunch
{
    public class Launch
    {
        MainWindow mainWindow = new MainWindow();
        public static string DefaultFNPath = "/FortniteGame/Binaries/Win64/FortniteLauncher.exe";
        public static string LaunchFNPath { get; set; }
        public static void GetPath()
        {
            MainWindow mainWindow = new MainWindow();
            string userpath = mainWindow.path;
            LaunchFNPath = userpath + DefaultFNPath;
        }
        public void BeforeStart()
        {
            Process[]FNExistingsProcess = Process.GetProcessesByName("FortniteClient-Win64-Shipping.exe");
            if (FNExistingsProcess.Length > 0)
            {
                MessageBox.Show("Close fortnite and try again!");
            }
            else
            {
                LaunchFN();
            }
        }
        public void LaunchFN()
        {
            AppPaths appPaths = new AppPaths();
            //set path
            GetPath();
            MainWindow mainWindow = new MainWindow();
            Process FNprocess = new Process();
            string userpath = mainWindow.PathBOx.Text;
            FNprocess.StartInfo.Arguments = "FortniteLauncher.exe -epicapp=Fortnite -epicenv=Prod -epicportal -epiclocale=en-us -skippatchcheck -NOSSLPINNING -FORCECONSOLE";
            FNprocess.StartInfo.FileName = userpath + DefaultFNPath;
            MessageBox.Show(userpath);
            FNprocess.Start();
        }
    }
}
