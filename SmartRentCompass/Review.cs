using System;

namespace SmartRentCompass
{
    public class Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ApartmentId { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }

        public Review(int userId, int apartmentId, string comment, int rating)
        {
            if (userId <= 0) throw new ArgumentOutOfRangeException(nameof(userId), "User ID must be positive.");
            if (apartmentId <= 0) throw new ArgumentOutOfRangeException(nameof(apartmentId), "Apartment ID must be positive.");
            if (rating < 1 || rating > 5) throw new ArgumentOutOfRangeException(nameof(rating), "Rating must be between 1 and 5.");

            UserId = userId;
            ApartmentId = apartmentId;
            Comment = comment ?? throw new ArgumentNullException(nameof(comment));
            Rating = rating;
            ReviewDate = DateTime.Now;
        }
    }
}