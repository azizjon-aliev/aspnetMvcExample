namespace BlogAPI.Common.DTO.PostDto;

public record UpdatePostDto(string Title, string? Description, bool IsPublished, Guid CategoryId);
