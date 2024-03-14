namespace BlogAPI.Models.Dtos.Responses;

public record ShortCategoryDto(Guid Id, string Name, int PostCount = 0);
