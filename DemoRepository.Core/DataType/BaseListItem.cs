namespace DemoRepository.Core.DataType;

public abstract class BaseListItem<TIdType>
{
    public TIdType? Id { get; set; }
}