using BlogAPI.Core.Models;
using BlogAPI.Core.Repositories;

namespace BlogAPI.Core.Services;

public class BaseService<T>: IBaseService<T> where T : BaseEntity
{
    protected readonly IBaseRepository<T> Repository;
    
    public BaseService(IBaseRepository<T> repository)
    {
        Repository = repository;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(int skip = 1, int take = 100)
    {
        var result = await Repository.GetAllAsync();
        return result.Skip((skip - 1) * take).Take(((skip - 1) * take) + take);
    }

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await Repository.GetByIdAsync(id);
    }

    public virtual async Task<T> AddAsync(T entity)
    {
        return await Repository.AddAsync(entity);
    }

    public virtual async Task<T?> UpdateAsync(int id, T entity)
    {
        return await Repository.UpdateAsync(id, entity);
    }

    public virtual async Task<bool> RemoveAsync(int id)
    {
        return await Repository.RemoveAsync(id);
    }
}