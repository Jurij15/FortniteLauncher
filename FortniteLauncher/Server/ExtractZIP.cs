using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using FortniteLauncher.Cores;

namespace FortniteLauncher.Server
{
    public class ExtractZIP
    {
        public void ZIP()
        {
            UpdateStatus.UpdateCurrentStatus("Extracting files...");
            ZipFile.ExtractToDirectory(AppPaths.LauncherTemp, AppPaths.LawinServerDefaultDir);
            InstallDependencies installDependencies = new InstallDependencies();
            installDependencies.Packages();
        }
    }
}
