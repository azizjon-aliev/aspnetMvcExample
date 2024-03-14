using BlogAPI.Core.Models;

namespace BlogAPI.Core.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<IQueryable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task<T?> UpdateAsync(int id, T entity);
    Task<bool> RemoveAsync(int id);
}
