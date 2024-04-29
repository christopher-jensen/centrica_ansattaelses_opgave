using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModel.Interfaces;
using ViewModel.Services;

namespace client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    { 
        public static IHost? AppHost { get; private set; }

        public App()
        {
            // Used for dependensy injection to inject my service
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();
                    //services.AddTransient<IDistrictService, DistrictService>();
                }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            //var startupForm = AppHost.Services.GetRequiredService<MainWindow>();
            //startupForm.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            //await AppHost!.StopAsync();
            base.OnExit(e);
        }
    }
}
