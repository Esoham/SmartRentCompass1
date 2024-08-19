using SmartRentCompass.Data;

public static class TestData
{
    public static List<User> GetTestUsers()
    {
        return new List<User>
        {
            new User
            {
                Id = 1,
                UserName = "testuser1",
                Email = "testuser1@example.com",
                Password = "password123",
                DateCreated = DateTime.Now.AddMonths(-1), // Created 1 month ago
                LastLogin = DateTime.Now.AddDays(-1), // Logged in yesterday
                Role = "User"
            },
            new User
            {
                Id = 2,
                UserName = "testuser2",
                Email = "testuser2@example.com",
                Password = "password123",
                DateCreated = DateTime.Now.AddMonths(-2), // Created 2 months ago
                LastLogin = DateTime.Now.AddDays(-2), // Logged in 2 days ago
                Role = "Admin"
            }
        };
    }
}