using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.Windows;
using System.Drawing;
using System.Diagnostics;
using FortniteLauncher.Cores;
using FortniteLauncher.Server;
using System.Threading;
using System.Runtime.InteropServices;
using ModernWpf;
using ModernWpf.Controls;
using FortniteLauncher.Cores.RaiderGameserver;
using System.IO;

namespace FortniteLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ///FortniteGame/Binaries/Win64/FortniteLauncher.exe <summary>
        /// FortniteGame/Binaries/Win64/FortniteClient-Win64-Shipping.exe
        /// </summary>
        public string DefaultFNPath = "/FortniteGame/Binaries/Win64/FortniteClient-Win64-Shipping.exe";
        public string path { get; set; }
        public bool serverOn = false;
        public string ISfsOK { get; set; }
        public int FNPID;

        [DllImport("kernel32.dll", EntryPoint = "AllocConsole", SetLastError = true, CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();
        public MainWindow()
        {
            InitializeComponent();
            OnStartup.Start();
            VersionBox.Text = Version.VersionFull;
            if (Version.VersionFull.Contains("Preview"))
            {
                TestingWelcome t = new TestingWelcome();
                t.ShowDialog();
                testingmessageblock.Visibility = Visibility.Visible;
            }
            else if (!Version.VersionFull.Contains("Preview"))
            {
                testingmessageblock.Visibility = Visibility.Hidden;
            }
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
            DarkModeBtn.IsChecked = true;
            PartiesCheckBox.IsChecked = false;
            SeasonImage.Visibility = Visibility.Collapsed;
            Username_box.Text = Username.UsernameString();
            //show or hide the player tab (until i get it working
            PlayerTab.Visibility = Visibility.Collapsed;
        }

        private void ExploreBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            path = folderBrowserDialog.SelectedPath;
            PathBOx.Text = folderBrowserDialog.SelectedPath;
        }

        private void LaunchBtn_Click(object sender, RoutedEventArgs e)
        {
            //this process thing doesnt work properly, i just wont bother to fix it
            /*
            Process[] existingprocessmaybe = Process.GetProcessesByName("Fortnite");
            if (existingprocessmaybe.Length == 0)
            {
                MainWindow mainWindow = new MainWindow();
                Process FNprocess = new Process();
                string pathfromuser = PathBOx.Text;
                string fullpath = pathfromuser + DefaultFNPath;
                FNprocess.StartInfo.Arguments = "-epicapp=Fortnite -epicenv=Prod -epicportal -epiclocale=en-us -skippatchcheck -NOSSLPINNING -FORCECONSOLE";
                FNprocess.StartInfo.FileName = fullpath;
                FNprocess.StartInfo.UseShellExecute = false;
                FNprocess.StartInfo.RedirectStandardOutput = true;
                //System.Windows.MessageBox.Show(fullpath);
                //AllocConsole();
                FNprocess.Start();
                //inject a ssl bypass dll from nyamimi

                AsyncStreamReader asyncOutputReader = new AsyncStreamReader(FNprocess.StandardOutput);
                asyncOutputReader.DataReceived += delegate (object sender, string data)
                {
                    Console.WriteLine(data);
                };

                asyncOutputReader.Start();
                FNPID = FNprocess.Id;
                InjectSSLbypass.InjectDll(FNprocess.Id, "LauncherData/AuroraNative.dll");
            }
            else
            {
                ContentDialog dialog = new ContentDialog();
                dialog.Title = "Fortnite already running!";
                dialog.Content = "Please Close fortnite and try again!";
                dialog.CloseButtonText = "OK";
                dialog.ShowAsync();
            }
            */
            //moved to launchfortnite.cs
            if (SuspendBECheckBox.IsChecked == true && SuspendEACCheckBox.IsChecked == true)
            {
                LaunchFortnite.Launch(PathBOx.Text, null, true, false, true, true, true);
            }
            else if (SuspendBECheckBox.IsChecked == true)
            {
                LaunchFortnite.Launch(PathBOx.Text, null, true, false, true, true, false);
            }
            else if (SuspendEACCheckBox.IsChecked == true)
            {
                LaunchFortnite.Launch(PathBOx.Text, null, true, false, true, false, true);
            }
            else
            {
                LaunchFortnite.Launch(PathBOx.Text, null, true, false, true, false, false);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (PartiesCheckBox.IsChecked == true)
            {
                PartiesXMPP p = new PartiesXMPP();
                p.DisableParties();
            }
            else if (PartiesCheckBox.IsChecked == false)
            {
                //nothing, countiniue
            }
            else if (IncludedProxyUSE.IsChecked == true)
            {
                Process[] proxyprocess = Process.GetProcessesByName("LawinServerProxy.exe");
                proxyprocess[0].Kill();
                proxyprocess[0].Dispose();
                proxyprocess[0].Close();
            }
            else if (IncludedProxyUSE.IsChecked == false)
            {

            }
            Environment.Exit(0);
        }

        private void DisBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //from https://iqcode.com/code/csharp/c-open-web-page-in-default-browser

                var uri = "https://discord.gg/AtXKh4rZCt";
                var psi = new System.Diagnostics.ProcessStartInfo();
                psi.UseShellExecute = true;
                psi.FileName = uri;
                System.Diagnostics.Process.Start(psi);
                //Process.Start("https://discord.gg/AtXKh4rZCt");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void PathBOx_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (PathBOx.Text == "")
            {
                //nothing
            }
            else if (PathBOx.Text != "")
            {
                string bmppath = PathBOx.Text + "/FortniteGame/Content/Splash/Splash.bmp";
                Bitmap bitmap = new Bitmap(bmppath);
                //ImageSource imgsource = new BitmapImage(new Uri(bmppath));
                SeasonImage.Source = new BitmapImage(new Uri(bmppath));

            }
        }

        private void InstallLawinBtn_Click(object sender, RoutedEventArgs e)
        {
            InstallServer install = new InstallServer();
            install.Install();
        }

        private void ReinstallUpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            ReinstallServer reinstallServer = new ReinstallServer();
            reinstallServer.Reinstall();
        }

        private void DeleteServerBtn_Click(object sender, RoutedEventArgs e)
        {
            DeleteServer delser = new DeleteServer();
            delser.DeleteSRV();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IncludedProxyUSE.IsChecked == true)
            {
                Process.Start(AppPaths.IncludedProxy);
                Start start = new Start();
                start.StartServer();
            }
            else if (IncludedProxyUSE.IsChecked == false)
            {
                Start start = new Start();
                start.StartServer();
            }
        }

        private void FixBtn_Click(object sender, RoutedEventArgs e)
        {
            ServerNotStartingFIx serverNotStartingFIx = new ServerNotStartingFIx();
            serverNotStartingFIx.FIX();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PartiesXMPP partiesXMPP = new PartiesXMPP();
            partiesXMPP.EnableParties();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PartiesXMPP partiesXMPP = new PartiesXMPP();
            partiesXMPP.DisableParties();
        }

        private void IncludedProxyUSE_Checked(object sender, RoutedEventArgs e)
        {
            //System.Windows.MessageBox.Show("WARNING! Using this Proxy may cause instability and Fortnite disconnecting from server! Rather use Fiddler!");
            /*
            ContentDialog proxywarningdialog = new ContentDialog();
            proxywarningdialog.Title = "Warning";
            proxywarningdialog.Content = "Using this Proxy may cause instability and Fortnite disconnecting from server! Rather use Fiddler!";
            proxywarningdialog.CloseButtonText = "OK";
            proxywarningdialog.ShowAsync();
            */
        }

        private void OpenFS_Click(object sender, RoutedEventArgs e)
        {
            OpenFSys open = new OpenFSys();
            open.OpenFSystem();
        }

        private void Lawinserver_github_link_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Uri.ToString());
        }

        private void OpenLGit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //from https://iqcode.com/code/csharp/c-open-web-page-in-default-browser

                var uri = "https://github.com/Jurij15/FortniteLauncher";
                var psi = new System.Diagnostics.ProcessStartInfo();
                psi.UseShellExecute = true;
                psi.FileName = uri;
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void LightModeBtn_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Light;
        }

        private void DarkModeBtn_Click(object sender, RoutedEventArgs e)
        {
            ThemeManager.Current.ApplicationTheme = ApplicationTheme.Dark;
        }

        private void SaveUsernameBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Username.SaveUsername(Username_box.Text))
            {
                //proceed
            }
            else if (!Username.SaveUsername(Username_box.Text))
            {
                ContentDialog proxywarningdialog = new ContentDialog();
                proxywarningdialog.Title = "Error";
                proxywarningdialog.Content = "Cannot save username!";
                proxywarningdialog.CloseButtonText = "OK";
                proxywarningdialog.ShowAsync();
            }
        }

        private void RaiderGitHubbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //from https://iqcode.com/code/csharp/c-open-web-page-in-default-browser

                var uri = "https://github.com/kem0x/raider3.5";
                var psi = new System.Diagnostics.ProcessStartInfo();
                psi.UseShellExecute = true;
                psi.FileName = uri;
                System.Diagnostics.Process.Start(psi);
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private void Download_UpdateRaiderBtn_Click(object sender, RoutedEventArgs e)
        {
            Download_UpdateDLL dll = new Download_UpdateDLL();
            dll.DownloadDLL();
        }

        //the button is called start fortnite, i just didnt change it
        private void InjectRaiderDLL_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.MessageBox.Show(Username.UsernameString());
            LaunchFortnite.Launch(Box3_5.Text, Username.UsernameString(), false, false, false, false, false);
        }

        private void RaiderExplore3_5btn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            path = folderBrowserDialog.SelectedPath;
            Box3_5.Text = folderBrowserDialog.SelectedPath;
        }

        private void InjectRaiderDLLBtn_Click(object sender, RoutedEventArgs e)
        {
            //will just reuse the ssl inject
            if (!File.Exists(AppPaths.RaiderDeleteDLLLocation))
            {
                ContentDialog proxywarningdialog = new ContentDialog();
                proxywarningdialog.Title = "Raider not found!";
                proxywarningdialog.Content = "Try clicking Install/Update DLL";
                proxywarningdialog.CloseButtonText = "OK";
                proxywarningdialog.ShowAsync();
            }
            else if (File.Exists(AppPaths.RaiderDeleteDLLLocation))
            {
                InjectSSLbypass.InjectDll(FNPID, AppPaths.RaiderDeleteDLLLocation); 
                ContentDialog proxywarningdialog = new ContentDialog();
                proxywarningdialog.Title = "Success!";
                proxywarningdialog.Content = "Raider injected!";
                proxywarningdialog.CloseButtonText = "OK";
                proxywarningdialog.ShowAsync();
            }
        }
    }
}
