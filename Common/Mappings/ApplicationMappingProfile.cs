using AutoMapper;
using BlogAPI.Common.DTO.TagDto;
using BlogAPI.Models.Entities;

namespace BlogAPI.Common.Mappings;

public class ApplicationMappingProfile: Profile
{
    public ApplicationMappingProfile()
    {
        CreateMap<Tag, ShortTagDto>().ReverseMap();
        CreateMap<Tag, DetailTagDto>().ReverseMap();
        CreateMap<Tag, CreateTagDto>().ReverseMap();
        CreateMap<Tag, UpdateTagDto>().ReverseMap();
    }
}