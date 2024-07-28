namespace SmartRentCompass
{
    public class Apartment
    {
        public int ApartmentId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string Source { get; set; }
        public bool PetsAllowed { get; set; }
        public decimal Price { get; set; }
        public int Size { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public bool IsAvailable { get; set; } // Added IsAvailable property
        public string Description { get; set; } // Added Description property
        public string Location => $"{City}, {State}";

        public Apartment(int apartmentId, string name, string address, string city, string state, int zipCode, string source, bool petsAllowed, decimal price, int size, int bedrooms, int bathrooms, bool isAvailable, string description)
        {
            ApartmentId = apartmentId;
            Name = name;
            Address = address;
            City = city;
            State = state;
            ZipCode = zipCode;
            Source = source;
            PetsAllowed = petsAllowed;
            Price = price;
            Size = size;
            Bedrooms = bedrooms;
            Bathrooms = bathrooms;
            IsAvailable = isAvailable;
            Description = description;
        }

        public void DisplayApartmentInfo()
        {
            Console.WriteLine($"Apartment: {Name}, Price: {Price}, Location: {Location}, Bedrooms: {Bedrooms}, Bathrooms: {Bathrooms}, Available: {IsAvailable}, Description: {Description}");
        }
    }
}