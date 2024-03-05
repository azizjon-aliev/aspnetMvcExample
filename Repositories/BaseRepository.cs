using BlogApi.Data;
using BlogAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repositories;

public class BaseAsyncRepository<T, TKey> : IBaseAsyncRepository<T, TKey> where T : BaseEntity
{
    private readonly ApplicationDbContext _dbContext;

    public BaseAsyncRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IQueryable<T>> GetAll()
    {
        return await Task.FromResult(_dbContext.Set<T>().AsQueryable());
    }

    public async Task<T?> GetById(TKey id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public async Task<T> Add(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<T?> Update(TKey id, T entity)
    {
        var existingEntity = await GetById(id);
        
        if (existingEntity == null)
        {
            return null;
        }
        
        entity.Id = existingEntity.Id;
        _dbContext.Entry(existingEntity).CurrentValues.SetValues(entity);
        await _dbContext.SaveChangesAsync();
        
        return entity;
    }

    public async Task<bool> Delete(TKey id)
    {
        var entity = await GetById(id);

        if (entity == null)
        {
            return false;
        }

        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}