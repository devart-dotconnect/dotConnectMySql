using Devart.Data.MySql;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "" +
          "Host=127.0.0.1;" +
          "User Id=TestUser;" +
          "Password=TestPassword;" +
          "Database=TestDb;" +
          "License Key=**********";

        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Connection successful!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}