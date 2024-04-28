﻿using System;
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
using client.View;
using client.ViewModel;
using ViewModel.Interfaces;

namespace client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly IDistrictService _districtService;
        //private readonly DistrictViewModel _districtViewModel;  

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AllDistrictsViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            //AllDistrictsViewModel districtViewModelObject =
            //    new AllDistrictsViewModel();
            ////int res = await districtViewModelObject.LoadDistrictsHardCoded();
            //districtViewModelObject.LoadDistricts();
            //AllDistrictsViewControl.DataContext = districtViewModelObject;
            //if (res == 0)
            //{
            //    Console.WriteLine("shit");
            //}
            //else
            //{
            //    DistrictViewControl.DataContext = districtViewModelObject;
            //}
        }
        private void ExitButton(object sender, RoutedEventArgs e)
        {
            var allDistrictView = new AllDistrictsView();

            Switcher.Navigate(allDistrictView);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Switcher.Initialize(this);
            Switcher.Navigate(new AllDistrictsView()); // Show the initial page
        }

    }
}
