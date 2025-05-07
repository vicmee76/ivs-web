using System.ComponentModel.DataAnnotations;

namespace ivs.Domain.Models.ViewModels.Events;

public class CreateDiscountVM
{
    public string? eventId { get; set; }
    
    [Required(ErrorMessage = "Select a discount type")]
    public string discountType { get; set; }
    
    [Required(ErrorMessage = "Disccount value is required")]
    [Range(0.01, 100, ErrorMessage = "Discount value must be greater than 0")]
    public decimal discountValue { get; set; }
    
    [Required(ErrorMessage = "Enter your discount code")]
    public string discountCode { get; set; }
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var allowedTypes = new[] { "percentage" };
        if (!allowedTypes.Contains(discountType?.ToUpper()))
        {
            yield return new ValidationResult("Discount type must be 'percentage'", new[] { nameof(discountType) });
        }
    }
    
}