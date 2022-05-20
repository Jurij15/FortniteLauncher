﻿using System;
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

namespace FortniteLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ///FortniteGame/Binaries/Win64/FortniteLauncher.exe
        public string DefaultFNPath = "/FortniteGame/Binaries/Win64/FortniteLauncher.exe";
        public string path { get; set; }
        public string serverON { get; set; }
        public string ISfsOK { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            OnStartup.Start();
            /*
            CheckFileSystem checkFileSystem = new CheckFileSystem();
            checkFileSystem.CheckFS();

            if (ISfsOK == "true")
            {
                StatusIcon.Fill = new SolidColorBrush(System.Windows.Media.Colors.LightGreen);
            }
            else if (ISfsOK == "false")
            {
                StatusIcon.Fill = new SolidColorBrush(System.Windows.Media.Colors.Red);
            }
            */
            VersionBox.Text = Version.VersionFull;
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
            if (PartiesCheckBox.IsChecked == true)
            {
                PartiesXMPP p = new PartiesXMPP();
                p.DisableParties();
            }
            else if (PartiesCheckBox.IsChecked == false)
            {
                //nothing, countiniue
            }
            Environment.Exit(0);
        }

        private void DisBtn_Click(object sender, RoutedEventArgs e)
        {

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
            Start start = new Start();
            start.StartServer();
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
    }
}
