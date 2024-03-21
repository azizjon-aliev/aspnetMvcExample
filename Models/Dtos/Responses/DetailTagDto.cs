namespace BlogAPI.Models.Dtos.Responses;

public record DetailTagDto(int Id, string Name, ICollection<ShortPostDto> Posts);
