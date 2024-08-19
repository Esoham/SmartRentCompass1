namespace SmartRentCompass.Data
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Favorite> Favorites { get; set; } = new List<Favorite>();

        // New properties
        public DateTime DateCreated { get; set; } = DateTime.Now; // Automatically set to current time
        public DateTime LastLogin { get; set; } // Track when the user last logged in
        public string Role { get; set; } = "User"; // Could be "User", "Admin", etc.

        // Considered using Data Annotations for validation if needed
        // [Required, EmailAddress]
        // public string Email { get; set; }
    }
}