using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortniteLauncher.Server
{
    public static class UpdateStatus
    {
        public static void UpdateCurrentStatus(string TextToDisplay)
        {
            MainWindow main = new MainWindow();
            main.CurrentStatus.Text = TextToDisplay;
        }
    }
}
