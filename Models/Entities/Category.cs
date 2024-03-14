namespace BlogAPI.Models.Entities;

public class Category: BaseEntity
{
    public string Name { get; set; }
    public List<Post> Posts { get; } = new List<Post>();
}