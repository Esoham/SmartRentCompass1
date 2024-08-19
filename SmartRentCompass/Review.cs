namespace SmartRentCompass.Data
{
    public class Review
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public int Rating
        {
            get => _rating;
            set
            {
                if (value < 1 || value > 5)
                    throw new ArgumentOutOfRangeException("Rating must be between 1 and 5.");
                _rating = value;
            }
        }
        private int _rating;
        public DateTime DatePosted { get; set; } = DateTime.Now;
    }
}