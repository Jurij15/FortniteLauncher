using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using FortniteLauncher.Common.Functions;
using System.Runtime.InteropServices;

namespace FortniteLauncher.Common
{
    public class Global
    {
        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();
        public static int FNPID;
        public static bool EnableLogging = true;

        public static string FortnitePath;
        public static string Username { get; set; }

        public static bool HasStartedLawinServer = false;
        public static int LawinServerPID;
        public static string Status = null;

        public static bool ExtractZIP(string ZIPpath, string extractPath)
        {
            try
            {
                ZipFile.ExtractToDirectory(ZIPpath, extractPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static void SetCurrentStatus(string StatusText)
        {
            Status = StatusText;
        }

        public static string GetCurrentStatus()
        {
            return Status;
        }

        public static void SetupConsole()
        {
            AllocConsole();
        }

        public static ServerFunctions server;
        public static FortniteFunctions fortnite;
        public static RaiderFunctions raider;
        public static ConsoleFunctions console;
        public static ConfigsFunctions configs;
        public static ConfigsFunctions.UsernameFunctions username;
    }
}
