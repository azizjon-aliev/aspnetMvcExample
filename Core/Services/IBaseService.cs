using BlogAPI.Models.Entities;

namespace BlogAPI.Core.Services;

public interface IBaseService<T> where T: BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync(int skip = 0, int take = 100);
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task<T?> UpdateAsync(int id, T entity);
    Task<bool> RemoveAsync(int id);
}