using DemoHttp.Models.Music;
using DemoHttp.Models.Music.Interfaces;
using DemoHttp.Services.Concerts;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IConcert, StaticConcerts>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var mapGroup = app.MapGroup("/concerts");


mapGroup.MapGet("/", async (IConcert concerts) =>
{
    return Results.Ok(await concerts.GetConcertsAsync());
});

mapGroup.MapGet("/{id}", async (IConcert concerts, int id) =>
     await concerts.GetConcertAsync(id) is Concert c
        ? Results.Ok(c)
        : Results.NotFound());

mapGroup.MapPost("/", async (IConcert concerts, Concert newConcert) => {

    if(newConcert is null || newConcert.Location is null ||
      newConcert.Artist is null || newConcert.Date.Year == 1)
    {
        return Results.BadRequest();
    } 

    var id = await concerts.AddConcertAsync(newConcert);
    newConcert.Id = id; 
    return Results.Created($"/concerts/{id}", newConcert);
});

mapGroup.MapDelete("/{id}", async (IConcert concerts, int id) =>
{
    if(await concerts.GetConcertAsync(id) is Concert c)
    {
        await concerts.DeleteConcertAsync(id);
        return Results.Ok();
    }
    return Results.NotFound();
});

mapGroup.MapPut("/{id}", async (IConcert concerts, int id, Concert updatedConcert) => {

    if (id != updatedConcert.Id) return Results.BadRequest();

    var c = await concerts.GetConcertAsync(id);
    if (c is null) return Results.NotFound();
    if (updatedConcert.Artist is not null) c.Artist = updatedConcert.Artist;
    if (updatedConcert.Date.Year != 1) c.Date = updatedConcert.Date;
    if (updatedConcert.Location is not null) c.Location = updatedConcert.Location;
    await concerts.UpdateConcertAsync(c);
    return Results.NoContent();
});

mapGroup.MapPatch("/{id}", async (IConcert concerts, int id, Concert updatedConcert) =>
{
    if (id != updatedConcert.Id) return Results.BadRequest();

    var c = await concerts.GetConcertAsync(id);
    if (c is null) return Results.NotFound();
    if (updatedConcert.Artist is not null) c.Artist = updatedConcert.Artist;
    if (updatedConcert.Date.Year != 1) c.Date = updatedConcert.Date;
    if (updatedConcert.Location is not null) c.Location = updatedConcert.Location;
    await concerts.UpdateConcertAsync(c);
    return Results.NoContent();
});

    
app.Run();





