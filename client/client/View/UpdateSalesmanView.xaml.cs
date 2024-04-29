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
using System.Windows.Shapes;

namespace client.View
{
    /// <summary>
    /// Interaction logic for UpdateSalesmanView.xaml
    /// </summary>
    public partial class UpdateSalesmanView : Window
    {
        public UpdateSalesmanView(int salesmanId)
        {
            InitializeComponent();
            var viewModel = new UpdateSalesmanViewModel(salesmanId);
            if (viewModel.CloseAction == null) {
                viewModel.CloseAction = new Action(this.Close);
            }
            this.DataContext = viewModel;

        }
    }
}
