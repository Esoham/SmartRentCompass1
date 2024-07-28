using System;

namespace SmartRentCompass
{
    /// <summary>
    /// Represents a user.
    /// </summary>
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Initializes a new instance of the User class.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <param name="firstName">The first name of the user.</param>
        /// <param name="lastName">The last name of the user.</param>
        /// <param name="email">The email of the user.</param>
        public User(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            Email = email ?? throw new ArgumentNullException(nameof(email));
        }

        /// <summary>
        /// Displays the user's information.
        /// </summary>
        public void DisplayUserInfo()
        {
            Console.WriteLine($"User ID: {Id}");
            Console.WriteLine($"Name: {FirstName} {LastName}");
            Console.WriteLine($"Email: {Email}");
        }
    }
}