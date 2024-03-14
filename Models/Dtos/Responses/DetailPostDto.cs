namespace BlogAPI.Models.Dtos.Responses;

public record DetailPostDto(int Id, string Title, string? Description, bool IsPublished, int CategoryId);
