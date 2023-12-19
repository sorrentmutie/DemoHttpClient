namespace DemoHttp.Models.Cinema;

public class Actor
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public decimal Salary { get; set; }
    public DateTime BirthDate { get; set; }
    public List<Movie> Movies { get; set; } = new List<Movie>();
}