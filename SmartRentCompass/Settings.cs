using System;
using Microsoft.Extensions.Configuration;

namespace SmartRentCompass
{
    /// <summary>
    /// Provides application settings.
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Gets the database connection string.
        /// </summary>
        public static string ConnectionString { get; private set; }

        static Settings()
        {
            try
            {
                ConnectionString = GetConnectionString();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching the connection string: {ex.Message}");
                ConnectionString = string.Empty;
            }
        }

        /// <summary>
        /// Fetches the connection string from the configuration file.
        /// </summary>
        /// <returns>The connection string.</returns>
        private static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            return configuration.GetConnectionString("DefaultConnection");
        }
    }
}