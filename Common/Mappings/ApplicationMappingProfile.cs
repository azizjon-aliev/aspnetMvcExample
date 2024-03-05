using AutoMapper;
using BlogAPI.Common.DTO.TagDto;
using BlogAPI.Common.DTO.CategoryDto;
using BlogAPI.Models.Entities;

namespace BlogAPI.Common.Mappings;

public class ApplicationMappingProfile: Profile
{
    public ApplicationMappingProfile()
    {
        // Tag
        CreateMap<Tag, ShortTagDto>().ReverseMap();
        CreateMap<Tag, DetailTagDto>().ReverseMap();
        CreateMap<Tag, CreateTagDto>().ReverseMap();
        CreateMap<Tag, UpdateTagDto>().ReverseMap();
        
        // Category
        CreateMap<Category, ShortCategoryDto>().ReverseMap();
        CreateMap<Category, DetailCategoryDto>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();
        CreateMap<Category, UpdateCategoryDto>().ReverseMap();
    }
}