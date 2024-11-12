namespace ivs.Domain.Models.Dtos.Events;


public class GetEventByUserDataDto
{
    public decimal totalSales { get; set; }
    public decimal totalSettlement { get; set; }
    public List<GetEventByUserDto> record { get; set; }
}

public class GetEventByUserDto
{
    public string? _id { get; set; }
    public string? user_id { get; set; }
    public string? eventName { get; set; }
    public string? eventAddress { get; set; }
    public string? eventOption { get; set; }
    public string? createdAt { get; set; }
    public string? eventImagePath { get; set; }
    public string? status { get; set; }
}