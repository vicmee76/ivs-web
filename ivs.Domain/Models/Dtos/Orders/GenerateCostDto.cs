namespace ivs.Domain.Models.Dtos.Orders;

public class GenerateCostDto
{
    public int totalTicketPurchased { get; set; }
    public decimal totalServiceFee { get; set; }
    public decimal totalTicketFee { get; set; }
    public decimal totalAmount { get; set; }
    public List<TicketsObjects>? tickets { get; set; }
}

public class TicketsObjects
{
    public string? ticketId { get; set; }
    public string? eventTimeId { get; set; }
    public string? ticketKind { get; set; }
    public string? ticketName { get; set; }
    public int ticketQuantity { get; set; }
    public decimal ticketPrice { get; set; }
    public decimal ticketServiceFee { get; set; }
    public decimal totalTicketServiceFee { get; set; }
    public decimal totalTicketFee { get; set; }
    public decimal totalTicketFeeAndServiceFee { get; set; }
}