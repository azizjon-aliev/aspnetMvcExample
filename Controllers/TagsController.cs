using AutoMapper;
using BlogAPI.Models.Dtos.Responses;
using BlogAPI.Models.Dtos.Requests;
using BlogAPI.Models.Entities;
using BlogAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers;

public class TagsController : BaseController<Tag, Guid, ShortTagDto, DetailTagDto, CreateTagDto, UpdateTagDto>
{
    public TagsController(IBaseService<Tag, Guid> service, IMapper mapper) : base(service, mapper)
    {
    }

    [HttpGet]
    public override async Task<ActionResult<IEnumerable<ShortTagDto>>> GetAllAsync([FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 100)
    {
        var entities = await Service.GetAllAsync(pageNumber, pageSize);
        var result = new List<ShortTagDto>();

        foreach (var entity in entities)
        {
            Console.WriteLine(entity.Posts.Count);
            var dto = Mapper.Map<ShortTagDto>(entity);
            result.Add(dto);
        }

        return Ok(result);
    }
}