using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SmartRentCompass
{
    /// <summary>
    /// Provides methods to interact with the FavoriteApartments database.
    /// </summary>
    public class FavoriteDatabaseHelper
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the FavoriteDatabaseHelper class.
        /// </summary>
        /// <param name="connectionString">The database connection string.</param>
        /// <exception cref="ArgumentNullException">Thrown when the connection string is null or empty.</exception>
        public FavoriteDatabaseHelper(string connectionString)
        {
            this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        /// <summary>
        /// Retrieves the favorite apartments for a specific user.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <returns>A list of favorite apartments.</returns>
        public List<Apartment> GetFavoriteApartments(int userId)
        {
            var favoriteApartments = new List<Apartment>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT a.* FROM FavoriteApartments fa JOIN Apartments a ON fa.ApartmentId = a.ApartmentId WHERE fa.UserId = @UserId";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var apartment = new Apartment(
                                    reader.GetInt32("ApartmentId"),
                                    reader.GetString("Name"),
                                    reader.GetString("Address"),
                                    reader.GetString("City"),
                                    reader.GetString("State"),
                                    reader.GetInt32("ZipCode"),
                                    reader.GetString("Source"),
                                    reader.GetBoolean("PetsAllowed"),
                                    reader.GetDecimal("Price"),
                                    reader.GetInt32("Size"),
                                    reader.GetInt32("Bedrooms"),
                                    reader.GetInt32("Bathrooms"),
                                    reader.GetBoolean("IsAvailable"),
                                    reader.GetString("Description")
                                );
                                favoriteApartments.Add(apartment);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching favorite apartments for user ID {userId}: {ex.Message}");
            }

            return favoriteApartments;
        }

        /// <summary>
        /// Adds an apartment to the user's favorites.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="apartmentId">The apartment ID.</param>
        public void AddFavoriteApartment(int userId, int apartmentId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO FavoriteApartments (UserId, ApartmentId) VALUES (@UserId, @ApartmentId)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@ApartmentId", apartmentId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding favorite apartment with ID {apartmentId} for user ID {userId}: {ex.Message}");
            }
        }

        /// <summary>
        /// Removes an apartment from the user's favorites.
        /// </summary>
        /// <param name="userId">The user ID.</param>
        /// <param name="apartmentId">The apartment ID.</param>
        public void RemoveFavoriteApartment(int userId, int apartmentId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM FavoriteApartments WHERE UserId = @UserId AND ApartmentId = @ApartmentId";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@ApartmentId", apartmentId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while removing favorite apartment with ID {apartmentId} for user ID {userId}: {ex.Message}");
            }
        }
    }
}