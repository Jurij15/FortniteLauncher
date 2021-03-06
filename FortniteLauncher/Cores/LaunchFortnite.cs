using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using ModernWpf;
using ModernWpf.Controls;

namespace FortniteLauncher.Cores
{
    public static  class LaunchFortnite
    {
        //moving it to here
        public static void Launch(string path, string username, bool UseSSLBypass, bool usePlatanium, bool UseLogging, bool suspendBE, bool suspendEAC)
        {
            string shipping = "/FortniteGame/Binaries/Win64/FortniteClient-Win64-Shipping.exe";
            string be = path + "/FortniteGame/Binaries/Win64/FortniteClient-Win64-Shipping_BE.exe";
            string eac = path + "/FortniteGame/Binaries/Win64/FortniteClient-Win64-Shipping_EAC.exe";
            string arguments = $"-epicapp=Fortnite -noeac -nobe -AUTH-TYPE=externalauthtoken -AUTH_LOGIN={username} -epicusername={username} -AUTH_PASSWORD=password -epicenv=Prod -epicportal -epiclocale=en-us -skippatchcheck -NOSSLPINNING -FORCECONSOLE";
            Process FNprocess = new Process();
            string fullpath = path + shipping;
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
            if (suspendEAC)
            {
                Process eacprocess = new Process();
                eacprocess.StartInfo.FileName = eac;
                eacprocess.StartInfo.UseShellExecute = true;
                if (!File.Exists(eac))
                {
                    ContentDialog proxywarningdialog = new ContentDialog();
                    proxywarningdialog.Title = "Error";
                    proxywarningdialog.Content = "Cannot suspend EAC!";
                    proxywarningdialog.CloseButtonText = "OK";
                    proxywarningdialog.ShowAsync();
                }
                else if (File.Exists(eac))
                {
                    eacprocess.Start();
                    Win32.Suspend("FortniteClient-Win64-Shipping_EAC");
                }
            }
            else if (suspendBE)
            {
                Process beprocess = new Process();
                beprocess.StartInfo.FileName = be;
                beprocess.StartInfo.UseShellExecute = true;
                if (!File.Exists(eac))
                {
                    ContentDialog proxywarningdialog = new ContentDialog();
                    proxywarningdialog.Title = "Error";
                    proxywarningdialog.Content = "Cannot suspend BE!";
                    proxywarningdialog.CloseButtonText = "OK";
                    proxywarningdialog.ShowAsync();
                }
                else if (File.Exists(eac))
                {
                    beprocess.Start();
                    Win32.Suspend("FortniteClient-Win64-Shipping_BE.exe");
                }
            }
        }
    }
}
