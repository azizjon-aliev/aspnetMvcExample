using BlogAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogApi.Data.EntityTypeConfigurations;

public class TagConfiguration: IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(t => t.Id);
        builder.HasIndex(t => t.Name).IsUnique();
        builder.Property(t => t.Name).HasMaxLength(200).IsRequired();

        builder.HasMany(t => t.Posts)
            .WithMany(p => p.Tags)
            .UsingEntity<PostTag>();
    }
}