using System;

namespace SmartRentCompass
{
    public static class MainMenu
    {
        private static int loggedInUserId = -1; // Track logged in user

        public static void Start()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Main Menu:");
                if (loggedInUserId == -1)
                {
                    Console.WriteLine("1. Register");
                    Console.WriteLine("2. Login");
                }
                else
                {
                    Console.WriteLine("3. Search Apartments");
                    Console.WriteLine("4. View Alerts");
                    Console.WriteLine("5. Settings");
                    Console.WriteLine("6. Compare Prices");
                    Console.WriteLine("7. Add Favorite");
                    Console.WriteLine("8. View Favorites");
                    Console.WriteLine("9. Add Review");
                    Console.WriteLine("10. View Reviews");
                    Console.WriteLine("11. Logout");
                }
                Console.WriteLine("0. Exit");
                Console.Write("Please choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        if (loggedInUserId == -1) Register();
                        break;
                    case "2":
                        if (loggedInUserId == -1) Login();
                        break;
                    case "3":
                        if (loggedInUserId != -1) ApartmentSearch.Search();
                        break;
                    case "4":
                        if (loggedInUserId != -1) Alerts.ViewAlerts();
                        break;
                    case "5":
                        if (loggedInUserId != -1) Settings.Configure();
                        break;
                    case "6":
                        if (loggedInUserId != -1) PriceComparison.ComparePrices();
                        break;
                    case "7":
                        if (loggedInUserId != -1) AddFavorite();
                        break;
                    case "8":
                        if (loggedInUserId != -1) ViewFavorites();
                        break;
                    case "9":
                        if (loggedInUserId != -1) AddReview();
                        break;
                    case "10":
                        if (loggedInUserId != -1) ViewReviews();
                        break;
                    case "11":
                        if (loggedInUserId != -1) Logout();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        private static void Register()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            UserDatabaseHelper.RegisterUser(username, password);
            Console.WriteLine("Registration successful.");
        }

        private static void Login()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (UserDatabaseHelper.ValidateUser(username, password))
            {
                loggedInUserId = UserDatabaseHelper.GetUserId(username); // Assuming you have a method to get user ID
                Console.WriteLine("Login successful.");
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }
        }

        private static void Logout()
        {
            loggedInUserId = -1;
            Console.WriteLine("Logged out successfully.");
        }

        private static void AddFavorite()
        {
            Console.Write("Enter apartment ID to add to favorites: ");
            if (int.TryParse(Console.ReadLine(), out int apartmentId))
            {
                FavoriteDatabaseHelper.AddFavorite(loggedInUserId, apartmentId);
                Console.WriteLine("Apartment added to favorites.");
            }
            else
            {
                Console.WriteLine("Invalid apartment ID. Please enter a valid number.");
            }
        }

        private static void ViewFavorites()
        {
            FavoriteDatabaseHelper.ViewFavorites(loggedInUserId);
        }

        private static void AddReview()
        {
            Console.Write("Enter apartment ID to review: ");
            if (int.TryParse(Console.ReadLine(), out int apartmentId))
            {
                Console.Write("Enter rating (1-5): ");
                if (int.TryParse(Console.ReadLine(), out int rating) && rating >= 1 && rating <= 5)
                {
                    Console.Write("Enter comment: ");
                    string comment = Console.ReadLine();
                    ApartmentDatabaseHelper.AddReview(loggedInUserId, apartmentId, rating, comment);
                    Console.WriteLine("Review added.");
                }
                else
                {
                    Console.WriteLine("Invalid rating. Please enter a number between 1 and 5.");
                }
            }
            else
            {
                Console.WriteLine("Invalid apartment ID. Please enter a valid number.");
            }
        }

        private static void ViewReviews()
        {
            Console.Write("Enter apartment ID to view reviews: ");
            if (int.TryParse(Console.ReadLine(), out int apartmentId))
            {
                var reviews = ApartmentDatabaseHelper.GetReviews(apartmentId);
                foreach (var review in reviews)
                {
                    Console.WriteLine($"{review.Username}: {review.Rating}/5");
                    Console.WriteLine($"Comment: {review.Comment}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Invalid apartment ID. Please enter a valid number.");
            }
        }
    }
}