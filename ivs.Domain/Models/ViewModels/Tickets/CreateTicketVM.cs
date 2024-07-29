using System.ComponentModel.DataAnnotations;

namespace ivs.Domain.Models.ViewModels.Tickets;

public class CreateTicketVM
{
    
    public string? ivsEvent_id { get; set; }

    [Required(ErrorMessage = "Ticket Kind is required.")]
    public string? ticketKind { get; set; }

    [Required(ErrorMessage = "Payment Option ID is required.")]
    public string? paymentOptionId { get; set; }

    [Required(ErrorMessage = "Ticket Name is required.")]
    [StringLength(100, ErrorMessage = "Ticket Name can't be longer than 100 characters.")]
    public string? ticketName { get; set; }

    public string? ticketAmount { get; set; }

    [Range(1, 100, ErrorMessage = "Group Size must be between 1 and 100.")]
    public int groupSize { get; set; } = 1;

    [StringLength(500, ErrorMessage = "Ticket Description can't be longer than 500 characters.")]
    public string? ticketDescription { get; set; }

    [Required(ErrorMessage = "Ticket selling start date is required.")]
    public DateTime? ticketSalesStartDateAndTime { get; set; }
    
    [Required(ErrorMessage = "Ticket selling end date is required.")]
    public DateTime? ticketSalesEndDateAndTime { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Ticket In Stock must be a positive number.")]
    public int ticketInStock { get; set; }
}