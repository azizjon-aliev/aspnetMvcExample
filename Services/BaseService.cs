using BlogAPI.Models.Entities;
using BlogAPI.Repositories;

namespace BlogAPI.Services;

public class BaseService<T, TKey>: IBaseService<T, TKey> where T : BaseEntity
{
    private readonly IBaseRepository<T, TKey> _repository;
    
    public BaseService(IBaseRepository<T, TKey> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<T>> GetAllAsync(int skip = 1, int take = 100)
    {
        var result = await _repository.GetAllAsync();
        return result.Skip((skip - 1) * take).Take(((skip - 1) * take) + take);
    }

    public async Task<T?> GetByIdAsync(TKey id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<T> AddAsync(T entity)
    {
        return await _repository.AddAsync(entity);
    }

    public async Task<T?> UpdateAsync(TKey id, T entity)
    {
        return await _repository.UpdateAsync(id, entity);
    }

    public async Task<bool> RemoveAsync(TKey id)
    {
        return await _repository.RemoveAsync(id);
    }
}