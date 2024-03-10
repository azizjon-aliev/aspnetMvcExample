namespace BlogAPI.Models.Dtos.Responses;

public record DetailPostDto(Guid Id, string Title, string? Description, bool IsPublished, Guid CategoryId);
