using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartRentCompass.Models;

namespace SmartRentCompass.Helpers
{
    public class ApartmentDatabaseHelper
    {
        private readonly SmartRentCompassContext _context;

        public ApartmentDatabaseHelper(SmartRentCompassContext context)
        {
            _context = context;
        }

        public async Task<List<Apartment>> GetAllApartmentsAsync()
        {
            return await _context.Apartments.ToListAsync();
        }

        // Other CRUD operations
    }
}