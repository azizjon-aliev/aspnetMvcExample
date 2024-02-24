using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApi.Data.EntityTypeConfigurations;

public class TagConfiguration: IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasMany(p => p.Posts)
            .WithMany(p => p.Tags);
        builder.HasIndex(p => p.Name)
            .IsUnique();
        builder.Property(p => p.Name)
            .HasMaxLength(200)
            .IsRequired();
    }
}