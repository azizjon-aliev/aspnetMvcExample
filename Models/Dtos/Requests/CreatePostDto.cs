namespace BlogAPI.Models.Dtos.Requests;

public record CreatePostDto(string Title, string? Description, bool IsPublished, Guid CategoryId);
