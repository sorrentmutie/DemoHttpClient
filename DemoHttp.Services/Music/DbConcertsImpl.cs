using DemoHttp.Models.DTO;
using DemoHttp.Models.Music;
using DemoHttp.Models.Music.Interfaces;
using DemoHttp.Services.Music.ServicesDTO;
using DemoMusic.DB;
using Microsoft.EntityFrameworkCore;

namespace DemoHttp.Services.Music;

public class DbConcertsImpl(MusicDbContext context) : IConcert
{
    public async Task<List<ConcertDtoForVisualization>?> GetConcertsAsync()
    {
        return (await context.Concerts
                .AsNoTracking()
                .Include(concert => concert.Artist)
                .ToListAsync())
            .ConvertConcertsToDto();
    }

    public async Task<ConcertDto?> GetConcertDtoAsync(int id)
    {
        return (await context.Concerts
                .AsNoTracking()
                .Include(concert => concert.Artist)
                .FirstOrDefaultAsync(c => c.Id == id))?
            .ConvertConcertSpecialToDto();
    }

    public async Task<ConcertDtoForVisualization?> GetConcertAsync(int id)
    {
        return (await context.Concerts
                .AsNoTracking()
                .Include(concert => concert.Artist)
                .FirstOrDefaultAsync(c => c.Id == id))?
            .ConvertConcertToDto();
    }

    public async Task<int> AddConcertAsync(ConcertDtoBase concert)
    {
        var concertDb = concert.ConvertDtoToConcert();

        if (concert.ArtistId == 0 && concert.Artist != null!)
        {
            var newArtist = new Artist
            {
                Name = concert.Artist.Name,
                Surname = concert.Artist.Surname,
                BirthYear = concert.Artist.BirthYear
            };
            await context.Artists.AddAsync(newArtist);
            await context.SaveChangesAsync();
            concertDb.ArtistId = newArtist.Id;
        }

        await context.Concerts.AddAsync(concertDb);
        await context.SaveChangesAsync();
        return concertDb.Id;
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

    public async Task UpdateConcertAsync(ConcertDto updatedConcert)
    {
        var concertDb = await context.Concerts.FirstOrDefaultAsync(x => x.Id == updatedConcert.Id);

        if (concertDb is not null)
        {
            concertDb.Date = updatedConcert.Date;
            concertDb.Location = updatedConcert.Location;
        }

        await context.SaveChangesAsync();
    }
}