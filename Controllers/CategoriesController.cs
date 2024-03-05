using AutoMapper;
using BlogAPI.Common.DTO.CategoryDto;
using BlogAPI.Models.Entities;
using BlogAPI.Services;

namespace BlogAPI.Controllers;

public class CategoriesController: BaseAsyncController<Category,Guid, ShortCategoryDto, DetailCategoryDto, CreateCategoryDto, UpdateCategoryDto>
{
    public CategoriesController(IBaseAsyncService<Category, Guid> service, IMapper mapper) : base(service, mapper)
    {
    }
}