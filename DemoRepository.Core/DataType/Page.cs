namespace DemoRepository.Core.DataType;

public class Page<TListItemType, TIdType> where TListItemType : BaseListItem<TIdType>
{
    public int TotalCount { get; set; }
    public int PageCount { get; set; }
    public int CurrentPage { get; set; }
    public int ElementsForPage { get; set; }
    public string? OrderBy { get; set; }
    public OrderByDirection OrderByDirection { get; set; }
    public List<TListItemType>? Items { get; set; }
}

public enum OrderByDirection
{
    Ascending,
    Descending
}