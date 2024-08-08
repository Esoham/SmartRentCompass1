using Microsoft.EntityFrameworkCore;
using SmartRentCompass.Models;

namespace SmartRentCompass
{
    public class SmartRentCompassContext : DbContext
    {
        public SmartRentCompassContext(DbContextOptions<SmartRentCompassContext> options)
            : base(options)
        {
        }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Alert> Alerts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Model configuration goes here
        }
    }
}