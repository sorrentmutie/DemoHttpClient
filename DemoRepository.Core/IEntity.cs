namespace DemoRepository.Core;

public interface IEntity<T>
{
    T Id { get; set; }
}