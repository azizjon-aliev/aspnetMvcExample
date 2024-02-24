using BlogAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/[controller]")]
public class BaseController<T, TKey> : Controller, IBaseController<T, TKey> where T: class
{
    private readonly IBaseService<T, TKey> _service;
    
    public BaseController(IBaseService<T, TKey> service)
    {
        _service = service;
    }
    
    [HttpGet]
    public IEnumerable<T> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100)
    {
        return _service.GetAll(skip: (pageNumber - 1) * pageSize, take: pageSize);
    }
    
    [HttpGet("{id}")]
    public T GetById(TKey id)
    {
        return _service.GetById(id);
    }
    
    
    [HttpPost]
    public T Create([FromBody] T data)
    {
        return _service.Create(data);
    }
    
    [HttpPut("{id}")]
    public T Put([FromQuery] TKey id, [FromBody] T data)
    {
        return _service.Update(id, data);
    }
    
    [HttpDelete("{id}")]
    public void Delete(TKey id)
    {
        _service.Delete(id);
    }
}