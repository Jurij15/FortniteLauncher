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
using FortniteLauncher.Cores.FortniteLaunch;
using FortniteLauncher.Cores;
using System.Diagnostics;

namespace FortniteLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ///FortniteGame/Binaries/Win64/FortniteLauncher.exe
        public string DefaultFNPath = "/FortniteGame/Binaries/Win64/FortniteClient-Win64-Shipping.exe";
        public static string LaunchFNPath { get; set; }
        public string path { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            //OnStartup.Start();
        }

        private void ExploreBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            path = folderBrowserDialog.SelectedPath;
            PathBOx.Text = folderBrowserDialog.SelectedPath;
            //i give up on this
            /*
            string imageath = path + "/FortniteGame/Content/Splash/Splash.bmp";
            System.Windows.MessageBox.Show(imageath);
            Bitmap bmp = new Bitmap(imageath);
            //convert the .bmp image to .png and display it normally
            System.Drawing.Image image1 = System.Drawing.Image.FromFile(imageath);
            image1.Save(imageath, System.Drawing.Imaging.ImageFormat.Png);
            //display the image
            string newimage = path + "/FortniteGame/Content/Splash/Splash.png";
            //SeasonImage.Source = new BitmapImage(new Uri(imageath, UriKind.Relative));
            */
        }

        private void LaunchBtn_Click(object sender, RoutedEventArgs e)
        {
            /*
            Launch1_5 launch1_5 = new Launch1_5();
            if (Client_onetofilve.IsChecked == true)
            {
                launch1_5.launchFN();
            }
            */
            Launch launch = new Launch();
            //launch.BeforeStart();
            MainWindow mainWindow = new MainWindow();
            Process FNprocess = new Process();
            string pathfromuser = PathBOx.Text;
            string fullpath = pathfromuser + DefaultFNPath;
            FNprocess.StartInfo.Arguments = "-epicapp=Fortnite -epicenv=Prod -epicportal -epiclocale=en-us -skippatchcheck -NOSSLPINNING -FORCECONSOLE";
            FNprocess.StartInfo.FileName = fullpath;
            System.Windows.MessageBox.Show(fullpath);
            FNprocess.Start();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
