using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace SmartRentCompass
{
    public class WebScraper
    {
        public List<Apartment> ScrapeApartments(string url)
        {
            var apartments = new List<Apartment>();

            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);

                foreach (var node in doc.DocumentNode.SelectNodes("//div[@class='listing']"))
                {
                    // Extract required information
                    string name = node.SelectSingleNode(".//h2[@class='title']").InnerText;
                    string address = node.SelectSingleNode(".//span[@class='address']").InnerText;
                    string city = "Anytown"; // Placeholder - ideally extracted from the node or provided in some way
                    string state = "Anystate"; // Placeholder - ideally extracted from the node or provided in some way
                    int zipCode = 12345; // Placeholder - ideally extracted from the node or provided in some way
                    string source = url;
                    decimal rent = Convert.ToDecimal(node.SelectSingleNode(".//span[@class='price']").InnerText.Replace("$", string.Empty));
                    int bedrooms = Convert.ToInt32(node.SelectSingleNode(".//span[@class='bedrooms']").InnerText.Replace(" Bed", string.Empty));
                    int bathrooms = Convert.ToInt32(node.SelectSingleNode(".//span[@class='bathrooms']").InnerText.Replace(" Bath", string.Empty));
                    bool petsAllowed = node.SelectSingleNode(".//span[@class='pets']").InnerText.Contains("Pets Allowed");

                    // Create an Apartment object with all required parameters
                    var apartment = new Apartment(address, city, state, zipCode, source, petsAllowed)
                    {
                        Name = name,
                        Rent = rent,
                        Bedrooms = bedrooms,
                        Bathrooms = bathrooms
                    };

                    apartments.Add(apartment);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while scraping {url}: {ex.Message}");
            }

            return apartments;
        }

        public List<Apartment> ScrapeMultipleSites(List<string> urls)
        {
            var allApartments = new List<Apartment>();

            foreach (var url in urls)
            {
                var apartments = ScrapeApartments(url);
                allApartments.AddRange(apartments);
            }

            return allApartments;
        }

        public void SetAlertForNewListings(string url, int intervalInMinutes, Action<List<Apartment>> callback)
        {
            var timer = new System.Timers.Timer(intervalInMinutes * 60 * 1000);
            timer.Elapsed += (sender, e) =>
            {
                var newApartments = ScrapeApartments(url);
                callback(newApartments);
            };
            timer.Start();
        }
    }
}