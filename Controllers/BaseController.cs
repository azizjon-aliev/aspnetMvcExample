using BlogAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseController<T> : Controller, IBaseController<T> where T: class
{
    private readonly IBaseService<T> _service;
    
    public BaseController(IBaseService<T> service)
    {
        _service = service;
    }
    
    [HttpGet]
    public IEnumerable<T> GetAll([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        return _service.GetAll(skip: (pageNumber - 1) * pageSize, take: pageSize);
    }
    
    [HttpGet("{id}")]
    public T GetById(int id)
    {
        return _service.GetById(id);
    }
    
    
    [HttpPost]
    public T Create([FromBody] T data)
    {
        return _service.Create(data);
    }
    
    [HttpPut]
    public T Put([FromQuery] int id, [FromBody] T data)
    {
        return _service.Update(id, data);
    }
    
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        _service.Delete(id);
    }
}