using System;
using System.Text;

namespace FortniteLauncher
{
    public class Version
    {
        //version number
        public static string VersionOnly = "1.0.0.1";
        //version type (Release, preview,...)
        public static string VersionType = "release";
        //anything else
        public static string VersionNotes = "final";
        //full version string
        public static string VersionFull = Version.VersionOnly + "-" + Version.VersionType + "-" + Version.VersionNotes;
    }
}
