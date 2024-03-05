using AutoMapper;
using BlogAPI.Common.DTO.CategoryDto;
using BlogAPI.Models.Entities;
using BlogAPI.Services;

namespace BlogAPI.Controllers;

public class CategoryController: BaseAsyncController<Category,Guid, ShortCategoryDto, DetailCategoryDto, CreateCategoryDto, UpdateCategoryDto>
{
    public CategoryController(IBaseAsyncService<Category, Guid> service, IMapper mapper) : base(service, mapper)
    {
    }
}