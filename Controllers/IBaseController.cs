using BlogAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    public interface IBaseController<TEntity, in TKey, TShortDto, TDetailDto, in TCreateDto, in TUpdateDto>
        where TEntity : BaseEntity
    {
        Task<ActionResult<IEnumerable<TShortDto>>> GetAllAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100);
        Task<ActionResult<TDetailDto>> GetByIdAsync(TKey id);
        Task<ActionResult<TDetailDto>> AddAsync([FromBody] TCreateDto data);
        Task<ActionResult<TDetailDto>> UpdateAsync(TKey id, [FromBody] TUpdateDto data);
        Task<ActionResult> RemoveAsync(TKey id);
    }
}