using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModernWpf;
using ModernWpf.Controls;
using System.Threading.Tasks;

namespace FortniteLauncher.Common
{
    public static class dialog
    {
        public static void ShowDialog(string Title, string content, string OKButtonText)
        {
            ContentDialog dialog = new ContentDialog();
            dialog.Title = Title;
            dialog.Content = content;
            dialog.CloseButtonText = OKButtonText;
            dialog.ShowAsync();
        }
    }
}
