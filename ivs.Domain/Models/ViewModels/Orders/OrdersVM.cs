namespace ivs.Domain.Models.ViewModels.Orders;

public class OrdersVM
{
    public OrderRequest OrderRequest { get; set; }
    public List<AttendanceVm> AttendeesRequest { get; set; }
}


public class OrderRequest
{
    public string? ivsEventId { get; set; }
    public decimal? totalOrderQuantity { get; set; }
    public decimal? totalServiceFee { get; set; }
    public decimal? totalTicketFee { get; set; }
    public decimal? percentageCharge { get; set; }
    public decimal? totalFee { get; set; }
    
    public decimal? gatewayFee { get; set; }
    public decimal? ivsNetRevenue { get; set; } 
    public decimal? ivsVat { get; set; }
    public decimal? totalServiceFeeAfterDeduction { get; set; }
}