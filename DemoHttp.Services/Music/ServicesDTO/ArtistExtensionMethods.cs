using DemoHttp.Models.DTO;
using DemoHttp.Models.Music;

namespace DemoHttp.Services.Music.ServicesDTO;

public static class ArtistExtensionMethods
{
    public static List<ArtistDto> ConvertArtistsToDto(this List<Artist> artists)
    {
        return artists.Select(artist => new ArtistDto
        {
            Id = artist.Id,
            Name = artist.Name,
            Surname = artist.Surname,
            BirthYear = artist.BirthYear,
            Concerts = artist.Concerts.Select(concert => new ConcertDto
            {
                Id = concert.Id,
                ArtistId = concert.ArtistId,
                Location = concert.Location,
                Date = concert.Date
            }).ToList()
        }).ToList();
    }
}