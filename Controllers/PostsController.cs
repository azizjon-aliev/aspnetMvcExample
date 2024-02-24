using BlogAPI.Models;
using BlogAPI.Services;

namespace BlogAPI.Controllers;

public class PostsController: BaseController<Post, Guid>
{
    public PostsController(IBaseService<Post, Guid> service) : base(service)
    {
    }
}