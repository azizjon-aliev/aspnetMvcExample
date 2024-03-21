namespace BlogAPI.Models.Entities;

using BlogAPI.Core.Models;


public class Post: BaseEntity
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public bool IsPublished { get; set; } = true;
    public int CategoryId { get; set; }
    public Category Category { get; } = null!;
    public ICollection<Tag> Tags { get; } = [];
}