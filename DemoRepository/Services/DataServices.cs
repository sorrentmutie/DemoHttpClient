using DemoRepository.Core;
using DemoRepository.Core.DataType;
using Microsoft.EntityFrameworkCore;

namespace DemoRepository.Services;

public class DataServices : IDataServices<WeatherForecastListItem, WeatherForecastDetails, int>

{
    private readonly IRepository<WeatherForecast, int> _repository;

    public DataServices(IRepository<WeatherForecast, int> repository)
    {
        _repository = repository;
    }

    public async Task<Page<WeatherForecastListItem, int>> GetAllAsync()
    {
        var data = await _repository
            .GetAll()
            .Select(forecast => new WeatherForecastListItem
            {
                DateTime = forecast.Date,
                Id = forecast.Id,
                TemperatureC = forecast.TemperatureC,
            })
            .ToListAsync();

        var page = new Page<WeatherForecastListItem, int>
        {
            Items = data,
            TotalCount = data.Count,
            PageCount = 1,
            CurrentPage = 1,
            ElementsForPage = 10
        };

        return page;
    }

    public async Task<WeatherForecastDetails?> GetByIdAsync(int id)
    {
        var weatherForecast = await _repository.GetByIdAsync(id);
        if (weatherForecast is null)
        {
            return null;
        }

        return new WeatherForecastDetails
        {
            Id = weatherForecast.Id,
            DateTime = weatherForecast.Date,
            Summary = weatherForecast.Summary,
            TemperatureC = weatherForecast.TemperatureC
        };
    }

    public async Task CreateAsync(WeatherForecastDetails entity)
    {
        var newForecast = new WeatherForecast
        {
            Date = entity.DateTime,
            Summary = entity.Summary,
            TemperatureC = entity.TemperatureC
        };

        await _repository.CreateAsync(newForecast);
    }

    public async Task UpdateAsync(WeatherForecastDetails entity)
    {
        await _repository.UpdateAsync(new WeatherForecast
        {
            Id = entity.Id,
            Date = entity.DateTime,
            Summary = entity.Summary,
            TemperatureC = entity.TemperatureC
        });
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}