using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace SmartRentCompass
{
    public class ApartmentDatabaseHelper
    {
        private static readonly string ConnectionString = "Server=localhost;Database=smartrentcompass;User ID=root;Password=Bourgeoi32#;";

        public string Username { get; set; } = string.Empty;

        public ApartmentDatabaseHelper()
        {
            // Initialize non-nullable properties
            Username = string.Empty; // or any default value you consider appropriate
        }

        public void AddApartment(Apartment apartment)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Apartments (Name, Address, Price, Bedrooms, Bathrooms, SquareFeet) VALUES (@Name, @Address, @Price, @Bedrooms, @Bathrooms, @SquareFeet)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", apartment.Name);
                        command.Parameters.AddWithValue("@Address", apartment.Address);
                        command.Parameters.AddWithValue("@Price", apartment.Rent); // Assuming Rent maps to Price
                        command.Parameters.AddWithValue("@Bedrooms", apartment.Bedrooms);
                        command.Parameters.AddWithValue("@Bathrooms", apartment.Bathrooms);
                        command.Parameters.AddWithValue("@SquareFeet", apartment.Size); // Assuming Size maps to SquareFeet
                        command.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"MySQL Error: {ex.Message}");
                    // Additional logging or actions
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                    // Additional logging or actions
                }
            }
        }

        public static List<Apartment> GetFilteredApartments(decimal minPrice, decimal maxPrice, string location)
        {
            var apartments = new List<Apartment>();

            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Apartments WHERE Price BETWEEN @minPrice AND @maxPrice AND Address = @location";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@minPrice", minPrice);
                        command.Parameters.AddWithValue("@maxPrice", maxPrice);
                        command.Parameters.AddWithValue("@location", location);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                apartments.Add(new Apartment(
                                    reader["Address"].ToString(),
                                    reader["City"].ToString(),
                                    reader["State"].ToString(),
                                    Convert.ToInt32(reader["ZipCode"]),
                                    reader["Source"].ToString(),
                                    Convert.ToBoolean(reader["PetsAllowed"]))
                                {
                                    ApartmentId = Convert.ToInt32(reader["ApartmentID"]),
                                    Name = reader["Name"].ToString(),
                                    Rent = Convert.ToDecimal(reader["Price"]), // Changed Rent to Price
                                    Size = Convert.ToInt32(reader["SquareFeet"]),
                                    Bedrooms = Convert.ToInt32(reader["Bedrooms"]),
                                    Bathrooms = Convert.ToInt32(reader["Bathrooms"])
                                });
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"MySQL Error: {ex.Message}");
                    // Additional logging or actions
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                    // Additional logging or actions
                }
            }

            return apartments;
        }

        public static List<Review> GetReviews(int apartmentId)
        {
            var reviews = new List<Review>();

            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Reviews.*, Users.Username FROM Reviews JOIN Users ON Reviews.UserId = Users.UserId WHERE ApartmentId = @apartmentId";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@apartmentId", apartmentId);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                reviews.Add(new Review
                                {
                                    Username = reader["Username"].ToString(),
                                    Rating = int.Parse(reader["Rating"].ToString()),
                                    Comment = reader["Comment"].ToString()
                                });
                            }
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"MySQL Error: {ex.Message}");
                    // Additional logging or actions
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                    // Additional logging or actions
                }
            }

            return reviews;
        }

        public static void AddReview(int userId, int apartmentId, int rating, string comment)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Reviews (UserId, ApartmentId, Rating, Comment) VALUES (@UserId, @ApartmentId, @Rating, @Comment)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@ApartmentId", apartmentId);
                        command.Parameters.AddWithValue("@Rating", rating);
                        command.Parameters.AddWithValue("@Comment", comment);
                        command.ExecuteNonQuery();
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine($"MySQL Error: {ex.Message}");
                    // Additional logging or actions
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"General Error: {ex.Message}");
                    // Additional logging or actions
                }
            }
        }
    }
}