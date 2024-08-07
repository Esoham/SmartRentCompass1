using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using SmartRentCompass.Models;

namespace SmartRentCompass
{
    public class SmartRentCompassContext : DbContext
    {
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public SmartRentCompassContext(DbContextOptions<SmartRentCompassContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Address).IsRequired();
                entity.Property(e => e.Price).IsRequired(); // Assuming 'Rent' should be 'Price'
                entity.Property(e => e.Bedrooms).IsRequired();
                entity.Property(e => e.Bathrooms).IsRequired();
                entity.Property(e => e.Description).IsRequired();
            });

            modelBuilder.Entity<Favorite>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.ApartmentId).IsRequired();
                entity.Property(e => e.AddedDate).IsRequired();
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.UserId).IsRequired();
                entity.Property(e => e.ApartmentId).IsRequired();
                entity.Property(e => e.Comment).IsRequired();
                entity.Property(e => e.Rating).IsRequired();
                entity.Property(e => e.ReviewDate).IsRequired();
            });
        }

        private static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }
    }
}