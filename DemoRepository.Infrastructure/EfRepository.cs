using DemoRepository.Core;
using Microsoft.EntityFrameworkCore;

namespace DemoRepository.Infrastructure;

public class EfRepository<TEntity, TKey> : IRepository<TEntity, TKey>  
    where TEntity : class, IEntity<TKey>, new()
{
    private readonly DbContext _dbContext;
    private readonly DbSet<TEntity> _set;

    public EfRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _set = dbContext.Set<TEntity>();
    }

    public IQueryable<TEntity> GetAll()
    {
        return _set.AsNoTracking();
    }

    public async Task<TEntity?> GetByIdAsync(TKey id)
    {
        return await _set.FindAsync(id);
    }

    public async Task CreateAsync(TEntity entity)
    {
        await _set.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _set.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

   public async Task DeleteAsync(TKey id)
       {
           var entity = new TEntity { Id = id };
           _set.Remove(entity);
           await _dbContext.SaveChangesAsync();
       } 
}