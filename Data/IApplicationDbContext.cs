using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Data;

public interface IApplicationDbContext: IDbContext
{
    DbSet<Tag> Tags { get; set; }
    DbSet<Category> Categories { get; set; }
    DbSet<Post> Posts { get; set; }
    
    int SaveChanges();
}