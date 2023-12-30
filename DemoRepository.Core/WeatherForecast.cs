namespace DemoRepository.Core;

public class WeatherForecast: IEntity<int>
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
}