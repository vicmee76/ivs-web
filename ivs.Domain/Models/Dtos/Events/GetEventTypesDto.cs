namespace ivs.Domain.Models.Dtos.Events;

public class GetEventTypesDto
{
    public string? _id { get; set; }
    public string? name { get; set; }
    public string? isActive { get; set; }
    public bool? isDeleted { get; set; }
    public string? createdAt { get; set; }
}