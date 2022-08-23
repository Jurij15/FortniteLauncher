using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using FortniteLauncher.Common.Functions;

namespace FortniteLauncher.Common
{
    public class Global
    {
        public static int FNPID;
        public static bool EnableLogging = true;

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

        public static ServerFunctions server;
        public static FortniteFunctions fortnite;
        public static RaiderFunctions raider;
    }
}
