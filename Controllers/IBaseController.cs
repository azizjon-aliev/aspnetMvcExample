using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers;

public interface IBaseController<T, TKey> where T: class
{
    public IEnumerable<T> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100);
    public T GetById(TKey id);
    public T Create([FromBody] T data);
    public T Put([FromQuery] TKey id, [FromBody] T data);
    public void Delete(TKey id);
}