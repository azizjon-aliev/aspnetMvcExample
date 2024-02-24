using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApi.Data.EntityTypeConfigurations;

public class CategoryConfiguration: IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasMany(p => p.Posts)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .IsRequired();
        builder.HasIndex(p => p.Name)
            .IsUnique();
        builder.Property(p => p.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}