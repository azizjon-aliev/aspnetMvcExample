using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApi.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureCategory(modelBuilder);
        ConfigureTag(modelBuilder);
        ConfigurePost(modelBuilder);
    }

    private void ConfigureCategory(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(e =>
        {
            e.HasMany(p => p.Posts)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();
            e.HasIndex(p => p.Name)
                .IsUnique();
            e.Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();
        });
    }
    
    private void ConfigureTag(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tag>(e =>
        {
            e.HasMany(p => p.Posts)
                .WithMany(p => p.Tags);
            e.HasIndex(p => p.Name)
                .IsUnique();
            e.Property(p => p.Name)
                .HasMaxLength(200)
                .IsRequired();
        });
    }
    
    private void ConfigurePost(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>(e =>
        {
            e.HasIndex(p => p.Title)
                .IsUnique();
            e.Property(p => p.Title)
                .HasMaxLength(200)
                .IsRequired();
            e.Property(p => p.Description)
                .HasMaxLength(2000)
                .IsRequired(false);
            e.HasOne(p => p.Category)
                .WithMany(p => p.Posts)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();
            e.HasMany(p => p.Tags)
                .WithMany(p => p.Posts);
        });
    }
}