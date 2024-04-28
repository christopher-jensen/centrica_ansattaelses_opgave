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
    public partial class AllDistrictsView : UserControl
    {
        public AllDistrictsView()
        {
            InitializeComponent();
            this.DataContext = new AllDistrictsViewModel();
        }

        public void GetDistrict(Object sender, RoutedEventArgs e)
        {
            var districtName = ((Button)sender).Tag;
            MessageBox.Show(districtName.ToString());
        }
    }
}
