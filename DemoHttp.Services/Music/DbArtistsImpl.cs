using DemoHttp.Models.DTO;
using DemoHttp.Models.Music.Interfaces;
using DemoHttp.Services.Music.ServicesDTO;
using DemoMusic.DB;
using Microsoft.EntityFrameworkCore;

namespace DemoHttp.Services.Music;

public class DbArtistsImpl(MusicDbContext context): IArtist
{
    public async Task<List<ArtistConcertsDetailDto>?> GetArtistsAsync()
    {
        return (await context.Artists
                .AsNoTracking()
                .Include(artist => artist.Concerts)
                .ToListAsync())
            .ConvertArtistsToDto();
    }
}