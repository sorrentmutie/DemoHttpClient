using DemoRepository.Core.DataType;

namespace DemoRepository.Core;

public class WeatherForecastDetails : BaseDetails<int>
{
    public DateTime DateTime { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public string? Summary { get; set; }
}