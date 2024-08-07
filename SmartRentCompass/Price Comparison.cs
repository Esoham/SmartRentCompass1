using System;
using System.Collections.Generic;
using System.Linq;
using SmartRentCompass.Models; // Add this directive to reference the Apartment class

namespace SmartRentCompass
{
    public class PriceComparison
    {
        private const string ApartmentsListCannotBeNullOrEmpty = "The apartments list cannot be null or empty.";

        public List<Apartment> ComparePrices(List<Apartment> apartments)
        {
            ValidateApartmentsList(apartments);

            return apartments.OrderBy(a => a.Rent).ToList();
        }

        public Apartment GetCheapestApartment(List<Apartment> apartments)
        {
            ValidateApartmentsList(apartments);

            return apartments.OrderBy(a => a.Rent).FirstOrDefault();
        }

        private static void ValidateApartmentsList(List<Apartment> apartments)
        {
            if (apartments == null || !apartments.Any())
            {
                throw new ArgumentException(ApartmentsListCannotBeNullOrEmpty, nameof(apartments));
            }
        }
    }
}