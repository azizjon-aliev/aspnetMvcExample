using AutoMapper;
using BlogAPI.Models.Dtos.Responses;
using BlogAPI.Models.Dtos.Requests;
using BlogAPI.Models.Entities;
using BlogAPI.Core.Controllers;
using BlogAPI.Services;

namespace BlogAPI.Controllers;

public class TagsController : BaseController<Tag, ShortTagDto, DetailTagDto, CreateTagDto, UpdateTagDto>
{

    public TagsController(TagService service, IMapper mapper) : base(service, mapper)
    {
    }
}