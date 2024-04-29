using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace client
{
    /// <summary>
    /// Used to navigate the applitcaion
    /// </summary>
    public static class Switcher
    {
        private static MainWindow main;
        public static void Initialize(MainWindow mainWindow)
        {
            main = mainWindow;
        }
        /// <summary>
        /// Function to navigate to new User Control Page. Sets the current contentcontrol of the main window
        /// </summary>
        /// <param name="page">UserControl object of the page you wish to add to the main window</param>
        public static void Navigate(UserControl page)
        {
            main.MainContentControl.Content = page;
        }
    }
}
