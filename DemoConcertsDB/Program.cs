
namespace DemoConcertsDB;

public static class Program
{
    public static void Main()
    {
        /*
        await using var context = new ConcertsDbContext();

        var concerts = new List<Concert>()
        {
            new Concert
            {
                Date = new DateTime(2021, 10, 10),
                Location = "Copenhagen",
                Artist = new Artist
                {
                    Name = "Eric",
                    Surname = "Clapton",
                    BirthYear = 1945
                }
            },

            new Concert
            {
                Date = new DateTime(2021, 6, 11),
                Location = "London",
                Artist = new Artist()
                {
                    Name = "Michael",
                    Surname = "Jackson",
                    BirthYear = 1958
                }
            },

            new Concert
            {
                Date = new DateTime(2021, 7, 12),
                Location = "Rome",
                Artist = new Artist
                {
                    Name = "David",
                    Surname = "Gilmour",
                    BirthYear = 1946
                }
            }
        };

        foreach (var concert in concerts)
        {
            await context.AddAsync(concert);
        }
        await context.SaveChangesAsync();
        */
    }
}