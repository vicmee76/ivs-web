using Newtonsoft.Json;

namespace ivs.Domain.Models.Dtos.Events;

public class GetEventDetailsDto
{
    public string eventImagePath;
    public string? eventImageData;
    public string _id { get; set; }
    public string eventName { get; set; }
    public string eventDescription { get; set; }
    public string eventAddress { get; set; }
    public string eventState { get; set; }
    public string adressPin { get; set; }
    public string eventOption { get; set; }
    public string status { get; set; }
    public string createdAt { get; set; }
    public string eventLongLink { get; set; }
    public string eventShortLink { get; set; }
    public string qrCodeLink { get; set; }
    public string updatedAt { get; set; }
    public string eventImage { get; set; }
    public string webLink { get; set; }
    public string facebookLink { get; set; }
    public string twitterLink { get; set; }
    public string instagramLink { get; set; }
    public List<User> Users { get; set; }
    public List<EventType> EventType { get; set; }
    public List<EventTime> EventTime { get; set; }
    public List<Ticket> Tickets { get; set; }
}

public class EventTime
{
    public string _id { get; set; }
    public string ivsEventId { get; set; }
    public string timeZone { get; set; }
    public string startDateAndTime { get; set; }
    public string endDateAndTime { get; set; }
    public string createdAt { get; set; }
}

public class EventType
{
    public string _id { get; set; }
    public string name { get; set; }
    public string createdAt { get; set; }
}



public class Ticket
{
    public string _id { get; set; }
    public string ivsEvent_id { get; set; }
    public string ticketKind { get; set; }
    public string paymentOptionId { get; set; }
    public string ticketName { get; set; }
    public TicketAmount? ticketAmount { get; set; }
    public string? ticketInStock { get; set; }
    public string groupSize { get; set; }
    public string ticketDescription { get; set; }
    public string ticketSalesEndDateAndTime { get; set; }
    public string createdAt { get; set; }
}

public class TicketAmount
{
    [JsonProperty("$numberDecimal")]
    public decimal numberDecimal { get; set; }
}

public class User
{
    public string _id { get; set; }
    public string fullname { get; set; }
    public string email { get; set; }
    public string createdAt { get; set; }
}