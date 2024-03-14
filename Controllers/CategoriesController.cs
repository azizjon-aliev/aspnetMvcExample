using AutoMapper;
using BlogAPI.Models.Dtos.Responses;
using BlogAPI.Models.Dtos.Requests;
using BlogAPI.Models.Entities;
using BlogAPI.Core.Services;
using BlogAPI.Core.Controllers;

namespace BlogAPI.Controllers;

public class CategoriesController: BaseController<Category, ShortCategoryDto, DetailCategoryDto, CreateCategoryDto, UpdateCategoryDto>
{
    public CategoriesController(IBaseService<Category> service, IMapper mapper) : base(service, mapper)
    {
    }
}