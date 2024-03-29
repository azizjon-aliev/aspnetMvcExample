using BlogApi.Data;
using BlogAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Core.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext _dbContext;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<T?> UpdateAsync(int id, T entity)
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

    public virtual async Task<bool> RemoveAsync(int id)
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