using AutoMapper;
using BlogAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using BlogAPI.Core.Services;

namespace BlogAPI.Core.Controllers
{
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public abstract class BaseController<TEntity, TShortDto, TDetailDto, TCreateDto, TUpdateDto>
        : ControllerBase, IBaseController<TEntity, TShortDto, TDetailDto, TCreateDto, TUpdateDto>
        where TEntity : BaseEntity
    {
        protected readonly IBaseService<TEntity> Service;
        protected readonly IMapper Mapper;

        public BaseController(IBaseService<TEntity> service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TShortDto>>> GetAllAsync([FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 100)
        {
            var entities = await Service.GetAllAsync(pageNumber, pageSize);
            var result = new List<TShortDto>();

            foreach (var entity in entities)
            {
                var dto = Mapper.Map<TShortDto>(entity);
                result.Add(dto);
            }

            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TDetailDto>> GetByIdAsync(int id)
        {
            var entity = await Service.GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            var dto = Mapper.Map<TDetailDto>(entity);
            return Ok(dto);
        }

        [HttpPost]
        public virtual async Task<ActionResult<TDetailDto>> AddAsync([FromBody] TCreateDto data)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            */

            var entity = Mapper.Map<TEntity>(data);
            
            var response = await Service.AddAsync(entity);

            var dto = Mapper.Map<TDetailDto>(response);
            
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public virtual async Task<ActionResult<TDetailDto>> UpdateAsync(int id, [FromBody] TUpdateDto data)
        {
            var entity = Mapper.Map<TEntity>(data);
            
            var response = await Service.UpdateAsync(id, entity);

            var dto = Mapper.Map<TDetailDto>(response);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public virtual async Task<ActionResult> RemoveAsync(int id)
        {
            var result = await Service.RemoveAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
