using System;
using System.Collections.Generic;
using System.Linq;
using SmartRentCompass.Models;

namespace SmartRentCompass.Repositories
{
    public interface IApartmentRepository
    {
        void AddApartment(Apartment apartment);
        void RemoveApartment(int id);
        Apartment GetApartmentById(int id);
        IEnumerable<Apartment> GetAllApartments();
        IEnumerable<Apartment> SearchApartments(string query);
    }

    public class ApartmentRepository : IApartmentRepository
    {
        private List<Apartment> apartments = new List<Apartment>();

        public void AddApartment(Apartment apartment)
        {
            apartments.Add(apartment);
        }

        public void RemoveApartment(int id)
        {
            var apartment = apartments.FirstOrDefault(a => a.Id == id);
            if (apartment != null)
            {
                apartments.Remove(apartment);
            }
        }

        public Apartment GetApartmentById(int id)
        {
            return apartments.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Apartment> GetAllApartments()
        {
            return apartments;
        }

        public IEnumerable<Apartment> SearchApartments(string query)
        {
            return apartments.Where(a => a.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                         a.Address.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                                         a.Description.Contains(query, StringComparison.OrdinalIgnoreCase));
        }
    }
}