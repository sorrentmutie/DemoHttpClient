namespace DemoRepository.Core.DataType;

public abstract class BaseDetails<TIdType>
{
    public TIdType? Id { get; set; }
}