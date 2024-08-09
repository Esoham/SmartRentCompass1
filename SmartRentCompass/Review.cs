namespace SmartRentCompass.Data
{
    public class Review
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }
    }
}