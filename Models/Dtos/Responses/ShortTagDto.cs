namespace BlogAPI.Models.Dtos.Responses;

public record ShortTagDto(int Id, string Name, int PostsCount = 0);
