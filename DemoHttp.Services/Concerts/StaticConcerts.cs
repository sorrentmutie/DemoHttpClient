
using DemoHttp.Models.Music;
using DemoHttp.Models.Music.Interfaces;

namespace DemoHttp.Services.Concerts;

public class StaticConcerts : IConcert
{
    private static List<Concert> concerts = new List<Concert>
    {
         new Concert
         {
             Id = 1,
             Date = new DateTime(2021, 10, 10),
             Location = "Copenhagen",
             Artist = "Metallica"
         },
       new Concert
       {
                Id = 2,
                Date = new DateTime(2021, 6, 11),
                Location = "London",
                Artist = "U2"
            },
       new Concert
       {
                Id = 3,
                Date = new DateTime(2021, 7, 12),
                Location = "Rome",
                Artist = "Radiohead"
            }
    };

    public async Task<int> AddConcertAsync(Concert concert)
    {
        await Task.Delay(1000);
        if(concerts is  null || concerts.Count() == 0)
        {
            concerts = new List<Concert>();
            concert.Id = 1;
        } else
        {
            concert.Id = concerts.Max(concert => concert.Id) + 1 ;
        }

        concerts.Add(concert);
        return concert.Id;
    }

    public Task DeleteConcertAsync(int id)
    {
        var concert = concerts.FirstOrDefault(x => x.Id == id);
        if (concert is not null)
        {
            concerts.Remove(concert);
        }
        return Task.CompletedTask;
    }

    public async Task<Concert?> GetConcertAsync(int id)
    {
        await Task.Delay(1000);
        return concerts.FirstOrDefault(x => x.Id == id);
    }

    public async Task<List<Concert>?> GetConcertsAsync()
    {
        await Task.Delay(1000);
        return concerts;
    }

    public Task UpdateConcertAsync(Concert concert)
    {
        var concertDb = concerts.FirstOrDefault(x => x.Id == concert.Id);
        if(concertDb is not null)
        {
            concertDb.Date = concert.Date;
            concertDb.Location = concert.Location;
            concertDb.Artist = concert.Artist;
        }
        return Task.CompletedTask;
    }
}
