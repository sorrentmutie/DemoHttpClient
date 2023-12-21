using DemoHttp.Models.Cinema;
using DemoMovie.DB;

Console.WriteLine("Hello, World!");

var context = new MovieDbContext();

/*await context.Actors.AddAsync(new Actor
{
    Name = "John",
    Surname = "Wayne",
    BirthDate = new DateTime(1935, 6, 15),
    Salary = 430.25m,
    Movies = new List<Movie>
    {
        new Movie
        {
            Title = "Via col vento",
        },
        new Movie
        {
            Title = "Terminator",
        },
        new Movie
        {
            Title = "Lo chiamavano trinità"
        }
    }
});

await context.Movies.AddAsync(new Movie
{
    Title = "Per un pugno di dollari",
    Actors = new List<Actor>
    {
        new Actor
        {
            Name = "mario",
            Surname = "Rossi",
            BirthDate = new DateTime(1963, 8, 21),
            Salary = 267.55m
        },
        new Actor
        {
            Name = "Giuseppe",
            Surname = "Verdi",
            BirthDate = new DateTime(1970, 2, 4),
            Salary = 176.23m
        }
    }
});

await context.SaveChangesAsync();
*/
/*
var moviesWithActors = await context.Movies
    .AsNoTracking()
    .Include(movie => movie.Actors)
    .ToListAsync();

foreach (var movie in moviesWithActors)
{
    Console.WriteLine($"{movie.Id}: {movie.Title}\n");
    foreach (var actor in movie.Actors)
    {
        Console.WriteLine($"{actor.Name}, {actor.Surname}, {actor.BirthDate}, {actor.Salary}");
    }
}*/
/*
var viaColVentoBis = await context.Movies.FirstOrDefaultAsync(movie => movie.Id == 1);
if (viaColVentoBis is not null)
{
    viaColVentoBis.Title = "Via Col Vento Bis";
    viaColVentoBis.Actors.Add(new Actor
    {
        Name = "Antonio",
        Surname = "Gialli",
        BirthDate = new DateTime(1980, 4, 28),
        Salary = 322.21m
    });
    await context.SaveChangesAsync();
}

foreach (var movie in moviesWithActors)
{
    Console.WriteLine($"{movie.Id}: {movie.Title}\n");
    foreach (var actor in movie.Actors)
    {
        Console.WriteLine($"{actor.Name}, {actor.Surname}, {actor.BirthDate}, {actor.Salary}");
    }
}

context.Movies.Remove(new Movie
{
    Id = 1
});
await context.SaveChangesAsync();
*/

var newMovie = new Movie
{
    Title = "Karate Kid",
};

await context.AddAsync(newMovie);
// await context.SaveChangesAsync();

var newReview = new Review
{
    Date = new DateTime(2022, 11, 23),
    Mark = "Excellent"
};

await context.AddAsync(newReview);
//await context.SaveChangesAsync();

var newReviewMovie = new ReviewMovie
{
    MovieId = newMovie.Id,
    ReviewId = newReview.Id,
    Movie = newMovie,
    Review = newReview,
    ReviewerName = "Pablito"
};

await context.AddAsync(newReviewMovie);
// await context.SaveChangesAsync();

var newActors = new List<Actor>
{
    new Actor
    {
        Name = "Andrea",
        Surname = "Blu",
        Id = 1,
        Movies = new List<Movie>
        {
            newMovie
        }
    }, 
    new Actor
    {
        Name = "Gianni",
        Surname = "Ippolito",
        Id = 2,
        Movies = new List<Movie>
        {
            newMovie
        }
    }
};

context.UpdateRange(newActors);
await context.SaveChangesAsync();