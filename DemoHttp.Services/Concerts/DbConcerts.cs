using DemoConcertsDB;
using DemoHttp.Models.Music;
using DemoHttp.Models.Music.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoHttp.Services.Concerts;

public class DbConcerts(ConcertsDbContext context) : IConcert
{
    public async Task<List<Concert>?> GetConcertsAsync()
    {
         return await context.Concerts
             .AsNoTracking()
             .Include(concert => concert.Artist)
             .ToListAsync();
    }

    public async Task<Concert?> GetConcertAsync(int id)
    {
        return await context.Concerts
            .AsNoTracking()
            .Include(concert => concert.Artist)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<int> AddConcertAsync(Concert concert)
    {
        await context.Concerts.AddAsync(concert);
        await context.SaveChangesAsync();
        return concert.Id;
    }

    public async Task DeleteConcertAsync(int id)
    {
        var concert = await context.Concerts
            .AsNoTracking()
            .Include(concert => concert.Artist)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (concert is not null)
        {
            context.Artists.RemoveRange(concert.Artist);
            context.Concerts.Remove(concert);
        }

        await context.SaveChangesAsync();
    }

    public async Task UpdateConcertAsync(Concert newConcert)
    {
        var concert = await context.Concerts.FirstOrDefaultAsync(x => x.Id == newConcert.Id);

        if (concert is not null)
        {
            concert.Date = newConcert.Date;
            concert.Location = newConcert.Location;
            concert.Artist = newConcert.Artist;
        }

        await context.SaveChangesAsync();
    }
}