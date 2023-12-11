// See https://aka.ms/new-console-template for more information
using DemoHttp.Services.ReqRes;

Console.WriteLine("Hello, World!");

var service = new ReqResService();
var data = await service.GetReqResData();
if(data is null)
{
    Console.WriteLine("Il server non ha risposto");
} else
{
    Console.WriteLine($"Il server ha risposto");
}
