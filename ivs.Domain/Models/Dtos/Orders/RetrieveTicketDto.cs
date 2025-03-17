namespace ivs.Domain.Models.Dtos.Orders;

public class RetrieveTicketDto
{
    public string orderId { get; set; }
    public string eventName { get; set; }
    public string ticketName { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string ticketQuantity { get; set; }
    public string ticketPrice { get; set; }
    public string code { get; set; }
    public string paymentGateWayTransactionIds { get; set; }
    public string paymentGateWayTransactionStatuses { get; set; }
    public string paymentGateWayTransactionDates { get; set; }
}