using DemoRepository.Core;
using DemoRepository.Data;
using DemoRepository.Infrastructure;
using DemoRepository.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DemoDbContext>(options => { options.UseInMemoryDatabase("DemoRepository"); });

builder.Services.AddScoped(typeof(IRepository<,>), typeof(EfRepository<,>));
builder.Services.AddScoped<IDataServices<WeatherForecastListItem, WeatherForecastDetails, int>, DataServices>();
builder.Services.AddScoped<DbContext, DemoDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var mapGroup = app.MapGroup("/weatherForecasts");

mapGroup.MapPost("/",
    async (IDataServices<WeatherForecastListItem, WeatherForecastDetails, int> dataServices,
        WeatherForecastDetails weatherForecast) =>
    {
        await dataServices.CreateAsync(weatherForecast);
        return Results.Created($"/weatherForecast/{weatherForecast.Id}", weatherForecast);
    });

mapGroup.MapGet("/{id:int}",
    async (IDataServices<WeatherForecastListItem, WeatherForecastDetails, int> dataServices, int id) =>
    {
        var weatherForecast = await dataServices.GetByIdAsync(id);
        return weatherForecast is null ? Results.NotFound() : Results.Ok(weatherForecast);
    });

mapGroup.MapGet("/", async (IDataServices<WeatherForecastListItem, WeatherForecastDetails, int> dataServices) =>
{
    var weatherForecast = await dataServices.GetAllAsync();
    return Results.Ok(weatherForecast);
});

mapGroup.MapPut("/",
    async (IDataServices<WeatherForecastListItem, WeatherForecastDetails, int> dataServices,
        WeatherForecastDetails weatherForecast) =>
    {
        await dataServices.UpdateAsync(weatherForecast);
        return Results.NoContent();
    });

mapGroup.MapDelete("/{id:int}",
    async (IDataServices<WeatherForecastListItem, WeatherForecastDetails, int> dataServices, int id) =>
    {
        if (await dataServices.GetByIdAsync(id) is null) return Results.NotFound();
        await dataServices.DeleteAsync(id);
        return Results.Ok();
    });

app.Run();