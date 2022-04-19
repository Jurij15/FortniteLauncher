using System;

namespace FortniteLauncher.Cores
{
    public class AppPaths
    {
        //app paths
        public static string DefaultDir = "LauncherData/";
        public static string LawinServerDefaultDir = "LauncherData/LawinServer";
        public static string LaunchersDir = "LauncherData/Launchers/";
        public static string Launcher_one_to_five = "LauncherData/Launchers/1-5Launch.bat";

        //fortnite paths
        MainWindow mainWindow = new MainWindow();
        public static string DefaultLauncherFNPath = "/FortniteGame/Binaries/Win64/Launcher.bat";
        public static string LauncherFNPath { get; set; }
        public static void GetPath()
        {
            MainWindow mainWindow = new MainWindow();
            string userpath = mainWindow.path;
            LauncherFNPath = userpath + DefaultLauncherFNPath;
        }
    }
}
