using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using BlogAPI.Services;

namespace BlogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseAsyncController<TEntity, TKey, TShortDto, TDetailDto, TCreateDto, TUpdateDto, TService> 
        : ControllerBase, IBaseAsyncController<TEntity, TKey, TShortDto, TDetailDto, TCreateDto, TUpdateDto>
        where TEntity : class
    {
        private readonly IBaseAsyncService<TEntity, TKey> _service;
        private readonly IMapper _mapper;

        public BaseAsyncController(IBaseAsyncService<TEntity, TKey> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TShortDto>>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100)
        {
            var entities = await _service.GetAll(pageNumber, pageSize);
            var result = new List<TShortDto>();
            
            foreach (var entity in entities)
            {
                var dto = _mapper<TShortDto>(entity);
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

            var dto = /* map to TDetailDto */;
            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult<TDetailDto>> Create([FromBody] TCreateDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = /* map from TCreateDto */;
            await _service.Create(entity);

            var dto = /* map to TDetailDto */;
            return CreatedAtAction(nameof(GetById), new { id = /* get the ID of the created entity */ }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TDetailDto>> Update(TKey id, [FromBody] TUpdateDto data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingEntity = await _service.GetById(id);

            if (existingEntity == null)
            {
                return NotFound();
            }

            /* Update properties of existingEntity using data */

            await _service.Update(existingEntity);

            var dto = /* map to TDetailDto */;
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
