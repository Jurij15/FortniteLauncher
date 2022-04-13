using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using FortniteLauncher.Cores;

namespace FortniteLauncher
{
    public class OnStartup
    {
        public void Start()
        {
            if (!Directory.Exists(AppPaths.DefaultDir))
            {
                Directory.CreateDirectory(AppPaths.DefaultDir);
            }
            else if (!Directory.Exists(AppPaths.LawinServerDefaultDir))
            {
                Directory.CreateDirectory(AppPaths.LawinServerDefaultDir);
            }

        }
    }
}
