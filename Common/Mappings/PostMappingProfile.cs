using AutoMapper;
using BlogAPI.Models.Entities;
using BlogAPI.Models.Dtos.Responses;
using BlogAPI.Models.Dtos.Requests;

namespace BlogAPI.Common.Mappings;

public class PostMappingProfile: Profile
{
    public PostMappingProfile()
    {
        CreateMap<Post, ShortPostDto>().ReverseMap();
        CreateMap<Post, DetailPostDto>().ReverseMap();
        CreateMap<Post, CreatePostDto>().ReverseMap();
        CreateMap<Post, UpdatePostDto>().ReverseMap();
    }
}