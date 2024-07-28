using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SmartRentCompass
{
    public static class AppInitializer
    {
        public static string Initialize()
        {
            try
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                IConfigurationRoot configuration = builder.Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception("Connection string is not configured.");
                }

                return connectionString;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching the connection string: {ex.Message}");
                throw;
            }
        }
    }
}