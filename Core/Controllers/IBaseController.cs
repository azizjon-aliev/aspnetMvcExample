using BlogAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Core.Controllers
{
    public interface IBaseController<TEntity, TShortDto, TDetailDto, in TCreateDto, in TUpdateDto>
        where TEntity : BaseEntity
    {
        Task<ActionResult<IEnumerable<TShortDto>>> GetAllAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 100);
        Task<ActionResult<TDetailDto>> GetByIdAsync(int id);
        Task<ActionResult<TDetailDto>> AddAsync([FromBody] TCreateDto data);
        Task<ActionResult<TDetailDto>> UpdateAsync(int id, [FromBody] TUpdateDto data);
        Task<ActionResult> RemoveAsync(int id);
    }
}