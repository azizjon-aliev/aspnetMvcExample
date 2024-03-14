using BlogAPI.Models.Entities;
using BlogAPI.Repositories;

namespace BlogAPI.Services;

public abstract class BaseService<T, TKey>: IBaseService<T, TKey> where T : BaseEntity
{
    protected readonly IBaseRepository<T, TKey> Repository;
    
    public BaseService(IBaseRepository<T, TKey> repository)
    {
        Repository = repository;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(int skip = 1, int take = 100)
    {
        var result = await Repository.GetAllAsync();
        return result.Skip((skip - 1) * take).Take(((skip - 1) * take) + take);
    }

    public virtual async Task<T?> GetByIdAsync(TKey id)
    {
        return await Repository.GetByIdAsync(id);
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        return await Repository.AddAsync(entity);
    }

    public virtual async Task<T?> UpdateAsync(TKey id, T entity)
    {
        return await Repository.UpdateAsync(id, entity);
    }

    public virtual async Task<bool> RemoveAsync(TKey id)
    {
        return await Repository.RemoveAsync(id);
    }
}