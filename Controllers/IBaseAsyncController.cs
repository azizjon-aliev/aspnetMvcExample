using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    public interface IBaseAsyncController<TEntity, in TKey, TShortDto, TDetailDto, in TCreateDto, in TUpdateDto>
        where TEntity : class
    {
        Task<ActionResult<IEnumerable<TShortDto>>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100);
        Task<ActionResult<TDetailDto>> GetById(TKey id);
        Task<ActionResult<TDetailDto>> Create([FromBody] TCreateDto data);
        Task<ActionResult<TDetailDto>> Update(TKey id, [FromBody] TUpdateDto data);
        Task<ActionResult> Delete(TKey id);
    }
}