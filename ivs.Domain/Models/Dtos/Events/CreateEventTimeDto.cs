namespace ivs.Domain.Models.Dtos.Events;

public class CreateEventTimeDto
{
    public string? _id { get; set; }
    public string? ivsEventId { get; set; }
    public string? timeZone { get; set; }
    public string? startDateAndTime { get; set; }
    public string? endDateAndTime { get; set; }
    public string? createdAt { get; set; }
}