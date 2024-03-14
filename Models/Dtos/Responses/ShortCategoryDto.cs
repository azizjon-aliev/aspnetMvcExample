namespace BlogAPI.Models.Dtos.Responses;

public record ShortCategoryDto(int Id, string Name, int PostCount = 0);
