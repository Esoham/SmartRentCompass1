using MySql.Data.MySqlClient;
using System;
using System.Security.Cryptography;
using System.Text;

public class UserDatabaseHelper
{
    private static readonly string ConnectionString = "Server=localhost;Database=smartrentcompass;User ID=root;Password=Bourgeoi32#;";

    public static void RegisterUser(string username, string password)
    {
        var salt = GenerateSalt();
        var hash = HashPassword(password, salt);

        using (var connection = new MySqlConnection(ConnectionString))
        {
            try
            {
                connection.Open();
                string insertUser = @"INSERT INTO Users (Username, PasswordHash, Salt) VALUES (@username, @passwordHash, @salt)";
                using (var command = new MySqlCommand(insertUser, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@passwordHash", hash);
                    command.Parameters.AddWithValue("@salt", salt);
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}");
                // Additional logging or actions
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
                // Additional logging or actions
            }
        }
    }

    public static bool ValidateUser(string username, string password)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            try
            {
                connection.Open();
                string getUser = @"SELECT PasswordHash, Salt FROM Users WHERE Username = @username";
                using (var command = new MySqlCommand(getUser, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var storedHash = reader["PasswordHash"].ToString();
                            var storedSalt = reader["Salt"].ToString();
                            var hash = HashPassword(password, storedSalt);

                            return storedHash == hash;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}");
                // Additional logging or actions
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
                // Additional logging or actions
            }
        }
        return false;
    }

    public static int GetUserId(string username)
    {
        using (var connection = new MySqlConnection(ConnectionString))
        {
            try
            {
                connection.Open();
                string getUserId = @"SELECT UserId FROM Users WHERE Username = @username";
                using (var command = new MySqlCommand(getUserId, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return Convert.ToInt32(reader["UserId"]);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}");
                // Additional logging or actions
            }
            catch (Exception ex)
            {
                Console.WriteLine($"General Error: {ex.Message}");
                // Additional logging or actions
            }
        }
        return -1; // or another appropriate default value or error code
    }

    private static string GenerateSalt()
    {
        const int saltSize = 16;
        using (var rng = new RNGCryptoServiceProvider())
        {
            var saltBytes = new byte[saltSize];
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }
    }

    private static string HashPassword(string password, string salt)
    {
        using (var sha256 = SHA256.Create())
        {
            var saltedPassword = string.Concat(password, salt);
            var saltedPasswordBytes = Encoding.UTF8.GetBytes(saltedPassword);
            var hashBytes = sha256.ComputeHash(saltedPasswordBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }
}