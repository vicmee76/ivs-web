namespace ivs.Domain.Models.ViewModels.Orders;

public class OrdersVM
{
    public OrderRequest OrderRequest { get; set; }
    public List<AttendanceVm> AttendeesRequest { get; set; }
}


public class OrderRequest
{
    public string? ivsEventId { get; set; }
    public string? totalOrderQuantity { get; set; }
    public string? totalServiceFee { get; set; }
    public string? totalTicketFee { get; set; }
    public string? percentageCharge { get; set; }
    public string? totalFee { get; set; }
}