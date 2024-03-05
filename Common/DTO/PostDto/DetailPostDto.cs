namespace BlogAPI.Common.DTO.PostDto;

public record DetailPostDto(Guid Id, string Title, string? Description, bool IsPublished, Guid CategoryId);
