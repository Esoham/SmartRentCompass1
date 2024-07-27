using System;
using System.Collections.Generic;
using SmartRentCompass;

public static class ApartmentSearch
{
    public static void Search()
    {
        Console.WriteLine("Starting apartment search...");

        int minRent = GetValidatedRent("Enter minimum rent: ");
        int maxRent = GetValidatedRent("Enter maximum rent: ");

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

    private static int GetValidatedRent(string prompt)
    {
        int rent;
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            input = input.Replace(",", "").Trim(); // Remove commas and whitespace
            if (int.TryParse(input, out rent))
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        return rent;
    }
}