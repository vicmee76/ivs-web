namespace ivs.Domain.Models.Dtos.Events;

public class GetEventByUserDto
{
    public string? _id { get; set; }
    public string? user_id { get; set; }
    public string? eventName { get; set; }
    public string? eventAddress { get; set; }
    public string? eventOption { get; set; }
    public string? createdAt { get; set; }
    public string? eventImageData { get; set; }
    public string? status { get; set; }
}