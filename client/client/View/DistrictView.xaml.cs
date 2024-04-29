using client.ViewModel;
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

namespace client.View
{
    /// <summary>
    /// Interaction logic for DistrictView.xaml
    /// </summary>
    public partial class DistrictView : UserControl
    {
        public DistrictView(string name)
        { 
            InitializeComponent();
            this.DataContext = new DistrictViewModel(name);
        }
    }
}
