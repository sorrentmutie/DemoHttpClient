using DemoRepository.Core;
using Microsoft.EntityFrameworkCore;

namespace DemoRepository.Data;

public class DemoDbContext: DbContext
{
    public DbSet<WeatherForecast> WeatherForecasts => Set<WeatherForecast>();
    
    public DemoDbContext(DbContextOptions<DemoDbContext> options): base(options)
    {
        
    }
}