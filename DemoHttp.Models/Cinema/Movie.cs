namespace DemoHttp.Models.Cinema;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public List<Actor> Actors { get; set; } = new List<Actor>();
    public List<ReviewMovie> ReviewMovies { get; set; } = new List<ReviewMovie>();
}