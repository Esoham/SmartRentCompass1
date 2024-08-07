using System;

namespace SmartRentCompass
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }

        private const string UsernameNullOrEmptyError = "Username cannot be null or empty.";
        private const string PasswordNullOrEmptyError = "Password cannot be null or empty.";
        private const string EmailNullOrEmptyError = "Email cannot be null or empty.";

        public User(string username, string password, string email)
        {
            if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException(UsernameNullOrEmptyError, nameof(username));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException(PasswordNullOrEmptyError, nameof(password));
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException(EmailNullOrEmptyError, nameof(email));

            Username = username;
            Password = password;
            Email = email;
            CreatedDate = DateTime.Now;
        }
    }
}