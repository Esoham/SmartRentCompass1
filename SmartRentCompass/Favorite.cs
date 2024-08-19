namespace SmartRentCompass.Data
{
    public class Favorite
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ApartmentId { get; set; }

        // New properties
        public DateTime DateAdded { get; set; } = DateTime.Now; // Automatically set to the current time
        public string Notes { get; set; } // Optional notes from the user about why they favorited the apartment
    }
}