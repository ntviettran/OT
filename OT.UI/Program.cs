using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OT.Core;
using OT.Core.GlobalVariable;
using OT.Repositories.Interfaces;
using OT.Repositories.Repositories;
using OT.Services.Interfaces;
using OT.Services.Services;
using OT.UI.Forms;
using OT.UI.Page;

namespace OT.UI
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContextFactory<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOverTimeRepository, OverTimeRepository>();
            services.AddScoped<IOverTimeService, OverTimeService>();

            services.AddTransient<Login>();
            services.AddTransient<MainForm>();
            services.AddTransient<OTRegister>();

            GlobalService.ServiceProvider = services.BuildServiceProvider();

            var formLogin = GlobalService.ServiceProvider.GetRequiredService<Login>();
            Application.Run(formLogin);
        }
    }
}