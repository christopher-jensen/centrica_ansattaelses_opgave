using client.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using ViewModel.Interfaces;
using ViewModel.Services;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using client.View;

namespace client.ViewModel
{
    public class DistrictViewModel : INotifyPropertyChanged
    {
        private readonly IDistrictService _districtService;
        private readonly string _name;
        private ObservableCollection<Store> _stores;
        private ObservableCollection<Salesman> _salesmen;
        private Salesman _mainSm;
        private Salesman _selectedSalesman;

        public DistrictViewModel(string name)
        {
            _districtService = new DistrictService();
            _name = name;
            GetSalesmen(name);
            GetStores(name);
            GetMainSalesman(name);
            UpdateSalesmanCommand = new RelayCommand(UpdateSalesman);
        }
        public ICommand UpdateSalesmanCommand { get; private set; }

        public ObservableCollection<Store> Stores { get => _stores; set {
                if (value != _stores)
                {
                    _stores = value;
                    RaisePropertyChanged("Stores");
                }
            }
        }
        public ObservableCollection<Salesman> SalesMen
        {
            get => _salesmen; set
            {
                if (value != _salesmen)
                {
                    _salesmen = value;
                    RaisePropertyChanged("SalesMen");
                }
            }
        }

        public Salesman MainSm { get => _mainSm; set
            {
                if (value != _mainSm)
                {
                    _mainSm = value;
                    RaisePropertyChanged("MainSm");
                }
            }
        }

        public Salesman SelectedSalesman { get => _selectedSalesman; set
            {
                if (value != _selectedSalesman)
                {
                    _selectedSalesman = value;
                    RaisePropertyChanged("SelectedSalesman");
                }
            }
        }

        private void UpdateSalesman()
        {
            var window = new UpdateSalesmanView(SelectedSalesman.Id);
            window.Show();
        }
        private async void GetSalesmen(string name) {
            try
            {
                var salesMen = await _districtService.GetSalesmen(_name);
                ObservableCollection<Salesman> salesMenCollection = new ObservableCollection<Salesman>(salesMen);
                SalesMen = salesMenCollection;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void GetStores(string name)
        {
            try
            {
                var stores = await _districtService.GetStores(_name);
                ObservableCollection<Store> storeCollection = new ObservableCollection<Store>(stores);
                Stores = storeCollection;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void GetMainSalesman(string name)
        {
            try
            {
                var salesMan = await _districtService.GetMainSalesMan(_name);
                MainSm = salesMan;
                SelectedSalesman= salesMan;
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
