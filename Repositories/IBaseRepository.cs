namespace BlogAPI.Repository;

public interface IBaseRepository<T, TKey> where T : class
{
    IQueryable<T> GetAll();
    T GetById(TKey id);
    T Add(T entity);
    T Update(TKey id, T entity);
    bool Delete(TKey id);
}