using System.Collections.Generic;

namespace SmartRentCompass.Data
{
    public static class TestData
    {
        public static List<Apartment> GetTestApartments()
        {
            return new List<Apartment>
            {
                new Apartment
                {
                    Id = 1,
                    Name = "Luxury Apartment",
                    Address = "123 Main St",
                    Price = 1200m,
                    Description = "A luxurious apartment with all amenities.",
                    ImageUrl = "https://example.com/image1.jpg",
                    Reviews = new List<Review>
                    {
                        new Review { Id = 1, ApartmentId = 1, UserId = 1, Content = "Great place!", Rating = 5 }
                    }
                },
                new Apartment
                {
                    Id = 2,
                    Name = "Cozy Apartment",
                    Address = "456 Maple Ave",
                    Price = 800m,
                    Description = "A cozy apartment in a quiet neighborhood.",
                    ImageUrl = "https://example.com/image2.jpg",
                    Reviews = new List<Review>
                    {
                        new Review { Id = 2, ApartmentId = 2, UserId = 2, Content = "Very comfortable.", Rating = 4 }
                    }
                }
            };
        }

        public static List<User> GetTestUsers()
        {
            return new List<User>
            {
                new User { Id = 1, UserName = "john_doe", Email = "john@example.com", Password = "password123" },
                new User { Id = 2, UserName = "jane_doe", Email = "jane@example.com", Password = "password456" }
            };
        }
    }
}