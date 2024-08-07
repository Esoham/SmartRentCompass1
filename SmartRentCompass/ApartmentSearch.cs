using System;
using System.Collections.Generic;
using SmartRentCompass.Models;
using SmartRentCompass.Repositories;

namespace SmartRentCompass.Services
{
    public class ApartmentSearch
    {
        private readonly IApartmentRepository _apartmentRepository;

        public ApartmentSearch(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository ?? throw new ArgumentNullException(nameof(apartmentRepository));
        }

        public IEnumerable<Apartment> Search(string query)
        {
            return _apartmentRepository.SearchApartments(query);
        }
    }
}