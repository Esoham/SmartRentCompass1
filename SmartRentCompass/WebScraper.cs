using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using SmartRentCompass.Models; // Add this directive to reference the Apartment class

namespace SmartRentCompass
{
    public class WebScraper
    {
        private const string UrlCannotBeNullOrEmpty = "URL cannot be null or empty.";

        public List<Apartment> ScrapeApartments(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) throw new ArgumentException(UrlCannotBeNullOrEmpty, nameof(url));

            var web = new HtmlWeb();
            var doc = web.Load(url);
            var apartments = new List<Apartment>();

            var nodes = doc.DocumentNode.SelectNodes("//div[@class='apartment']");
            if (nodes == null) return apartments; // Return empty list if no apartments found

            foreach (var node in nodes)
            {
                var address = GetNodeText(node, ".//span[@class='address']");
                var priceText = GetNodeText(node, ".//span[@class='price']").Replace("$", "").Replace(",", "").Trim();
                if (!decimal.TryParse(priceText, out var price))
                {
                    continue; // Skip if the price cannot be parsed
                }
                var bedroomsText = GetNodeText(node, ".//span[@class='bedrooms']").Trim();
                if (!int.TryParse(bedroomsText, out var bedrooms))
                {
                    continue; // Skip if the number of bedrooms cannot be parsed
                }
                var bathroomsText = GetNodeText(node, ".//span[@class='bathrooms']").Trim();
                if (!int.TryParse(bathroomsText, out var bathrooms))
                {
                    continue; // Skip if the number of bathrooms cannot be parsed
                }
                var description = GetNodeText(node, ".//span[@class='description']");

                var apartment = new Apartment(address, price, bedrooms, bathrooms, true, DateTime.Now, description);
                apartments.Add(apartment);
            }

            return apartments;
        }

        private static string GetNodeText(HtmlNode node, string xpath)
        {
            var selectedNode = node.SelectSingleNode(xpath);
            return selectedNode?.InnerText?.Trim() ?? string.Empty;
        }
    }
}