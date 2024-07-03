using System.ComponentModel.DataAnnotations;

namespace ivs.Domain.Models.ViewModels.Events;

public class CreateEventVM
{
    public string? user_id { get; set; }
    
    [Required]
    public string? eventName { get; set; }
    
    [Required]
    public string? eventDescription { get; set; }
    
    [Required]
    public string? eventAddress { get; set; }
    
    [Required]
    public string? eventState { get; set; }
    public string? adressPin { get; set; }
    
    [Required]
    public string? eventTypeId { get; set; }
    
    [Required]
    public string? eventOption { get; set; }
    public string? webLink { get; set; }
    public string? facebookLink { get; set; }
    public string? twitterLink { get; set; }
    public string? instagramLink { get; set; }
}