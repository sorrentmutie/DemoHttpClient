using DemoHttp.Models.DTO;
using DemoHttp.Models.Music;

namespace DemoHttp.Services.Music.ServicesDTO;

public static class ArtistExtensionMethods
{
    public static List<ArtistConcertsDetailDto> ConvertArtistsToDto(this List<Artist> artists)
    {
        return artists.Select(artist => new ArtistConcertsDetailDto()
        {
            Id = artist.Id,
            Name = artist.Name,
            Surname = artist.Surname,
            BirthYear = artist.BirthYear,
            Concerts = artist.Concerts.Select(concert => new ConcertDtoEssential()
            {
                Location = concert.Location,
                Date = concert.Date
            }).ToList()
        }).ToList();
    }
}