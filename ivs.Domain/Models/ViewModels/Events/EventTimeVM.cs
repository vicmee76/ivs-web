namespace ivs.Domain.Models.ViewModels.Events;

public class EventTimeVM
{
    public string? ivsEventId { get; set; }
    public DateTime? startDateAndTime { get; init; }
    public DateTime? endDateAndTime { get; init; }
    public string? timeZone { get; init; }
}