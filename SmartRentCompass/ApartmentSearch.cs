using System;
using System.Collections.Generic;

namespace SmartRentCompass
{
    public static class ApartmentSearch
    {
        public static void Search()
        {
            Console.WriteLine("Starting apartment search...");

            // Implement scraping logic and insert apartments into database
            // ...

            // Advanced filtering
            Console.Write("Enter minimum rent: ");
            int minRent = int.Parse(Console.ReadLine());

            Console.Write("Enter maximum rent: ");
            int maxRent = int.Parse(Console.ReadLine());

            Console.Write("Enter location: ");
            string location = Console.ReadLine();

            List<Apartment> apartments = ApartmentDatabaseHelper.GetFilteredApartments(minRent, maxRent, location);

            Console.WriteLine("Filtered Apartments:");
            foreach (var apt in apartments)
            {
                Console.WriteLine($"- {apt.Name}: ${apt.Rent} per month, {apt.Address}");
            }
        }

        public static void SearchByRentAndLocation(int minRent, int maxRent, string location)
        {
            Console.WriteLine("Searching apartments by rent and location...");

            List<Apartment> apartments = ApartmentDatabaseHelper.GetFilteredApartments(minRent, maxRent, location);

            Console.WriteLine("Filtered Apartments:");
            foreach (var apt in apartments)
            {
                Console.WriteLine($"- {apt.Name}: ${apt.Rent} per month, {apt.Address}");
            }
        }
    }
}