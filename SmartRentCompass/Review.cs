using System;

namespace SmartRentCompass
{
    /// <summary>
    /// Represents a review for an apartment.
    /// </summary>
    public class Review
    {
        public int Id { get; set; }
        public int ApartmentId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public int Rating { get; set; }

        /// <summary>
        /// Initializes a new instance of the Review class.
        /// </summary>
        /// <param name="id">The review ID.</param>
        /// <param name="apartmentId">The apartment ID.</param>
        /// <param name="userId">The user ID.</param>
        /// <param name="content">The content of the review.</param>
        /// <param name="rating">The rating given in the review.</param>
        public Review(int id, int apartmentId, int userId, string content, int rating)
        {
            Id = id;
            ApartmentId = apartmentId;
            UserId = userId;
            Content = content ?? throw new ArgumentNullException(nameof(content));
            Rating = rating;
        }

        /// <summary>
        /// Displays the details of the review.
        /// </summary>
        public void DisplayReview()
        {
            Console.WriteLine($"Review ID: {Id}");
            Console.WriteLine($"Apartment ID: {ApartmentId}");
            Console.WriteLine($"User ID: {UserId}");
            Console.WriteLine($"Content: {Content}");
            Console.WriteLine($"Rating: {Rating}");
        }
    }
}