using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace SmartRentCompass
{
    /// <summary>
    /// Provides methods to interact with the Apartments database.
    /// </summary>
    public class ApartmentDatabaseHelper
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the ApartmentDatabaseHelper class.
        /// </summary>
        /// <param name="connectionString">The database connection string.</param>
        /// <exception cref="ArgumentNullException">Thrown when the connection string is null or empty.</exception>
        public ApartmentDatabaseHelper(string connectionString)
        {
            this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        /// <summary>
        /// Retrieves all apartments from the database.
        /// </summary>
        /// <returns>A list of apartments.</returns>
        public List<Apartment> GetAllApartments()
        {
            var apartments = new List<Apartment>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Apartments";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
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
                                    reader.GetBoolean("IsAvailable"), // Ensure this matches the database column
                                    reader.GetString("Description") // Ensure this matches the database column
                                );
                                apartments.Add(apartment);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching apartments: {ex.Message}");
            }

            return apartments;
        }

        /// <summary>
        /// Retrieves an apartment by its ID from the database.
        /// </summary>
        /// <param name="id">The apartment ID.</param>
        /// <returns>The apartment with the specified ID, or null if not found.</returns>
        public Apartment GetApartmentById(int id)
        {
            Apartment apartment = null;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT * FROM Apartments WHERE ApartmentId = @Id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                apartment = new Apartment(
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
                                    reader.GetBoolean("IsAvailable"), // Ensure this matches the database column
                                    reader.GetString("Description") // Ensure this matches the database column
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching the apartment with ID {id}: {ex.Message}");
            }

            return apartment;
        }

        /// <summary>
        /// Adds a new apartment to the database.
        /// </summary>
        /// <param name="apartment">The apartment to add.</param>
        public void AddApartment(Apartment apartment)
        {
            if (apartment == null) throw new ArgumentNullException(nameof(apartment));

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Apartments (Address, City, State, ZipCode, Price, Bedrooms, Bathrooms, IsAvailable, Description) VALUES (@Address, @City, @State, @ZipCode, @Price, @Bedrooms, @Bathrooms, @IsAvailable, @Description)";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Address", apartment.Address);
                        command.Parameters.AddWithValue("@City", apartment.City);
                        command.Parameters.AddWithValue("@State", apartment.State);
                        command.Parameters.AddWithValue("@ZipCode", apartment.ZipCode);
                        command.Parameters.AddWithValue("@Price", apartment.Price);
                        command.Parameters.AddWithValue("@Bedrooms", apartment.Bedrooms);
                        command.Parameters.AddWithValue("@Bathrooms", apartment.Bathrooms);
                        command.Parameters.AddWithValue("@IsAvailable", apartment.IsAvailable);
                        command.Parameters.AddWithValue("@Description", apartment.Description);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding a new apartment: {ex.Message}");
            }
        }

        /// <summary>
        /// Updates an existing apartment in the database.
        /// </summary>
        /// <param name="apartment">The apartment to update.</param>
        public void UpdateApartment(Apartment apartment)
        {
            if (apartment == null) throw new ArgumentNullException(nameof(apartment));

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Apartments SET Address = @Address, City = @City, State = @State, ZipCode = @ZipCode, Price = @Price, Bedrooms = @Bedrooms, Bathrooms = @Bathrooms, IsAvailable = @IsAvailable, Description = @Description WHERE ApartmentId = @Id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", apartment.ApartmentId);
                        command.Parameters.AddWithValue("@Address", apartment.Address);
                        command.Parameters.AddWithValue("@City", apartment.City);
                        command.Parameters.AddWithValue("@State", apartment.State);
                        command.Parameters.AddWithValue("@ZipCode", apartment.ZipCode);
                        command.Parameters.AddWithValue("@Price", apartment.Price);
                        command.Parameters.AddWithValue("@Bedrooms", apartment.Bedrooms);
                        command.Parameters.AddWithValue("@Bathrooms", apartment.Bathrooms);
                        command.Parameters.AddWithValue("@IsAvailable", apartment.IsAvailable);
                        command.Parameters.AddWithValue("@Description", apartment.Description);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the apartment with ID {apartment.ApartmentId}: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes an apartment from the database.
        /// </summary>
        /// <param name="id">The ID of the apartment to delete.</param>
        public void DeleteApartment(int id)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Apartments WHERE ApartmentId = @Id";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the apartment with ID {id}: {ex.Message}");
            }
        }
    }
}