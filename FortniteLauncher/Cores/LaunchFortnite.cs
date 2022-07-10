using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FortniteLauncher.Cores
{
    public static  class LaunchFortnite
    {
        //moving it to here
        public static void Launch(string path, string username, bool UseSSLBypass, bool usePlatanium, bool UseLogging, bool suspenBE, bool suspendEAC)
        {
            Process FNprocess = new Process();
            string fullpath = path + "/FortniteGame/Binaries/Win64/FortniteClient-Win64-Shipping.exe";
            FNprocess.StartInfo.Arguments = $"-epicapp=Fortnite -AUTH-TYPE=externalauthtoken -AUTH_LOGIN={username} -epicusername={username} -AUTH_PASSWORD=password -epicenv=Prod -epicportal -epiclocale=en-us -skippatchcheck -NOSSLPINNING -FORCECONSOLE";
            FNprocess.StartInfo.FileName = fullpath;
            FNprocess.StartInfo.UseShellExecute = true;
            FNprocess.StartInfo.RedirectStandardOutput = true;
            //System.Windows.MessageBox.Show(fullpath);
            FNprocess.Start();
            MainWindow mainWindow = new MainWindow();
            mainWindow.FNPID = FNprocess.Id;
            if (UseLogging == true)
            {
                AsyncStreamReader asyncOutputReader = new AsyncStreamReader(FNprocess.StandardOutput);
                asyncOutputReader.DataReceived += delegate (object sender, string data)
                {
                    Console.WriteLine(data);
                };
                asyncOutputReader.Start();
            }
            if (UseSSLBypass == true)
            {
                if (usePlatanium == true)
                {
                    InjectSSLbypass.InjectDll(FNprocess.Id, "LauncherData/Platanium.dll");
                }
                else if (usePlatanium == false)
                {
                    InjectSSLbypass.InjectDll(FNprocess.Id, "LauncherData/AuroraNative.dll");
                }
            }
        }
    }
}
