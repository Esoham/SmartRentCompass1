using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartRentCompass
{
    /// <summary>
    /// Provides methods for web scraping.
    /// </summary>
    public static class WebScraper
    {
        /// <summary>
        /// Fetches the content of a web page from the specified URL.
        /// </summary>
        /// <param name="url">The URL of the web page to fetch.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the content of the web page.</returns>
        public static async Task<string> FetchPageContent(string url)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException(nameof(url));

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while fetching the content from {url}: {ex.Message}");
                    return string.Empty;
                }
            }
        }
    }
}