using ivs.Domain.Models.Dtos.Events;
using Newtonsoft.Json;

namespace ivs.Domain.Models.Dtos.Tickets;

public class TicketDto
{
    public string? _id { get; set; }
    public string? ivsEvent_id { get; set; }
    public string? eventTimeId { get; set; }
    public string? ticketKind { get; set; }
    public string? paymentOptionId { get; set; }
    public string? ticketName { get; set; }
    public TicketAmount? ticketAmount { get; set; }
    public int groupSize { get; set; }
    public string? ticketDescription { get; set; }
    public DateTime? ticketSalesEndDateAndTime { get; set; }
    public DateTime? ticketSalesStartDateAndTime { get; set; }
    public string? createdAt { get; set; }
    public int ticketInStock { get; set; }
    public EventTimeDto eventTimeDetails { get; set; }
}


public class TicketAmount
{
    [JsonProperty("$numberDecimal")]
    public decimal numberDecimal { get; set; }
}