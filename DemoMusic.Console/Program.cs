using DemoHttp.Client;
using DemoHttp.Client.Models;

var httpClient = new HttpClient();
var concertService = new MusicConcertClient(httpClient);

// var concerts = await concertService.GetConcertsAsync();
// if (concerts is not null)
// {
//     foreach (var c in concerts)
//     {
//         Console.WriteLine($"Id: {c.Id}\nLocation: {c.Location}\nDate: {c.Date}");
//     }
// }
//
// var concert = await concertService.GetConcertAsync(3);
// if (concert is not null)
// {
//     Console.WriteLine($"Concert with id 3:\nLocation: {concert.Location}\nDate: {concert.Date}");
// }

var allConcerts = new List<Concert>();
int? currentPage = 1;
int? totalPages = null;
do
{
    
    var concertsList = await concertService.GetConcertsWithPaginationAsync(currentPage, "Location", OrderingDirection.Ascending);
    
    if (concertsList is not null)
    {
        
        totalPages = concertsList.Total / concertsList.Concerts.Count;
        allConcerts.AddRange(concertsList.Concerts);
    }
    currentPage++;
} while (currentPage <= totalPages);

foreach (var c in allConcerts)
{
    Console.WriteLine($"Id: {c.Id}\nLocation: {c.Location}\nDate: {c.Date}");
}


// var concertsListResult = await concertService.GetConcertsWithPaginationAsync(1, "Location", OrderingDirection.Ascending);
// if (concertsListResult is not null)
// {
//     Console.WriteLine($"Page: {concertsListResult.Page}\nTotal: {concertsListResult.Total}\nConcerts: ");
//     foreach (var c in concertsListResult.Concerts)
//     {
//         Console.WriteLine($"Id: {c.Id}\nLocation: {c.Location}\nDate: {c.Date}");
//     }
// }

