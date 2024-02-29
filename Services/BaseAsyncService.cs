using BlogAPI.Repositories;

namespace BlogAPI.Services;

public class BaseAsyncService<T, TKey>: IBaseAsyncService<T, TKey> where T : class
{
    private readonly IBaseAsyncRepository<T, TKey> _repository;
    
    public BaseAsyncService(IBaseAsyncRepository<T, TKey> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<T>> GetAll(int skip = 0, int take = 100)
    {
        var result = await _repository.GetAll();
        return result.Skip(skip).Take(take);
    }

    public async Task<T?> GetById(TKey id)
    {
        return await _repository.GetById(id);
    }

    public async Task<T> Create(T entity)
    {
        return await _repository.Add(entity);
    }

    public async Task<T?> Update(TKey id, T entity)
    {
        return await _repository.Update(id, entity);
    }

    public async Task<bool> Delete(TKey id)
    {
        return await _repository.Delete(id);
    }
}