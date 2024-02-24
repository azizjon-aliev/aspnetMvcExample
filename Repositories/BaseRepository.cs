using BlogApi.Data;
using BlogAPI.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repository;

public class BaseRepository<T, TKey>: IBaseRepository<T, TKey> where T : class
{
    readonly IApplicationDbContext _dbContext;
    
    public BaseRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IQueryable<T> GetAll()
    {
        return _dbContext.instance.Set<T>().AsNoTracking();
    }
    
    public T GetById(TKey id)
    {
        var entity = _dbContext.instance.Set<T>().Find(id);
        
        if (entity == null)
            throw new NotFoundException(typeof(T).Name, id);
        return entity;
    }
    
    public T Add(T entity)
    {
        _dbContext.instance.Set<T>().Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }
    
    public T Update(TKey id, T entity)
    {
        var item = _dbContext.instance.Set<T>().Find(id);

        if (item == null)
            throw new NotFoundException(typeof(T).Name, id);
        
        _dbContext.instance.Entry(item).CurrentValues.SetValues(entity);
        _dbContext.SaveChanges();
        return entity;
    }
    
    public bool Delete(TKey id)
    {
        var entity = _dbContext.instance.Set<T>().Find(id);
        if (entity == null)
        {
            return false;
        }
        _dbContext.instance.Set<T>().Remove(entity);
        _dbContext.SaveChanges();
        return true;
    }
}