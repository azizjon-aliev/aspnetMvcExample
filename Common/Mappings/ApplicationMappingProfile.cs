using AutoMapper;
using BlogAPI.Models.Entities;
using BlogAPI.Models.Dtos.Responses;
using BlogAPI.Models.Dtos.Requests;

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
        
        // Post
        CreateMap<Post, ShortPostDto>().ReverseMap();
        CreateMap<Post, DetailPostDto>().ReverseMap();
        CreateMap<Post, CreatePostDto>().ReverseMap();
        CreateMap<Post, UpdatePostDto>().ReverseMap();
    }
}