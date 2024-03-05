namespace BlogAPI.Models.Entities;

public class Tag: BaseEntity
{
    public string Name { get; set; }
    public List<Post> Posts { get; } = [];
}