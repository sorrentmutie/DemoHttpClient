using DemoHttp.Models.Music;
using DemoHttp.Models.Music.Interfaces;

namespace DemoHttp.Services.Concerts;

public class StaticConcerts : IConcert
{
    private static List<Concert> _concerts =
    [
        new Concert
        {
            Id = 1,
            Date = new DateTime(2021, 10, 10),
            Location = "Copenhagen",
            Artist = new Artist
            {
                Id = 1,
                Name = "Eric",
                Surname = "Clapton",
                BirthYear = 1963
            }
        },

        new Concert
        {
            Id = 2,
            Date = new DateTime(2021, 6, 11),
            Location = "London",
            Artist = new Artist
            {
                Id = 1,
                Name = "Eric",
                Surname = "Clapton",
                BirthYear = 1963
            }
        },

        new Concert
        {
            Id = 3,
            Date = new DateTime(2021, 7, 12),
            Location = "Rome",
            Artist = new Artist
            {
                Id = 2,
                Name = "David",
                Surname = "Gilmour",
                BirthYear = 1950
            }
        }
    ];

    public async Task<int> AddConcertAsync(Concert concert)
    {
        await Task.Delay(1000);
        if (_concerts.Count == 0)
        {
            _concerts = [];
            concert.Id = 1;
        }
        else
        {
            concert.Id = _concerts.Max(c => c.Id) + 1;
        }

        _concerts.Add(concert);
        return concert.Id;
    }

    public Task DeleteConcertAsync(int id)
    {
        var concert = _concerts.FirstOrDefault(x => x.Id == id);
        if (concert is not null)
        {
            _concerts.Remove(concert);
        }

        return Task.CompletedTask;
    }

    public async Task<Concert?> GetConcertAsync(int id)
    {
        await Task.Delay(1000);
        return _concerts.FirstOrDefault(x => x.Id == id);
    }

    public async Task<List<Concert>?> GetConcertsAsync()
    {
        await Task.Delay(1000);
        return _concerts;
    }

    public Task UpdateConcertAsync(Concert concert)
    {
        var concertDb = _concerts.FirstOrDefault(x => x.Id == concert.Id);
        if (concertDb is null) return Task.CompletedTask;
        concertDb.Date = concert.Date;
        concertDb.Location = concert.Location;
        concertDb.Artist = concert.Artist;

        return Task.CompletedTask;
    }
}