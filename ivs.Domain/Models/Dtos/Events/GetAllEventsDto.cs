namespace ivs.Domain.Models.Dtos.Events;

public class GetAllEventsDto
{
    public string page { get; set; }
    public string limit { get; set; }
    public int totalPages { get; set; }
    public int totalItems { get; set; }
    public List<GetAllEventsDataDtos> events { get; set; }
}


public class GetAllEventsDataDtos
{
    public string _id { get; set; }
    public string user_id { get; set; }
    public string eventName { get; set; }
    public string eventAddress { get; set; }
    public string eventOption { get; set; }
    public string status { get; set; }
    public string createdAt { get; set; }
    public string eventCode { get; set; }
    public string eventImagePath { get; set; }
}