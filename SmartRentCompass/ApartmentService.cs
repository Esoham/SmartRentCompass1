using System.Collections.Generic;
using System.Linq;

namespace SmartRentCompass.Data
{
    public class ApartmentService
    {
        private readonly List<Apartment> _apartments;
        private readonly List<User> _users;

        public ApartmentService()
        {
            _apartments = TestData.GetTestApartments();
            _users = TestData.GetTestUsers();
        }

        public List<Apartment> GetAllApartments() => _apartments;

        public Apartment GetApartmentById(int id) => _apartments.FirstOrDefault(a => a.Id == id);

        public void AddReview(int apartmentId, int userId, string content, int rating)
        {
            var apartment = _apartments.FirstOrDefault(a => a.Id == apartmentId);
            if (apartment != null)
            {
                var review = new Review
                {
                    Id = apartment.Reviews.Count + 1,
                    ApartmentId = apartmentId,
                    UserId = userId,
                    Content = content,
                    Rating = rating
                };
                apartment.Reviews.Add(review);
            }
        }

        public void AddFavorite(int userId, int apartmentId)
        {
            var user = _users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                var favorite = new Favorite
                {
                    Id = user.Favorites.Count + 1,
                    UserId = userId,
                    ApartmentId = apartmentId
                };
                user.Favorites.Add(favorite);
            }
        }

        public List<Favorite> GetFavoritesByUserId(int userId)
        {
            var user = _users.FirstOrDefault(u => u.Id == userId);
            return user?.Favorites ?? new List<Favorite>();
        }
    }
}