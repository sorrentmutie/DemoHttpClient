using DemoRepository.Core.DataType;

namespace DemoRepository.Core;

public interface IDataServices<TListItemType, TDetailsType, TIdType>
   where TListItemType: BaseListItem<TIdType>
   where TDetailsType: BaseDetails<TIdType>
{
   Task<Page<TListItemType, TIdType>> GetAllAsync();
   Task<TDetailsType?> GetByIdAsync(TIdType id);
   Task CreateAsync(TDetailsType entity);
   Task UpdateAsync(TDetailsType entity);
   Task DeleteAsync(TIdType id);
}