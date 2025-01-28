using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace ClassLibrary.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            try
            {

                var basePath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName, "ClassLibrary");

                var configuration = new ConfigurationBuilder()
                    .SetBasePath(basePath) 
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                var connectionString = configuration.GetConnectionString("DefaultConnection");

                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseSqlServer(connectionString);

                return new AppDbContext(optionsBuilder.Options);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error creating DbContext. Check your configuration.", ex);
            }
        }
    }
}
