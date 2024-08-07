using System;
using SmartRentCompass.Models;
using SmartRentCompass.Repositories;

namespace SmartRentCompass
{
    public class MainMenu
    {
        private readonly IApartmentRepository _apartmentRepository;

        public MainMenu(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("Welcome to SmartRentCompass!");
                Console.WriteLine("1. View All Apartments");
                Console.WriteLine("2. Add New Apartment");
                Console.WriteLine("3. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewAllApartments();
                        break;
                    case "2":
                        AddNewApartment();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void ViewAllApartments()
        {
            var apartments = _apartmentRepository.GetAllApartments();

            foreach (var apartment in apartments)
            {
                Console.WriteLine(apartment);
            }
        }

        private void AddNewApartment()
        {
            Console.WriteLine("Enter name:");
            var name = Console.ReadLine();

            Console.WriteLine("Enter address:");
            var address = Console.ReadLine();

            Console.WriteLine("Enter price:");
            var price = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of bedrooms:");
            var bedrooms = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter number of bathrooms:");
            var bathrooms = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter size:");
            var size = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter amenities:");
            var amenities = Console.ReadLine();

            Console.WriteLine("Enter description:");
            var description = Console.ReadLine();

            var apartment = new Apartment
            {
                Name = name,
                Address = address,
                Price = price,
                Bedrooms = bedrooms,
                Bathrooms = bathrooms,
                Size = size,
                Amenities = amenities,
                Description = description
            };

            _apartmentRepository.AddApartment(apartment);

            Console.WriteLine("Apartment added successfully!");
        }
    }
}