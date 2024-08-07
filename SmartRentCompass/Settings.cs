namespace SmartRentCompass
{
    public class Settings
    {
        public string DatabaseConnectionString { get; set; }

        private const string ConnectionStringNullError = "Database connection string cannot be null.";

        public Settings(string databaseConnectionString)
        {
            DatabaseConnectionString = databaseConnectionString ?? throw new System.ArgumentNullException(nameof(databaseConnectionString), ConnectionStringNullError);
        }
    }
}