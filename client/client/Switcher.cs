using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace client
{
    public static class Switcher
    {
        private static MainWindow main;
        public static void Initialize(MainWindow mainWindow)
        {
            main = mainWindow;
        }
        public static void Navigate(UserControl page)
        {
            main.MainContentControl.Content = page;
        }
    }
}
