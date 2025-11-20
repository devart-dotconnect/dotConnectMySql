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
          "Protocol=SSL;" +
          "SSL CA Cert=file://C:\\CA-cert.pem;" +
          "SSL Cert=file://C:\\SSL-client-cert.pem;" +
          "SSL Key=file://C:\\SSL-client-key.pem;" +
          "License Key=**********";

        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("SSL/TLS Connection successful!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}