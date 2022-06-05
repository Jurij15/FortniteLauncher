using System;
using System.Text;

namespace FortniteLauncher
{
    public class Version
    {
        //version number
        public static string VersionOnly = "1.0.0.0";
        //version type (Release, preview,...)
        public static string VersionType = "Beta2";
        //anything else
        public static string VersionNotes = "test";
        //full version string
        public static string VersionFull = Version.VersionOnly + "-" + Version.VersionType + "-" + Version.VersionNotes;
    }
}
