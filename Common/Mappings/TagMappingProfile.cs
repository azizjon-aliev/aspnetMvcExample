using AutoMapper;
using BlogAPI.Models.Entities;
using BlogAPI.Models.Dtos.Responses;
using BlogAPI.Models.Dtos.Requests;

namespace BlogAPI.Common.Mappings;

public class TagMappingProfile: Profile
{
    public TagMappingProfile()
    {
        CreateMap<Tag, ShortTagDto>().ReverseMap();
        CreateMap<Tag, DetailTagDto>().ReverseMap();
        CreateMap<Tag, CreateTagDto>().ReverseMap();
        CreateMap<Tag, UpdateTagDto>().ReverseMap();
    }
}