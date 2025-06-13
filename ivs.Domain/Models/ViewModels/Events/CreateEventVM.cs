using System.ComponentModel.DataAnnotations;

namespace ivs.Domain.Models.ViewModels.Events;

public class CreateEventVM
{
    public string? user_id { get; set; }
    
    [Required(ErrorMessage = "Event name is required")]
    [MinLength(3, ErrorMessage = "Event name should be more than 3 characters.")]
    public string? eventName { get; set; }
    
    [Required(ErrorMessage = "Event code is required")]
    [MinLength(2, ErrorMessage = "Should be more than 2 characters.")]
    [RegularExpression(@"^[a-zA-Z0-9-_]+$", ErrorMessage = "Only letters, numbers, and '-', '_' are allowed.")]
    public string? eventCode { get; set; }
    
    [Required(ErrorMessage = "Event description is required")]
    public string? eventDescription { get; set; }
    
    [Required(ErrorMessage = "Event address is required")]
    [MinLength(5, ErrorMessage = "Address should be more than 5 characters.")]
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