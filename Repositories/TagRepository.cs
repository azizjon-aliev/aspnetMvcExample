using BlogApi.Data;
using BlogAPI.Core.Repositories;
using BlogAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace BlogAPI.Repositories;
   

public class TagRepository : BaseRepository<Tag>
{
    public TagRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<IEnumerable<Tag>> GetAllAsync()
    {
        return await _dbContext.Tags.Include(x => x.Posts).ToListAsync();
    }


    public override async Task<Tag?> GetByIdAsync(int id)
    {
        return await _dbContext.Tags.Include(x => x.Posts).FirstOrDefaultAsync(x => x.Id == id);
    }
}