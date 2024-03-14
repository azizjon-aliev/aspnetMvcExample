namespace BlogAPI.Models.Dtos.Requests;

public record UpdatePostDto(string Title, string? Description, bool IsPublished, int CategoryId);
