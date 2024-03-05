using BlogAPI.Models.Entities;

namespace BlogAPI.Repositories;

public interface IBaseAsyncRepository<T, in TKey> where T : BaseEntity
{
    Task<IQueryable<T>> GetAll();
    Task<T?> GetById(TKey id);
    Task<T> Add(T entity);
    Task<T?> Update(TKey id, T entity);
    Task<bool> Delete(TKey id);
}
