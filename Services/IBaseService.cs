namespace BlogAPI.Services;

public interface IBaseService<T> where T: class
{
    IQueryable<T> GetAll(int skip = 0, int take = 100);
    T GetById(int id);
    T Create(T entity);
    T Update(int id, T entity);
    bool Delete(int id);
}