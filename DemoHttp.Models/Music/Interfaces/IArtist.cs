using DemoHttp.Models.DTO;

namespace DemoHttp.Models.Music.Interfaces;

public interface IArtist
{
    Task<List<ArtistDto>?> GetArtistsAsync();
}