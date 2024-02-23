namespace BlogAPI.Repository;

public interface IBaseRepository<T> where T : class
{
    IQueryable<T> GetAll();
    T GetById(int id);
    T Add(T entity);
    T Update(int id, T entity);
    bool Delete(int id);
}