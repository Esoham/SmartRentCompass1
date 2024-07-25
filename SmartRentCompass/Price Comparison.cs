using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace SmartRentCompass
{
    public static class PriceComparison
    {
        private static readonly string ConnectionString = "Server=localhost;Database=smartrentcompass;User ID=root;Password=Bourgeoi32#;";

        public static void ComparePrices()
        {
            List<Apartment> apartments = new List<Apartment>();

            using (var connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM Apartments";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                apartments.Add(new Apartment(
                                    reader["Address"].ToString(),
                                    reader["City"].ToString(),
                                    reader["State"].ToString(),
                                    int.Parse(reader["ZipCode"].ToString()),
                                    reader["Source"].ToString(),
                                    bool.Parse(reader["PetsAllowed"].ToString())
                                )
                                {
                                    ApartmentId = int.Parse(reader["ApartmentId"].ToString()),
                                    Name = reader["Name"].ToString(),
                                    Rent = decimal.Parse(reader["Rent"].ToString()), // Updated to Rent
                                    Size = int.Parse(reader["Size"].ToString()),    // Added Size property
                                    Bedrooms = int.Parse(reader["Bedrooms"].ToString()), // Added Bedrooms property
                                    Bathrooms = int.Parse(reader["Bathrooms"].ToString()) // Added Bathrooms property
                                });
                            }
                        }
                    }

                    DisplayBestDeals(apartments);
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

        private static void DisplayBestDeals(List<Apartment> apartments)
        {
            var groupedByLocation = apartments.GroupBy(a => a.Location);

            foreach (var group in groupedByLocation)
            {
                Console.WriteLine($"Best deals in {group.Key}:");
                foreach (var apartment in group.OrderBy(a => a.Rent).Take(3)) // Updated to Rent
                {
                    Console.WriteLine($"- {apartment.Name}: ${apartment.Rent} per month from {apartment.Source}"); // Updated to Rent
                }
            }
        }
    }
}