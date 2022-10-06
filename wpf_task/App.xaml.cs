﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using wpf_task.Data;
using wpf_task.Services;
using wpf_task.ViewModels;

namespace wpf_task
{
    public partial class App : Application
    {
        public static Window? ActiveWindow => Current.Windows
               .OfType<Window>()
               .FirstOrDefault(w => w.IsActive);

        public static Window? FocusedWindow => Current.Windows
           .OfType<Window>()
           .FirstOrDefault(w => w.IsFocused);

        public static Window? CurrentWindow => FocusedWindow ?? ActiveWindow;

        private static IHost? _Host;

        public static IHost Host => _Host
            ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Host.Services;
        
        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
            .AddDatabase(host.Configuration.GetSection("Database"))
            .AddServices()
            .AddViewModels()
        ;

        protected override async void OnStartup(StartupEventArgs e)
        {
            var host = Host;

            using (var scope = Services.CreateScope())
                scope.ServiceProvider.GetRequiredService<DbInit>().InitializeAsync().Wait();

            base.OnStartup(e);
            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;
            base.OnExit(e);
            await host.StopAsync();
        }
    }
}
