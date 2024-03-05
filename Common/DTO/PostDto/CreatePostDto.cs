namespace BlogAPI.Common.DTO.PostDto;

public record CreatePostDto(string Title, string? Description, bool IsPublished, Guid CategoryId);
