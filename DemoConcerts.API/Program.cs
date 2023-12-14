using DemoConcertsDB;
using DemoHttp.Models.DTO;
using DemoHttp.Models.Music;
using DemoHttp.Models.Music.Interfaces;
using DemoHttp.Services.Concerts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IConcert, DbConcerts>();

var connectionString = builder.Configuration.GetConnectionString("MusicDB");
builder.Services.AddDbContext<ConcertsDbContext>(options => options.UseSqlite(connectionString,
    b => b.MigrationsAssembly("DemoConcertsDB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var mapGroup = app.MapGroup("/concerts");
var mapArtist = app.MapGroup("/artists");


mapGroup.MapGet("/", async (IConcert concerts) =>
    Results.Ok(await concerts.GetConcertsAsync()));

mapGroup.MapGet("/{id:int}", async (IConcert concerts, int id) =>
    await concerts.GetConcertAsync(id) is { } c
        ? Results.Ok(c)
        : Results.NotFound());

mapGroup.MapPost("/", async (IConcert concerts, ConcertDtoBase newConcert) =>
{
    /*if (newConcert.ArtistId == 0 || newConcert.Date.Year == 1)
    {
        return Results.BadRequest();
    }*/

    var id = await concerts.AddConcertAsync(newConcert);

    return Results.Created($"/concerts/{id}", newConcert);
});

mapGroup.MapDelete("/{id:int}", async (IConcert concerts, int id) =>
{
    if (await concerts.GetConcertAsync(id) is not { } c) return Results.NotFound();
    await concerts.DeleteConcertAsync(id);
    return Results.Ok();
});

mapGroup.MapPut("/{id:int}", async (IConcert concerts, int id, ConcertDto updatedConcert) =>
{
    
    if (id != updatedConcert.Id) return Results.BadRequest();

    var c = await concerts.GetConcertDtoAsync(id);
    if (c is null) return Results.NotFound();
    if (updatedConcert.ArtistId != 0) c.ArtistId = updatedConcert.ArtistId;
    if (updatedConcert.Date.Year != 1) c.Date = updatedConcert.Date;
    c.Location = updatedConcert.Location;
    await concerts.UpdateConcertAsync(c);
    
    return Results.NoContent();
});

mapGroup.MapPatch("/{id}", async (IConcert concerts, int id, Concert updatedConcert) =>
{
    if (id != updatedConcert.Id) return Results.BadRequest();

    var c = await concerts.GetConcertDtoAsync(id);
    if (c is null) return Results.NotFound();
    if (updatedConcert.ArtistId != 0) c.ArtistId = updatedConcert.ArtistId;
    if (updatedConcert.Date.Year != 1) c.Date = updatedConcert.Date;
    c.Location = updatedConcert.Location;
    await concerts.UpdateConcertAsync(c);
    
    return Results.NoContent();   
});

mapArtist.MapGet("/", async (IConcert service) =>
    Results.Ok(await service.GetArtistsAsync()));

app.Run();