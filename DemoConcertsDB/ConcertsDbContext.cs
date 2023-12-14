using DemoConcertsDB.Configuration;
using DemoHttp.Models.Music;
using Microsoft.EntityFrameworkCore;

namespace DemoConcertsDB;

public class ConcertsDbContext: DbContext
{
    public DbSet<Concert> Concerts { get; init; } = null!;
    public DbSet<Artist> Artists { get; init; } = null!;

    public ConcertsDbContext(DbContextOptions<ConcertsDbContext> dbContextOptions): base(dbContextOptions)
    {
        
    }
    
    /*
    public ConcertsDbContext()
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite("Data Source = /Users/Francesco/Documents/Ellycode/DemoHttpClient/DemoConcertsDB/MusicDB");
    }
    */
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArtistConfiguration).Assembly);
    }
}