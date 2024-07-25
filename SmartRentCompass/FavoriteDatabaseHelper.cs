using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SmartRentCompass
{
    public static class FavoriteDatabaseHelper
    {
        private const string ConnectionString = "Server=your_server;Database=SmartRentCompass;User ID=root;Password=Bourgeoi32#;";

        public static void InitializeFavoriteDatabase()
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                string createFavoritesTable = @"
                CREATE TABLE IF NOT EXISTS Favorites (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    UserId INT NOT NULL,
                    ApartmentId INT NOT NULL,
                    FOREIGN KEY (UserId) REFERENCES Users(Id),
                    FOREIGN KEY (ApartmentId) REFERENCES Apartments(Id)
                );";

                using (var command = new MySqlCommand(createFavoritesTable, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void AddFavorite(int userId, int apartmentId)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                string insertFavorite = @"
                INSERT INTO Favorites (UserId, ApartmentId)
                VALUES (@userId, @apartmentId);";

                using (var command = new MySqlCommand(insertFavorite, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    command.Parameters.AddWithValue("@apartmentId", apartmentId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ViewFavorites(int userId)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                connection.Open();

                string selectFavorites = @"
                SELECT a.Name, a.Price, a.Location, a.Source
                FROM Favorites f
                JOIN Apartments a ON f.ApartmentId = a.Id
                WHERE f.UserId = @userId;";

                using (var command = new MySqlCommand(selectFavorites, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader["Name"]}: ${reader["Price"]} per month, {reader["Location"]} from {reader["Source"]}");
                        }
                    }
                }
            }
        }
    }
}