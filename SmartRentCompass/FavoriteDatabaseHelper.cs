using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient; // Ensure the correct MySQL library is used

namespace SmartRentCompass
{
    public class FavoriteDatabaseHelper
    {
        private readonly string _connectionString;

        private const string SELECT_FAVORITES_BY_USERID_QUERY = "SELECT * FROM Favorites WHERE UserId = @UserId";
        private const string INSERT_FAVORITE_QUERY = "INSERT INTO Favorites (UserId, ApartmentId, AddedDate) VALUES (@UserId, @ApartmentId, @AddedDate)";

        private const string USERID_PARAM = "@UserId";
        private const string APARTMENTID_PARAM = "@ApartmentId";
        private const string ADDEDDATE_PARAM = "@AddedDate";

        public FavoriteDatabaseHelper(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public List<Favorite> GetFavoritesByUserId(int userId)
        {
            if (userId <= 0) throw new ArgumentOutOfRangeException(nameof(userId), "User ID must be positive.");

            var favorites = new List<Favorite>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand(SELECT_FAVORITES_BY_USERID_QUERY, connection))
                {
                    command.Parameters.AddWithValue(USERID_PARAM, userId);

                    using (MySql.Data.MySqlClient.MySqlDataReader reader = command.ExecuteReader()) // Explicit namespace
                    {
                        while (reader.Read())
                        {
                            favorites.Add(MapFavorite(reader));
                        }
                    }
                }
            }

            return favorites;
        }

        public void AddFavorite(Favorite favorite)
        {
            if (favorite == null) throw new ArgumentNullException(nameof(favorite));

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand(INSERT_FAVORITE_QUERY, connection))
                {
                    AddFavoriteParameters(command, favorite);
                    command.ExecuteNonQuery();
                }
            }
        }

        private static Favorite MapFavorite(MySql.Data.MySqlClient.MySqlDataReader reader) // Explicit namespace
        {
            return new Favorite(
                Convert.ToInt32(reader["UserId"]),
                Convert.ToInt32(reader["ApartmentId"])
            )
            {
                Id = Convert.ToInt32(reader["Id"]),
                AddedDate = Convert.ToDateTime(reader["AddedDate"])
            };
        }

        private static void AddFavoriteParameters(MySqlCommand command, Favorite favorite)
        {
            command.Parameters.AddWithValue(USERID_PARAM, favorite.UserId);
            command.Parameters.AddWithValue(APARTMENTID_PARAM, favorite.ApartmentId);
            command.Parameters.AddWithValue(ADDEDDATE_PARAM, favorite.AddedDate);
        }

        // Additional methods for updating and deleting favorites can be added here
    }
}