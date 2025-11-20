# How to connect to MySQL and MariaDB in .NET with C#

Based on [https://www.devart.com/dotconnect/mysql/connect-mysql-in-net.html](https://www.devart.com/dotconnect/mysql/connect-mysql-in-net.html)

This tutorial walks you through several approaches for connecting to MySQL and MariaDB databases using C#. Whether you're building a data-driven .NET application with ADO.NET or working with EF Core for object-relational mapping, this guide will help you set up and manage secure, efficient database connections using dotConnect for MySQL.

## Connect to MySQL using C#

Learn how to establish a straightforward database connection to MySQL or MariaDB using ADO.NET and dotConnect for MySQL. This section covers how to create a connection string, open the connection, and perform basic queries in a .NET Console App.

```cs
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
```

## Connect to MySQL using the SSL/TLS connection

Security is critical when working with databases over a network. This section shows you how to configure and use SSL/TLS encryption in your connection string when accessing MySQL or MariaDB from your .NET application. 

```cs
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
```

## Connect to MySQL with EF Core

For developers using EF Core, this section demonstrates how to integrate dotConnect for MySQL with Entity Framework Core.

```cs
using Microsoft.EntityFrameworkCore;
using Devart.Data.MySql.EFCore;

public class Actor
{
  public int ActorId { get; set; }
  public string FirstName { get; set; }
  public string LastName { get; set; }
}

public class SakilaContext : DbContext
{
  public DbSet<Actor> Actors { get; set; }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    optionsBuilder.UseMySql(
      "Server=127.0.0.1;Port=3306;UserId=TestUser;Password=TestPassword;Database=sakila;License Key=**********",
      MySqlServerVersion.LatestSupportedServerVersion
    );
  }
}

class Program
{
  static void Main()
  {
    using (var context = new SakilaContext())
    {
      try
      {
        // Ensure the database is created
        context.Database.EnsureCreated();
        Console.WriteLine("Connected to the database successfully!");

        // Query data from the Actors table
        var actors = context.Actors;
        foreach (var actor in actors)
        {
          Console.WriteLine($"Actor ID: {actor.ActorId}, Name: {actor.FirstName} {actor.LastName}");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error: {ex.Message}");
      }
    }
  }
}
```