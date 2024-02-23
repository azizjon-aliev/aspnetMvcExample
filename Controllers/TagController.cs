using BlogAPI.Models;
using BlogAPI.Services;

namespace BlogAPI.Controllers;

public class TagController: BaseController<Tag>
{
    public TagController(IBaseService<Tag> service) : base(service)
    {
    }
}