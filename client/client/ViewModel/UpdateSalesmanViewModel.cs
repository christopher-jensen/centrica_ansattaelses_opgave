using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ViewModel.Interfaces;
using ViewModel.Services;

namespace client.ViewModel
{
    public class UpdateSalesmanViewModel : INotifyPropertyChanged
    {
        private int _salesmanId;
        private string _district;
        private bool _isMain;
        IDistrictService _districtService;
        public UpdateSalesmanViewModel(int salesmanId)
        {
            UpdateSalesmanCommand = new RelayCommand(UpdateSalesman);
            _districtService = new DistrictService();
            _salesmanId = salesmanId;
        }
        public Action CloseAction { get; set; }
        public ICommand UpdateSalesmanCommand { get; private set; }
        public string District
        {
            get => _district; set
            {
                if (value != _district) {
                    _district= value;
                    RaisePropertyChanged("District");
                }
            }
        }
        public bool IsMain
        {
            get => _isMain; set
            {
                if (value != _isMain)
                {
                    _isMain = value;
                    RaisePropertyChanged("IsMain");
                }
            }
        }

        private async void UpdateSalesman()
        {
            try
            {
                await _districtService.UpdateSalesman(_salesmanId, IsMain, District);
                MessageBox.Show("Success! Updated Salesman district");
                CloseAction();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
