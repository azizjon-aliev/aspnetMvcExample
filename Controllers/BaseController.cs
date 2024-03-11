using Asp.Versioning;
using AutoMapper;
using BlogAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using BlogAPI.Services;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class BaseController<TEntity, TKey, TShortDto, TDetailDto, TCreateDto, TUpdateDto>
        : ControllerBase, IBaseController<TEntity, TKey, TShortDto, TDetailDto, TCreateDto, TUpdateDto>
        where TEntity : BaseEntity
    {
        private readonly IBaseService<TEntity, TKey> _service;
        private readonly IMapper _mapper;

        public BaseController(IBaseService<TEntity, TKey> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TShortDto>>> GetAllAsync([FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 100)
        {
            var entities = await _service.GetAllAsync(pageNumber, pageSize);
            var result = new List<TShortDto>();

            foreach (var entity in entities)
            {
                var dto = _mapper.Map<TShortDto>(entity);
                result.Add(dto);
            }

            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TDetailDto>> GetByIdAsync(TKey id)
        {
            var entity = await _service.GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<TDetailDto>(entity);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<TDetailDto>> AddAsync([FromBody] TCreateDto data)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            */

            var entity = _mapper.Map<TEntity>(data);
            
            var response = await _service.AddAsync(entity);

            var dto = _mapper.Map<TDetailDto>(response);
            
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TDetailDto>> UpdateAsync(TKey id, [FromBody] TUpdateDto data)
        {
            var entity = _mapper.Map<TEntity>(data);
            
            var response = await _service.UpdateAsync(id, entity);

            var dto = _mapper.Map<TDetailDto>(response);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveAsync(TKey id)
        {
            var result = await _service.RemoveAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
