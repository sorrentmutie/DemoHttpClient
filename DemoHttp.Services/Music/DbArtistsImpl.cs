using DemoHttp.Models.DTO;
using DemoHttp.Models.Music;
using DemoHttp.Models.Music.Interfaces;
using DemoHttp.Services.Music.ServicesDTO;
using DemoMusic.DB;
using Microsoft.EntityFrameworkCore;

namespace DemoHttp.Services.Music;

public class DbArtistsImpl(MusicDbContext context) : IArtist
{
    public async Task<List<ArtistConcertsDetailWithIdDto>?> GetArtistsAsync()
    {
        return (await context.Artists
                .AsNoTracking()
                .Include(artist => artist.Concerts)
                .ToListAsync())
            .ConvertArtistsToDto();
    }

    public async Task<ArtistDtoWithId> AddArtistAsync(ArtistDtoEssential newArtist)
    {
        var artistDb = newArtist.ConvertDtoToArtist();

        await context.Artists.AddAsync(artistDb);
        await context.SaveChangesAsync();

        return artistDb.ConvertArtistToDtoWithId();
    }

    public async Task<bool> AddConcertToArtist(int id, ConcertDtoEssential newConcert)
    {
        var artistDb = await context.Artists.FirstOrDefaultAsync(artist => artist.Id == id);
        if (artistDb == null)
            return false;
        var newConcertDb = new Concert()
        {
            Date = newConcert.Date,
            Location = newConcert.Location,
            ArtistId = id
        };
        await context.Concerts.AddAsync(newConcertDb);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task AddArtistWithConcertsAsync(ArtistConcertsDetailDto newArtist)
    {
        var artistDb = new Artist()
        {
            Name = newArtist.Name,
            Surname = newArtist.Surname,
            BirthYear = newArtist.BirthYear,
            Concerts = newArtist.Concerts.Select(c => new Concert
            {
                Location = c.Location,
                Date = c.Date
            }).ToList()
        };
        await context.Artists.AddAsync(artistDb);
        await context.SaveChangesAsync();
    }
}