using System;

namespace SmartRentCompass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Initializing application...");
            string connectionString = string.Empty;

            try
            {
                connectionString = AppInitializer.Initialize();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during initialization: {ex.Message}");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Welcome to SmartRent Compass!");
            Console.WriteLine("1. View Alerts");
            Console.WriteLine("2. Search Apartments");
            Console.WriteLine("3. View Favorite Apartments");
            Console.WriteLine("4. Add Favorite Apartment");
            Console.WriteLine("5. Remove Favorite Apartment");
            Console.WriteLine("6. Exit");
            Console.Write("Please select an option: ");

            // Additional code to handle user input and execute the selected option...

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}