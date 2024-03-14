using BlogApi.Data;
using BlogAPI.Models.Entities;

namespace BlogAPI.Repositories;

public class BaseRepository<T, TKey> : IBaseRepository<T, TKey> where T : BaseEntity
{
    protected readonly ApplicationDbContext _dbContext;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<IQueryable<T>> GetAllAsync()
    {
        return await Task.FromResult(_dbContext.Set<T>().AsQueryable());
    }

    public virtual async Task<T?> GetByIdAsync(TKey id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T?> UpdateAsync(TKey id, T entity)
    {
        var existingEntity = await GetByIdAsync(id);
        
        if (existingEntity == null)
        {
            return null;
        }
        
        entity.Id = existingEntity.Id;
        _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
        await _dbContext.SaveChangesAsync();
        
        return entity;
    }

    public virtual async Task<bool> RemoveAsync(TKey id)
    {
        var entity = await GetByIdAsync(id);

        if (entity == null)
        {
            return false;
        }

        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}