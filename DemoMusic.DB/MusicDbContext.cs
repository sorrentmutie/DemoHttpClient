﻿using DemoHttp.Models.Music;
using DemoMusic.DB.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DemoMusic.DB;

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
            .UseSqlite("Data Source = /Users/Francesco/Documents/Ellycode/DemoHttpClient/DemoMusic.DB/MusicDB");
    }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArtistConfiguration).Assembly);
    }
}