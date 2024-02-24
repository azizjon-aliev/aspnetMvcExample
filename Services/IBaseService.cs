namespace BlogAPI.Services;

public interface IBaseService<T, TKey> where T: class
{
    IQueryable<T> GetAll(int skip = 0, int take = 100);
    T GetById(TKey id);
    T Create(T entity);
    T Update(TKey id, T entity);
    bool Delete(TKey id);
}