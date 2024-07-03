namespace ivs.Domain.Models.ViewModels.Tickets;

public class CreateTicketVM
{
    public string? ivsEvent_id { get; set; }
    public string? ticketKind { get; set; }
    public string? paymentOptionId { get; set; }
    public string? ticketName { get; set; }
    public string? ticketAmount { get; set; }
    public int groupSize { get; set; }
    public string? ticketDescription { get; set; }
    public DateTime? ticketSalesEndDateAndTime { get; set; }
    public int ticketInStock { get; set; }
}