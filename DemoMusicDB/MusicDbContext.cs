using DemoHttp.Models.Music;
using DemoMusicDB.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DemoMusicDB;

public class MusicDbContext : DbContext
{
    public DbSet<Concert> Concerts { get; init; } = null!;
    public DbSet<Artist> Artists { get; init; } = null!;

    public MusicDbContext(DbContextOptions<MusicDbContext> dbContextOptions) : base(dbContextOptions) { }

    
    public MusicDbContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite("Data Source = /Users/Francesco/Documents/Ellycode/DemoHttpClient/DemoMusicDB/MusicDB");
    }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArtistConfiguration).Assembly);
    }
}