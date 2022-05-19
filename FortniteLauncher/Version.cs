using System;
using System.Text;

namespace FortniteLauncher
{
    public class Version
    {
        //version number
        public static string VersionOnly = "1.0.0.0";
        //version type (Release, preview,...)
        public static string VersionType = "Debug";
        //anything else
        public static string VersionNotes = "Full";
        //full version string
        public static string VersionFull = Version.VersionOnly + "-" + Version.VersionType + "-" + Version.VersionNotes;
    }
}
