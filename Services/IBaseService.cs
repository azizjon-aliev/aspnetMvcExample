namespace BlogAPI.Services;

public interface IBaseService<T> where T: class
{
    IQueryable<T> GetAll(int skip, int take);
    T GetById(int id);
    T Create(T entity);
    T Update(int id, T entity);
    bool Delete(int id);
}