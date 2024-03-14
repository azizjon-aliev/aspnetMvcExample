namespace BlogAPI.Models.Entities;

using BlogAPI.Core.Models;


public class Category: BaseEntity
{
    public string Name { get; set; }
    public List<Post> Posts { get; } = new List<Post>();
}