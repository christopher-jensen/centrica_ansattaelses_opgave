using client.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ViewModel.Interfaces;
using ViewModel.Services;

namespace client.ViewModel
{
    public class AllDistrictsViewModel : INotifyPropertyChanged
        {

        private readonly IDistrictService _districtService;

        //public DistrictViewModel(IDistrictService districtService)
        //{
        //    _districtService = districtService;
        //}
        private ObservableCollection<District> _districts;
        public AllDistrictsViewModel()
        {
            _districtService = new DistrictService();
            LoadDistricts();
        }

        public ObservableCollection<District>? Districts { get => _districts; set
            {
                if (value != _districts) { 
                    _districts = value;
                    RaisePropertyChanged("Districts");
                }
            }
        }

        private async void LoadDistricts()
        {
            try
            {
                var districts = await _districtService.GetDistricts();
                ObservableCollection<District> districtsCollection = new ObservableCollection<District>(districts);
                Districts = districtsCollection;
            } catch (Exception ex)
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
