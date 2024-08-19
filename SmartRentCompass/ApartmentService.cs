using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SmartRentCompass.Models;

namespace SmartRentCompass.Services
{
    public class ApartmentService
    {
        private readonly ApplicationDbContext _context;

        public ApartmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Method to retrieve all apartments asynchronously
        public async Task<List<Apartment>> GetAllApartmentsAsync()
        {
            return await _context.Apartments.ToListAsync();
        }

        // Method to retrieve available apartments only asynchronously
        public async Task<List<Apartment>> GetAvailableApartmentsAsync()
        {
            return await _context.Apartments.Where(a => a.Available).ToListAsync();
        }

        // Method to add a new apartment asynchronously
        public async Task AddApartmentAsync(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            await _context.SaveChangesAsync();
        }

        // Method to find an apartment by ID asynchronously
        public async Task<Apartment> GetApartmentByIdAsync(int id)
        {
            return await _context.Apartments.FindAsync(id);
        }
    }
}