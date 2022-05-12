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
            ZipFile.ExtractToDirectory(AppPaths.LawinGit, AppPaths.LawinServerDefaultDir);
        }
    }
}
