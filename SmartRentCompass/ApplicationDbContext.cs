using Microsoft.EntityFrameworkCore;
using SmartRentCompass.Models; // Adjust based on where your models are located

namespace SmartRentCompass
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Apartment> Apartments { get; set; } // This DbSet represents the Apartments table in your database
    }
}