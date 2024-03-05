using BlogAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApi.Data.EntityTypeConfigurations;

public class PostConfiguration: IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.HasKey(p => p.Id);
        builder.HasIndex(p => p.Title)
            .IsUnique();
        builder.Property(p => p.Title)
            .HasMaxLength(200)
            .IsRequired();
        builder.Property(p => p.Description)
            .HasMaxLength(2000)
            .IsRequired(false);
        builder.HasOne(p => p.Category)
            .WithMany(p => p.Posts)
            .HasForeignKey(p => p.CategoryId)
            .IsRequired();
        builder.HasMany(p => p.Tags)
            .WithMany(p => p.Posts);
    }
}