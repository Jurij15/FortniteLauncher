using System;

namespace FortniteLauncher.Cores
{
    public class AppPaths
    {
        //app paths
        public static string DefaultDir = "LauncherData/";
        public static string LawinServerDefaultDir = "LauncherData/";
        public static string LauncherTemp = "LauncherData/Temp";
        public static string PartiesXMPP = "LauncherData/PartiesXMPP.ini";
        public static string Depencencies = "LauncherData/LawinServer-Main/install_packages.bat";

        //lawinserver git string
        public static string LawinGit = "https://github.com/Lawin0129/LawinServer/archive/refs/heads/main.zip";

        //fortnite paths
        /*
        MainWindow mainWindow = new MainWindow();
        public static string DefaultFNPath = "/FortniteGame/Binaries/Win64/FortniteLauncher.exe";
        public static string LaunchFNPath { get; set; }
        public static void GetPath()
        {
            MainWindow mainWindow = new MainWindow();
            string userpath = mainWindow.path;
            LaunchFNPath = userpath + DefaultFNPath;
        }
        */
    }
}
