using AutoMapper;
using BlogAPI.Models.Entities;
using BlogAPI.Models.Dtos.Responses;
using BlogAPI.Models.Dtos.Requests;

namespace BlogAPI.Common.Mappings;

public class CategoryMappingProfile: Profile
{
    public CategoryMappingProfile()
    {
        CreateMap<Category, ShortCategoryDto>().ReverseMap();
        CreateMap<Category, DetailCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
    }
}