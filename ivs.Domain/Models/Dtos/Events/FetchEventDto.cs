using Newtonsoft.Json;

namespace ivs.Domain.Models.Dtos.Events;

public class FetchEventDto
{
    [JsonProperty("_id")] 
    public string _id { get; set; }

    [JsonProperty("eventName")] 
    public string eventName { get; set; }

    [JsonProperty("eventAddress")] 
    public string eventAddress { get; set; }

    [JsonProperty("eventState")] 
    public string eventState { get; set; }

    [JsonProperty("eventOption")] 
    public string eventOption { get; set; }

    [JsonProperty("createdAt")] 
    public string createdAt { get; set; }

    [JsonProperty("eventImageData")] 
    public string eventImageData { get; set; }

    [JsonProperty("eventTimes")] 
    public List<FewEventTime> eventTimes { get; set; }

    [JsonProperty("eventTickets")] 
    public List<FewEventTicket> eventTickets { get; set; }

    [JsonProperty("eventTypes")] 
    public List<FewEventType> eventTypes { get; set; }

    [JsonProperty("paymentOptions")] 
    public List<FewPaymentOption> paymentOptions { get; set; }
}

public class FewEventTicket
{
    [JsonProperty("ticketKind")]
    public string ticketKind { get; set; }

    [JsonProperty("ticketInStock")]
    public string ticketInStock { get; set; }

    [JsonProperty("ticketAmount")]
    public TicketAmount ticketAmount { get; set; }
}

public class FewEventTime
{
    [JsonProperty("startDateAndTime")]
    public string startDateAndTime { get; set; }

    [JsonProperty("endDateAndTime")]
    public string endDateAndTime { get; set; }
}

public class FewEventType
{
    [JsonProperty("name")]
    public string name { get; set; }
}

public class FewPaymentOption
{
    [JsonProperty("name")]
    public string name { get; set; }
}

