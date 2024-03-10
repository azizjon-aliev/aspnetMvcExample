using BlogAPI.Models.Entities;

namespace BlogAPI.Services;

public interface IBaseService<T, in TKey> where T: BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync(int skip = 0, int take = 100);
    Task<T?> GetByIdAsync(TKey id);
    Task<T> AddAsync(T entity);
    Task<T?> UpdateAsync(TKey id, T entity);
    Task<bool> RemoveAsync(TKey id);
}