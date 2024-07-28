using System;

namespace SmartRentCompass
{
    /// <summary>
    /// Provides methods to display and handle the main menu options.
    /// </summary>
    public static class MainMenu
    {
        /// <summary>
        /// Displays the main menu and handles user input.
        /// </summary>
        public static void ShowMenu()
        {
            Console.WriteLine("Welcome to SmartRent Compass!");
            Console.WriteLine("1. View Alerts");
            Console.WriteLine("2. Search Apartments");
            Console.WriteLine("3. View Favorite Apartments");
            Console.WriteLine("4. Add Favorite Apartment");
            Console.WriteLine("5. Remove Favorite Apartment");
            Console.WriteLine("6. Exit");

            Console.Write("Please select an option: ");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Alerts.ViewAlerts();
                    break;
                case "2":
                    SearchApartments();
                    break;
                case "3":
                    ViewFavoriteApartments();
                    break;
                case "4":
                    AddFavoriteApartment();
                    break;
                case "5":
                    RemoveFavoriteApartment();
                    break;
                case "6":
                    Console.WriteLine("Exiting the application...");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        private static void SearchApartments()
        {
            Console.WriteLine("Searching for apartments...");
            // Example implementation: Call the apartment search logic here
        }

        private static void ViewFavoriteApartments()
        {
            Console.WriteLine("Viewing favorite apartments...");
            // Example implementation: Call the favorite apartments logic here
        }

        private static void AddFavoriteApartment()
        {
            try
            {
                Console.Write("Enter the User ID: ");
                if (!int.TryParse(Console.ReadLine(), out int userId))
                {
                    throw new ArgumentException("Invalid User ID.");
                }

                Console.Write("Enter the Apartment ID: ");
                if (!int.TryParse(Console.ReadLine(), out int apartmentId))
                {
                    throw new ArgumentException("Invalid Apartment ID.");
                }

                var favoriteHelper = new FavoriteDatabaseHelper(GetConnectionString());
                favoriteHelper.AddFavoriteApartment(userId, apartmentId);
                Console.WriteLine("Apartment added to favorites.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private static void RemoveFavoriteApartment()
        {
            try
            {
                Console.Write("Enter the User ID: ");
                if (!int.TryParse(Console.ReadLine(), out int userId))
                {
                    throw new ArgumentException("Invalid User ID.");
                }

                Console.Write("Enter the Apartment ID: ");
                if (!int.TryParse(Console.ReadLine(), out int apartmentId))
                {
                    throw new ArgumentException("Invalid Apartment ID.");
                }

                var favoriteHelper = new FavoriteDatabaseHelper(GetConnectionString());
                favoriteHelper.RemoveFavoriteApartment(userId, apartmentId);
                Console.WriteLine("Apartment removed from favorites.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// Fetches the connection string from the configuration file.
        /// </summary>
        /// <returns>The connection string.</returns>
        private static string GetConnectionString()
        {
            // Example implementation: Fetch connection string from configuration
            return "your_connection_string_here"; // Replace with actual connection string fetching logic
        }
    }
}