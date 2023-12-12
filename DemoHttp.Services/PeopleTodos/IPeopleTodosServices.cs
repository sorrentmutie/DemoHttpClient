using DemoHttp.Models.PeopleTodos;

namespace DemoHttp.Services.PeopleTodos;

public interface IPeopleTodosServices
{
    Task<List<Person>?> GetPeopleAsync();
    Task<List<Todos>?> GetTodosAsync(int? userId);
}