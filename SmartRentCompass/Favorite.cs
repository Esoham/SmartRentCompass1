using System;

namespace SmartRentCompass
{
    public class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ApartmentId { get; set; }
        public DateTime AddedDate { get; set; }

        public Favorite(int userId, int apartmentId)
        {
            if (userId <= 0) throw new ArgumentOutOfRangeException(nameof(userId), "User ID must be positive.");
            if (apartmentId <= 0) throw new ArgumentOutOfRangeException(nameof(apartmentId), "Apartment ID must be positive.");

            UserId = userId;
            ApartmentId = apartmentId;
            AddedDate = DateTime.Now;
        }
    }
}