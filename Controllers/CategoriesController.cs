using AutoMapper;
using BlogAPI.Models.Dtos.Responses;
using BlogAPI.Models.Dtos.Requests;
using BlogAPI.Models.Entities;
using BlogAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers;

public class CategoriesController: BaseController<Category,Guid, ShortCategoryDto, DetailCategoryDto, CreateCategoryDto, UpdateCategoryDto>
{
    public CategoriesController(IBaseService<Category, Guid> service, IMapper mapper) : base(service, mapper)
    {
    }
}