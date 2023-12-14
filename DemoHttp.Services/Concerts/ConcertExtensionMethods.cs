using DemoHttp.Models.DTO;
using DemoHttp.Models.Music;

namespace DemoHttp.Services.Concerts;

public static class ConcertExtensionMethods
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

    public static List<ConcertDtoForVisualization> ConvertConcertsToDto(this List<Concert> concerts)
    {
        return concerts.Select(concert => new ConcertDtoForVisualization()
        {
            Id = concert.Id,
            Date = concert.Date,
            Location = concert.Location,
            ArtistId = concert.ArtistId
        }).ToList();
    }

    public static ConcertDtoForVisualization ConvertConcertToDto(this Concert concert)
    {
        return new ConcertDtoForVisualization()
        {
            Id = concert.Id,
            Date = concert.Date,
            Location = concert.Location,
            ArtistId = concert.ArtistId
        };
    }
    
    public static ConcertDto ConvertConcertSpecialToDto(this Concert concert)
    {
        return new ConcertDto()
        {
            Id = concert.Id,
            Date = concert.Date,
            Location = concert.Location,
            ArtistId = concert.ArtistId,
            Artist = new ArtistDto
            {
                BirthYear = concert.Artist.BirthYear,
                Id = concert.Artist.Id,
                Name = concert.Artist.Name,
                Surname = concert.Artist.Surname
            }
        };
    }

    public static Concert ConvertDtoToConcert(this ConcertDtoBase concert)
    {
        return new Concert
        {
            Date = concert.Date,
            Location = concert.Location,
            ArtistId = concert.ArtistId
        };
    }
}