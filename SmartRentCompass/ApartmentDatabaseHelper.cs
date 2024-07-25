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
                    string query = "INSERT INTO Apartments (Name, Address, Rent, Size, Bedrooms, Bathrooms, PetsAllowed) VALUES (@Name, @Address, @Rent, @Size, @Bedrooms, @Bathrooms, @PetsAllowed)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", apartment.Name);
                        command.Parameters.AddWithValue("@Address", apartment.Address);
                        command.Parameters.AddWithValue("@Rent", apartment.Rent);
                        command.Parameters.AddWithValue("@Size", apartment.Size);
                        command.Parameters.AddWithValue("@Bedrooms", apartment.Bedrooms);
                        command.Parameters.AddWithValue("@Bathrooms", apartment.Bathrooms);
                        command.Parameters.AddWithValue("@PetsAllowed", apartment.PetsAllowed);
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

        public void RemoveApartment(int apartmentId)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "DELETE FROM Apartments WHERE ApartmentId = @ApartmentId";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApartmentId", apartmentId);
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

        public void UpdateApartment(Apartment apartment)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Apartments SET Name = @Name, Address = @Address, Rent = @Rent, Size = @Size, Bedrooms = @Bedrooms, Bathrooms = @Bathrooms, PetsAllowed = @PetsAllowed WHERE ApartmentId = @ApartmentId";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", apartment.Name);
                        command.Parameters.AddWithValue("@Address", apartment.Address);
                        command.Parameters.AddWithValue("@Rent", apartment.Rent);
                        command.Parameters.AddWithValue("@Size", apartment.Size);
                        command.Parameters.AddWithValue("@Bedrooms", apartment.Bedrooms);
                        command.Parameters.AddWithValue("@Bathrooms", apartment.Bathrooms);
                        command.Parameters.AddWithValue("@PetsAllowed", apartment.PetsAllowed);
                        command.Parameters.AddWithValue("@ApartmentId", apartment.ApartmentId);
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

        public Apartment GetApartment(int apartmentId)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Apartments WHERE ApartmentId = @ApartmentId";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ApartmentId", apartmentId);
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new Apartment(
                                    reader.GetString("Address"),
                                    reader.GetString("City"),
                                    reader.GetString("State"),
                                    reader.GetInt32("ZipCode"),
                                    reader.GetString("Source"),
                                    reader.GetBoolean("PetsAllowed")
                                )
                                {
                                    ApartmentId = reader.GetInt32("ApartmentId"),
                                    Name = reader.GetString("Name"),
                                    Rent = reader.GetDecimal("Rent"),
                                    Size = reader.GetInt32("Size"),
                                    Bedrooms = reader.GetInt32("Bedrooms"),
                                    Bathrooms = reader.GetInt32("Bathrooms")
                                };
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
            return null;
        }

        public static List<Apartment> GetFilteredApartments(int minRent, int maxRent, string location)
        {
            var apartments = new List<Apartment>();

            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Apartments WHERE Rent BETWEEN @minRent AND @maxRent AND Address LIKE @location";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@minRent", minRent);
                        command.Parameters.AddWithValue("@maxRent", maxRent);
                        command.Parameters.AddWithValue("@location", $"%{location}%");

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                apartments.Add(new Apartment(
                                    reader.GetString("Address"),
                                    reader.GetString("City"),
                                    reader.GetString("State"),
                                    reader.GetInt32("ZipCode"),
                                    reader.GetString("Source"),
                                    reader.GetBoolean("PetsAllowed")
                                )
                                {
                                    ApartmentId = reader.GetInt32("ApartmentId"),
                                    Name = reader.GetString("Name"),
                                    Rent = reader.GetDecimal("Rent"),
                                    Size = reader.GetInt32("Size"),
                                    Bedrooms = reader.GetInt32("Bedrooms"),
                                    Bathrooms = reader.GetInt32("Bathrooms")
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

        public static void AddReview(int userId, int apartmentId, int rating, string comment)
        {
            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Reviews (UserId, ApartmentId, Rating, Comment) VALUES (@userId, @apartmentId, @rating, @comment)";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@apartmentId", apartmentId);
                        command.Parameters.AddWithValue("@rating", rating);
                        command.Parameters.AddWithValue("@comment", comment);
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
    }
}