using System;
using System.Collections.Generic;
using System.Linq;
using SmartRentCompass;

public class ApartmentSearch
{
    private List<Apartment> apartments;

    public ApartmentSearch()
    {
        apartments = new List<Apartment>();
    }

    public void AddApartment(Apartment apartment)
    {
        apartments.Add(apartment);
    }

    public void SearchByPrice(int maxPrice)
    {
        var results = apartments.Where(a => a.Price <= maxPrice).ToList();
        if (results.Any())
        {
            foreach (var apartment in results)
            {
                apartment.DisplayApartmentInfo();
            }
        }
        else
        {
            Console.WriteLine("No apartments found within the specified price range.");
        }
    }
}