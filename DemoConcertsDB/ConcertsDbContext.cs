using DemoHttp.Models.Music;
using Microsoft.EntityFrameworkCore;

namespace DemoConcertsDB;

public class ConcertsDbContext(DbContextOptions<ConcertsDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Concert> Concerts { get; init; } = null!;
    public DbSet<Artist> Artists { get; init; } = null!;
    // private readonly string _connectionString = connectionString;

    /*
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite(_connectionString);
    }
    */
}