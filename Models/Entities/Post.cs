namespace BlogAPI.Models.Entities;

public class Post: BaseEntity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool IsPublished { get; set; }
    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public List<Tag> Tags { get; set; } = [];
}