using AutoMapper;
using BlogAPI.Models.Dtos.Responses;
using BlogAPI.Models.Dtos.Requests;
using BlogAPI.Models.Entities;
using BlogAPI.Core.Services;
using BlogAPI.Core.Controllers;

namespace BlogAPI.Controllers;

public class TagsController : BaseController<Tag, ShortTagDto, DetailTagDto, CreateTagDto, UpdateTagDto>
{
    public TagsController(IBaseService<Tag> service, IMapper mapper) : base(service, mapper)
    {
    }
}