using System.ComponentModel.DataAnnotations;

namespace ivs.Domain.Models.ViewModels.Events;

public class EventTimeVM
{
    public string? ivsEventId { get; set; }
    
    [Required(ErrorMessage = "Start date is required")]
    public DateTime? startDateAndTime { get; init; }
    
    [Required(ErrorMessage = "End date is required")]
    public DateTime? endDateAndTime { get; init; }
    public string? timeZone { get; init; }
}