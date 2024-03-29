using AutoMapper;
using BlogAPI.Models.Entities;
using BlogAPI.Models.Dtos.Responses;
using BlogAPI.Models.Dtos.Requests;

namespace BlogAPI.Common.Mappings;

public class TagMappingProfile: Profile
{
    public TagMappingProfile()
    {
        CreateMap<Tag, ShortTagDto>()
            .ForMember(dest => dest.PostsCount, opt => opt.MapFrom(src => src.Posts.Count));

        CreateMap<Tag, DetailTagDto>()
            .ForMember(dest => dest.Posts, opt => opt.MapFrom(src => src.Posts.Select(x => new ShortPostDto( x.Id, x.Title ))));
        
        CreateMap<DetailCategoryDto, Tag>();
        CreateMap<Tag, CreateTagDto>().ReverseMap();
        CreateMap<Tag, UpdateTagDto>().ReverseMap();
    }
}

// 64fa3cbc-d893-41f1-9243-e64889bcbe37

// category id - 31aeee7c-fda5-4891-b64f-e3a44ff39786

// post id - 8235ee37-90fc-417f-b1e7-64f5094235b8