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