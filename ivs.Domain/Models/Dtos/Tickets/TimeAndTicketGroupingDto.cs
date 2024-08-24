namespace ivs.Domain.Models.Dtos.Tickets;

public class TimeAndTicketGroupingDto
{
    public string EventTimeId { get; set; }
    public string StartDateAndTime { get; set; }
    public List<TicketDto> Tickets { get; set; }
}