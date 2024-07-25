using System;

namespace SmartRentCompass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to SmartRent Compass!");
            // Initialize the application
            AppInitializer.Initialize();
            // Start the main menu
            MainMenu.Start();
        }
    }
}