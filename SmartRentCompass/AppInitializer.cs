using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using SmartRentCompass.Repositories; // Ensure this is added for ApartmentRepository
using SmartRentCompass.Models;

namespace SmartRentCompass
{
    public static class AppInitializer
    {
        public static void Initialize()
        {
            Console.WriteLine("Initializing application...");

            // Load configuration
            var configuration = LoadConfiguration();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var apartmentRepository = new ApartmentRepository(); // Remove connectionString if not used

            // Add test data
            AddTestData(apartmentRepository);

            Console.WriteLine("Application initialized.");
        }

        private static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }

        private static void AddTestData(IApartmentRepository apartmentRepository)
        {
            var testApartment = new Apartment
            {
                Name = "Test Apartment",
                Address = "123 Main St",
                Price = 1200,
                Bedrooms = 2,
                Bathrooms = 1,
                Size = 800,
                Amenities = "Cozy 2-bedroom apartment",
                Description = "A cozy 2-bedroom apartment with all amenities."
            };

            apartmentRepository.AddApartment(testApartment);
        }
    }
}