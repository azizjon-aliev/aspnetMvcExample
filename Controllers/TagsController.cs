using AutoMapper;
using BlogAPI.Common.DTO.TagDto;
using BlogAPI.Models.Entities;
using BlogAPI.Services;

namespace BlogAPI.Controllers;

public class TagsController: BaseController<Tag, Guid, ShortTagDto, DetailTagDto, CreateTagDto, UpdateTagDto>
{
    public TagsController(IBaseService<Tag, Guid> service, IMapper mapper) : base(service, mapper)
    {
    }
}