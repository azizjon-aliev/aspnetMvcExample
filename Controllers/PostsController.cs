using AutoMapper;
using BlogAPI.Common.DTO.PostDto;
using BlogAPI.Models.Entities;
using BlogAPI.Services;

namespace BlogAPI.Controllers;

public class PostsController: BaseController<Post, Guid, ShortPostDto, DetailPostDto, CreatePostDto, UpdatePostDto>
{
    public PostsController(IBaseService<Post, Guid> service, IMapper mapper) : base(service, mapper)
    {
    }
}