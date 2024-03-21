namespace BlogAPI.Models.Entities;

using BlogAPI.Core.Models;


public class Category: BaseEntity
{
    public string Name { get; set; }
    public ICollection<Post> Posts { get; } = [];
}