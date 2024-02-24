using BlogAPI.Models;
using BlogAPI.Services;

namespace BlogAPI.Controllers;

public class TagsController: BaseController<Tag, Guid>
{
    public TagsController(IBaseService<Tag, Guid> service) : base(service)
    {
    }
}