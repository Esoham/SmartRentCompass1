namespace SmartRentCompass.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public bool Available { get; set; }
    }
}