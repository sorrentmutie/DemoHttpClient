using DemoHttp.Client;

var httpClient = new HttpClient();
var concertService = new MusicConcertClient(httpClient);

var concerts = await concertService.GetConcertsAsync();
if (concerts is not null)
{
    foreach (var c in concerts)
    {
        Console.WriteLine($"Id: {c.Id}\nLocation: {c.Location}\nDate: {c.Date}");
    }
}

var concert = await concertService.GetConcertAsync(3);
if (concert is not null)
{
    Console.WriteLine($"Concert with id 3:\nLocation: {concert.Location}\nDate: {concert.Date}");
}