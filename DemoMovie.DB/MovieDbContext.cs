using DemoHttp.Models.Cinema;
using DemoMovie.DB.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DemoMovie.DB;

public class MovieDbContext: DbContext
{
    public DbSet<Actor> Actors { get; init; } = null!;
    public DbSet<Movie> Movies { get; init; } = null!;
    public DbSet<Review> Reviews { get; init; } = null!;
    public DbSet<ReviewMovie> ReviewsMovies { get; init; } = null!;
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite("Data Source = /Users/Francesco/Documents/Ellycode/DemoHttpClient/DemoMovie.DB/Database/MovieDB")
            .LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ActorConfiguration).Assembly);
    }
}