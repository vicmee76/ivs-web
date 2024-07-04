using System.ComponentModel.DataAnnotations;

namespace ivs.Domain.Models.ViewModels.Events;

public class CreateEventVM
{
    public string? user_id { get; set; }
    
    [Required(ErrorMessage = "Event name is required")]
    public string? eventName { get; set; }
    
    [Required(ErrorMessage = "Event description is required")]
    public string? eventDescription { get; set; }
    
    [Required(ErrorMessage = "Event address is required")]
    public string? eventAddress { get; set; }
    
    [Required(ErrorMessage = "Event state is required")]
    public string? eventState { get; set; }
    public string? adressPin { get; set; }
    
    [Required(ErrorMessage = "Please select an event type option")]
    public string? eventTypeId { get; set; }
    
    [Required(ErrorMessage = "Please select and event option")]
    public string? eventOption { get; set; }
    public string? webLink { get; set; }
    public string? facebookLink { get; set; }
    public string? twitterLink { get; set; }
    public string? instagramLink { get; set; }
}