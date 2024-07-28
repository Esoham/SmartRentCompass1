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
                                ));
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
                foreach (var apartment in group.OrderBy(a => a.Price).Take(3))
                {
                    Console.WriteLine($"- {apartment.Name}: ${apartment.Price} per month from {apartment.Source}");
                }
            }
        }
    }
}