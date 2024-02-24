using BlogAPI.Repository;

namespace BlogAPI.Services;

public class BaseService<T>: IBaseService<T> where T : class
{
    private readonly IBaseRepository<T> _repository;
    
    public BaseService(IBaseRepository<T> repository)
    {
        _repository = repository;
    }
    
    public IQueryable<T> GetAll(int skip = 0, int take = 100)
    {
        return _repository.GetAll().Skip(skip).Take(take);;
    }

    public T GetById(int id)
    {
        return _repository.GetById(id);
    }

    public T Create(T entity)
    {
        return _repository.Add(entity);
    }

    public T Update(int id, T entity)
    {
        return _repository.Update(id, entity);
    }

    public bool Delete(int id)
    {
        return _repository.Delete(id);
    }
}