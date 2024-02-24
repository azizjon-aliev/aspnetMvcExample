using BlogAPI.Models;
using BlogAPI.Models.DTO;
using BlogAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers;

public class TagsController: BaseController<Tag, Guid>
{
    public TagsController(IBaseService<Tag, Guid> service) : base(service)
    {
    }
}