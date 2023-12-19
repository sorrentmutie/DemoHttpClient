using DemoMusic.DB;
using DemoHttp.Models.DTO;
using DemoHttp.Models.Music;
using DemoHttp.Models.Music.Interfaces;
using DemoHttp.Services.Music;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IConcert, DbConcertsImpl>();
builder.Services.AddScoped<IArtist, DbArtistsImpl>();

builder.Services.AddDbContext<MusicDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MusicDB"),
        optionsBuilder => optionsBuilder.MigrationsAssembly("DemoMusic.DB")));

var numberElementsPerPage = builder.Configuration["NumberElementsPerPage"] != null ?
    Convert.ToInt32(builder.Configuration["NumberElementsPerPage"]) : 10;

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var mapConcert = app.MapGroup("/concerts");
var mapArtist = app.MapGroup("/artists");


mapConcert.MapGet("/", async (IConcert concerts) =>
    Results.Ok(await concerts.GetConcertsAsync()));

mapConcert.MapGet("/pages/{page:min(1)}/direction/{direction:int}/order/{orderBy?}", 
    async (IConcert concerts, int page, string? orderBy, int direction = 0) =>
{
    var orderingDirection = direction switch
    {
        0 => OrderingDirection.Ascending,
        _ => OrderingDirection.Descending
    };
    return Results.Ok(await concerts.GetConcertsAsync(page, numberElementsPerPage, orderingDirection, orderBy));
});
    

mapConcert.MapGet("/{id:int}/", async (IConcert concerts, int id) =>
    await concerts.GetConcertAsync(id) is { } c
        ? Results.Ok(c)
        : Results.NotFound());

mapConcert.MapPost("/", async (IConcert concerts, ConcertDtoBase newConcert) =>
{
    /*if (newConcert.ArtistId == 0 || newConcert.Date.Year == 1)
    {
        return Results.BadRequest();
    }*/

    var id = await concerts.AddConcertAsync(newConcert);

    return Results.Created($"/concerts/{id}", newConcert);
});

mapConcert.MapDelete("/{id:int}", async (IConcert concerts, int id) =>
{
    if (await concerts.GetConcertAsync(id) is null) return Results.NotFound();
    await concerts.DeleteConcertAsync(id);
    return Results.Ok();
});

mapConcert.MapPut("/{id:int}", async (IConcert concerts, int id, ConcertDto updatedConcert) =>
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

mapConcert.MapPatch("/{id}", async (IConcert concerts, int id, Concert updatedConcert) =>
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

mapArtist.MapGet("/", async (IArtist service) =>
    Results.Ok(await service.GetArtistsAsync()));

app.Run();