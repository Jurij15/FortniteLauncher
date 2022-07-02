using System;

namespace FortniteLauncher.Cores
{
    public class AppPaths
    {
        //app paths
        public static string DefaultDir = "LauncherData/";
        public static string LawinServerDefaultDir = "LauncherData/LawinServer";
        public static string LauncherTemp = "LauncherData/Temp";
        public static string PartiesXMPP = "LauncherData/LawinServer/PartiesXMPP.ini";
        public static string Depencencies = "LauncherData/LawinServer-Main/install_packages.bat";
        public static string IncludedProxy = "LauncherData/Proxy/LawinServerProxy.exe";
        public static string UsernameConfing = "LauncherData/Config/Username";

        //raider
        public static string RaiderDLL = "LauncherData/RaiderGameserver/";
        public static string RaiderTemp = "LauncherData/RaiderGameserver/Temp";
        public static string RaiderGitMSBUILD = "https://nightly.link/kem0x/raider3.5/workflows/msbuild/stable/Release.zip";
        public static string RaiderDeleteDLLLocation = "LauncherData/RaiderGameserver/Raider.dll";
        public static string RaiderPDB = "LauncherData/RaiderGameserver/Raider.pdb"; //will just delete, no real use for it

        //lawinserver git string
        public static string LawinGit = "https://github.com/Lawin0129/LawinServer/archive/refs/heads/main.zip";
    }
}
