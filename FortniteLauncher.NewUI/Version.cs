using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteLauncher.NewUI
{
    public class Version
    {
        public static string versionNumber = "1.1.0.0";
        public static string type = "debug";
        public static string args = "dev";
        public static string VersionString =versionNumber + "-"+ type+"-"+args;
    }
}
