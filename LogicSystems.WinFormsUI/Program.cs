using Microsoft.Extensions.DependencyInjection;
using LogicSystems.Business;
using LogicSystems.Data;

namespace LogicSystems.WinFormsUI
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Setup Dependency Injection Container
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();

            // Run application with MainForm
            var mainForm = serviceProvider.GetRequiredService<MainForm>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Register Business Services
            services.AddScoped<OrderService>();
            services.AddScoped<PaymentService>();
            services.AddScoped<CargoService>();

            // Register Data Services
            services.AddScoped<ProductRepository>();
            services.AddScoped<Logger>();

            // Register UI Forms
            services.AddTransient<MainForm>();
            services.AddTransient<OrderForm>();
            services.AddTransient<PaymentForm>();
            services.AddTransient<ProductsForm>();
            services.AddTransient<CargoForm>();
            services.AddTransient<LogsForm>();
        }
    }
}