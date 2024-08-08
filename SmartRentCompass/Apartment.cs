namespace SmartRentCompass.Models
{
    public class Apartment
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public decimal Rent { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime AvailableFrom { get; set; }
        public string Description { get; set; }

        // Adding the missing properties
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Size { get; set; }
        public string Amenities { get; set; }

        // Constructor with validation
        public Apartment(string address, decimal rent, int bedrooms, int bathrooms, bool isAvailable, DateTime availableFrom, string description)
        {
            if (string.IsNullOrWhiteSpace(address)) throw new ArgumentException("Address cannot be null or empty.", nameof(address));
            if (rent < 0) throw new ArgumentOutOfRangeException(nameof(rent), "Rent must be a non-negative value.");
            if (bedrooms < 0) throw new ArgumentOutOfRangeException(nameof(bedrooms), "Bedrooms must be a non-negative value.");
            if (bathrooms < 0) throw new ArgumentOutOfRangeException(nameof(bathrooms), "Bathrooms must be a non-negative value.");
            if (string.IsNullOrWhiteSpace(description)) throw new ArgumentException("Description cannot be null or empty.", nameof(description));

            Address = address;
            Rent = rent;
            Bedrooms = bedrooms;
            Bathrooms = bathrooms;
            IsAvailable = isAvailable;
            AvailableFrom = availableFrom;
            Description = description;
        }

        // Parameterless constructor for Entity Framework
        public Apartment() { }

        public override string ToString()
        {
            return $"{Address} - {Rent:C} - {Bedrooms} Bed(s), {Bathrooms} Bath(s) - Available from {AvailableFrom:MM/dd/yyyy}";
        }
    }
}