using System;
using System.Collections.Generic;
using System.IO;
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
using FortniteLauncher.Common;
using System.Drawing;
using System.Windows.Shell;
using LogSharper;
using FortniteLauncher.Common.Functions;

namespace FortniteLauncher.NewUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ServerFunctions server;
        public FortniteFunctions fortnite;
        public RaiderFunctions raider;
        public ConsoleFunctions console;
        public ConfigsFunctions configs;
        public ConfigsFunctions.UsernameFunctions username;
        public void InsertNewLineIntoFortniteTabInfo(string text)
        {
            string currenttext = DynamicInfoTextBox.Text;
            if (currenttext=="")
            {
                DynamicInfoTextBox.Text = text;
            }
            else
            {
                DynamicInfoTextBox.Text = currenttext + Environment.NewLine + text;
            }
        }
        public void OnStartup()
        {
            if (Version.VersionString.Contains("debug")) //if version contains debug, console is enabled by default
            {
                Common.Global.SetupConsole();
                LogSharper.LogSharper.Setup(true);
                Logger.Info("Debug mode detected, console enabled");
            }
            DynamicInfoTextBox.Text = "";
            Logger.Info("Log cleared!");

            if (!Global.HasStartedLawinServer)
            {
                Logger.Warning("LawinServer was not started by the launcher!");
                InsertNewLineIntoFortniteTabInfo(Strings.LawinServerNotStartedWarning);
            }

            if (ConfigsFunctions.UsernameFunctions.UsernameString() == "")
            {
                ConfigsFunctions.UsernameFunctions.SaveUsername("Player");
            }

            UsernameBox.Text = ConfigsFunctions.UsernameFunctions.UsernameString();
            Global.Username = ConfigsFunctions.UsernameFunctions.UsernameString();
            Logger.Info("Set username!");
            Logger.Info(Global.Username);
        }
        public MainWindow()
        {
            InitializeComponent();
            OnStartup();
        }

        private void ExploreBtn_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            Global.FortnitePath= folderBrowserDialog.SelectedPath;
            FortnitePathBox.Text = folderBrowserDialog.SelectedPath;
        }

        private void FortnitePathBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FortnitePathBox.Text == "")
            {
                //nothing
            }
            else if (FortnitePathBox.Text != "")
            {
               string bmp = FortnitePathBox.Text + Strings.SplashScreenImage;
               Bitmap bitmap = new Bitmap(bmp);
               FortniteSplashImage.Source = new BitmapImage(new Uri(bmp));
            }
        }

        private void LaunchBtn_Click(object sender, RoutedEventArgs e)
        {
            FortniteFunctions.LaunchFortnite(FortnitePathBox.Text,Global.Username, true, false, false, false, false);
            InsertNewLineIntoFortniteTabInfo("[INFO]Fortnite was launched!");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
