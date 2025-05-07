namespace ivs.Domain.Models.Dtos.Events;

public class DiscountResponseDto
{
    public string _id { get; set; }
    public string eventId { get; set; }
    public string discountType { get; set; }
    public string discountCode { get; set; }
    public decimal discountValue { get; set; }
    public bool isActive { get; set; }
    public string createdAt { get; set; }
}