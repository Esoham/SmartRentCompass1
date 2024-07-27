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
        public decimal Rent { get; set; }
        public int Size { get; set; } // SquareFeet
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public string Location => $"{City}, {State}";

        // Constructor
        public Apartment(string address, string city, string state, int zipCode, string source, bool petsAllowed)
        {
            Address = address ?? throw new ArgumentNullException(nameof(address));
            City = city ?? throw new ArgumentNullException(nameof(city));
            State = state ?? throw new ArgumentNullException(nameof(state));
            ZipCode = zipCode;
            Source = source ?? throw new ArgumentNullException(nameof(source));
            PetsAllowed = petsAllowed;
        }
    }
}