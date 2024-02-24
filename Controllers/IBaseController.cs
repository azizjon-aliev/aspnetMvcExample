using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers;

public interface IBaseController<T> where T: class
{
    public IEnumerable<T> GetAll([FromQuery] int pageNumber, [FromQuery] int pageSize);
    public T GetById(int id);
    public T Create([FromBody] T data);
    public T Put([FromQuery] int id, [FromBody] T data);
    public void Delete(int id);
}