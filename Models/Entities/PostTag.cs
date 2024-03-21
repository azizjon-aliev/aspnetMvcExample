namespace BlogAPI.Models.Entities;


public class PostTag
{
    public int PostId { get; set; }
    public int TagId { get; set; }
    public Post Post { get; } = null!;
    public Tag Tag { get; } = null!;
}