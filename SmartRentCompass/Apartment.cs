namespace SmartRentCompass.Data
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}