using BlogAPI.Models;
using BlogAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers;

[ApiController]
[Route("api/v{v:apiVersion}/[controller]")]
public class TagsController: ControllerBase
{
    private readonly IBaseService<Tag, Guid> _service;
    private readonly ILogger<TagsController> _logger;

    public TagsController(IBaseService<Tag, Guid> service, ILogger<TagsController> logger)
    {
        _service = service;
        _logger = logger;
    }
    
    
}