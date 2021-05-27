using JaiVendas.CrossCutting.Infra.IOC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JaiVendas.Presentation.WinApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton(LoadConfig())
                .RegisterServices()
                .RegisterAppplicationForms()
                .BuildServiceProvider();

            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            var formMain = serviceProvider.GetService<FormMain>();
            System.Windows.Forms.Application.Run(formMain);
        }

        static IConfiguration LoadConfig()
        {
            var builder = new ConfigurationBuilder();
            var currentDirectory = Directory.GetCurrentDirectory();
            var appSettingsName = "appSettings.json";

            return builder
                .SetBasePath(currentDirectory)
                .AddJsonFile(appSettingsName)
                .Build();

        }

        static IServiceCollection RegisterAppplicationForms(this IServiceCollection services)
        {
            return services
                .AddSingleton<FormMain>()
                .AddTransient<FormCustomerList>()
                .AddTransient<FormCustomerEdit>()
                .AddTransient<FormCustomerAdd>()
                .AddTransient<FormCustomerPhone>();
        }

    }
}
