using BlogAPI.Models.Entities;

namespace BlogAPI.Repositories;

public interface IBaseRepository<T, in TKey> where T : BaseEntity
{
    Task<IQueryable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(TKey id);
    Task<T> AddAsync(T entity);
    Task<T?> UpdateAsync(TKey id, T entity);
    Task<bool> RemoveAsync(TKey id);
}
