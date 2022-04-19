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

namespace FortniteLauncher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string path { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            OnStartup.Start();
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
    }
}
