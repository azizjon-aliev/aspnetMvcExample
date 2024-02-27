using BlogAPI.Repositories;

namespace BlogAPI.Services;

public class BaseService<T, TKey>: IBaseService<T, TKey> where T : class
{
    private readonly IBaseRepository<T, TKey> _repository;
    
    public BaseService(IBaseRepository<T, TKey> repository)
    {
        _repository = repository;
    }
    
    public IQueryable<T> GetAll(int skip = 0, int take = 100)
    {
        return _repository.GetAll().Skip(skip).Take(take);;
    }

    public T GetById(TKey id)
    {
        return _repository.GetById(id);
    }

    public T Create(T entity)
    {
        return _repository.Add(entity);
    }

    public T Update(TKey id, T entity)
    {
        return _repository.Update(id, entity);
    }

    public bool Delete(TKey id)
    {
        return _repository.Delete(id);
    }
}