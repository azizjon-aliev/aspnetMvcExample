namespace BlogAPI.Models.Entities;

public class Category: BaseEntity
{
    public string Name { get; set; }
    public ICollection<Post> Posts { get; } = new List<Post>();
}