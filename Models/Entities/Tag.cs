namespace BlogAPI.Models.Entities;

using BlogAPI.Core.Models;


public class Tag: BaseEntity
{
    public string Name { get; set; }
    public List<Post> Posts { get; } = [];
}