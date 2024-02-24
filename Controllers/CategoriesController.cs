using BlogAPI.Models;
using BlogAPI.Services;

namespace BlogAPI.Controllers;

public class CategoriesController: BaseController<Category, Guid>
{
    public CategoriesController(IBaseService<Category, Guid> service) : base(service)
    {
    }
}