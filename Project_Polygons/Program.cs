using CalculatorApp.Handler;
using CalculatorApp.Handlers;
using CalculatorApp;
using RSPGameApp;
using ShapeApp;
using ClassLibrary.Data;
using ShapeApp.Controller;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project_Polygons;
using System;

namespace Project_Polygons
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var services = new ServiceCollection();
                var configuration = BuildConfiguration();
                ConfigureServices(services, configuration);

                var serviceProvider = services.BuildServiceProvider();

                InitializeDatabase(serviceProvider);

                var menu = serviceProvider.GetRequiredService<Menu>();
                menu.ShowMainMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel inträffade: {ex.Message}");
            }
        }

        private static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        private static void ConfigureServices(ServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IShapeRepository, ShapeRepository>();
            services.AddScoped<ICalculatorRepository, CalculatorRepository>();
            services.AddScoped<IGameRepository, GameRepository>();

            services.AddScoped<RectangleController>();
            services.AddScoped<ParallelogramController>();
            services.AddScoped<TriangleController>();
            services.AddScoped<RhombusController>();

            services.AddScoped<ShapesController>();

            services.AddScoped<CalculatorHandler>();
            services.AddScoped<GameHandler>();
            services.AddScoped<OperationHandler>();
            services.AddScoped<HistoryHandler>();
            services.AddScoped<UpdateHandler>();
            services.AddScoped<DeleteHandler>();

            services.AddScoped<Menu>();
        }

        private static void InitializeDatabase(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                try
                {
                    dbContext.Database.EnsureCreated();
                    Console.WriteLine("Databasen har initierats framgångsrikt.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Fel vid initiering av databasen: {ex.Message}");
                }
            }
        }
    }
}
