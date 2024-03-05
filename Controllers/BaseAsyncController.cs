using AutoMapper;
using BlogAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using BlogAPI.Services;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class BaseAsyncController<TEntity, TKey, TShortDto, TDetailDto, TCreateDto, TUpdateDto>
        : ControllerBase, IBaseAsyncController<TEntity, TKey, TShortDto, TDetailDto, TCreateDto, TUpdateDto>
        where TEntity : BaseEntity
    {
        private readonly IBaseAsyncService<TEntity, TKey> _service;
        private readonly IMapper _mapper;

        public BaseAsyncController(IBaseAsyncService<TEntity, TKey> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TShortDto>>> GetAll([FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 100)
        {
            var entities = await _service.GetAll(pageNumber, pageSize);
            var result = new List<TShortDto>();

            foreach (var entity in entities)
            {
                var dto = _mapper.Map<TShortDto>(entity);
                result.Add(dto);
            }

            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<TDetailDto>> GetById(TKey id)
        {
            var entity = await _service.GetById(id);

            if (entity == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<TDetailDto>(entity);
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<TDetailDto>> Create([FromBody] TCreateDto data)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            */

            var entity = _mapper.Map<TEntity>(data);
            
            var response = await _service.Create(entity);

            var dto = _mapper.Map<TDetailDto>(response);
            
            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TDetailDto>> Update(TKey id, [FromBody] TUpdateDto data)
        {
            var entity = _mapper.Map<TEntity>(data);
            
            var response = await _service.Update(id, entity);

            var dto = _mapper.Map<TDetailDto>(response);
            return Ok(dto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(TKey id)
        {
            var result = await _service.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
