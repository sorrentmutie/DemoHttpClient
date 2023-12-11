using DemoHttp.Services.ReqRes;

Console.WriteLine("Hello, World!");

//var httpClient = new HttpClient();  
//var service = new ReqResService(httpClient);
//var data = await service.GetReqResPeopleAsync();
//if(data is null)
//{
//    Console.WriteLine("Il server non ha risposto");
//} else
//{
//    Console.WriteLine($"Il server ha risposto");
//    //Console.WriteLine($"{data.PerPage}"  );
//    if(data is null)
//    {
//        Console.WriteLine("Non ci sono persone");
//        return;
//    } else
//    {
//        foreach (var person in data)
//        {
//            Console.WriteLine($"{person.FirstName} {person.LastName}");
//        }
//    }
//}