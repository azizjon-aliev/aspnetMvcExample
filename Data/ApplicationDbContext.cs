using BlogApi.Data.EntityTypeConfigurations;
using BlogAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Post> Posts { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Ignore<BaseEntity>();
        builder.ApplyConfiguration(new TagConfiguration());
        builder.ApplyConfiguration(new CategoryConfiguration());
        builder.ApplyConfiguration(new PostConfiguration());
        base.OnModelCreating(builder);
    }
}