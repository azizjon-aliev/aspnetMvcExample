using AutoMapper;
using BlogAPI.Models.Dtos.Responses;
using BlogAPI.Models.Dtos.Requests;
using BlogAPI.Models.Entities;
using BlogAPI.Services;
using BlogAPI.Core.Controllers;

namespace BlogAPI.Controllers;

public class PostsController: BaseController<Post, ShortPostDto, DetailPostDto, CreatePostDto, UpdatePostDto>
{
    public PostsController(IBaseService<Post> service, IMapper mapper) : base(service, mapper)
    {
    }
}