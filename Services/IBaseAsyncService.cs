namespace BlogAPI.Services;

public interface IBaseAsyncService<T, in TKey> where T: class
{
    Task<IEnumerable<T>> GetAll(int skip = 0, int take = 100);
    Task<T?> GetById(TKey id);
    Task<T> Create(T entity);
    Task<T?> Update(TKey id, T entity);
    Task<bool> Delete(TKey id);
}