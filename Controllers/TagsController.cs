using BlogAPI.Models;
using BlogAPI.Services;

namespace BlogAPI.Controllers;

public class TagsController: BaseController<Tag>
{
    public TagsController(IBaseService<Tag> service) : base(service)
    {
    }
}