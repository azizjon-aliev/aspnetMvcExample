using BlogApi.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repository;

public class BaseRepository<T>: IBaseRepository<T> where T : class
{
    readonly ApplicationDbContext _dbContext;
    
    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IQueryable<T> GetAll()
    {
        return _dbContext.Set<T>().AsNoTracking();
    }
    
    public T GetById(int id)
    {
        var entity = _dbContext.Set<T>().Find(id);
        
        if (entity == null)
            throw new ArgumentException("Item not found");
        return entity;
    }
    
    public T Add(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }
    
    public T Update(int id, T entity)
    {
        var item = _dbContext.Set<T>().Find(id);
        
        if (item == null)
            throw new ArgumentException("Item not found");
        
        _dbContext.Entry(item).CurrentValues.SetValues(entity);
        _dbContext.SaveChanges();
        return entity;
    }
    
    public bool Delete(int id)
    {
        var entity = _dbContext.Set<T>().Find(id);
        if (entity == null)
        {
            return false;
        }
        _dbContext.Set<T>().Remove(entity);
        _dbContext.SaveChanges();
        return true;
    }
}