using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.ViewModels.Orders
{
    public class AttendanceVm
    {

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Please enter your correct first name")]
        public string? firstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Please enter your correct last name")]
        public string? lastName { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(15, MinimumLength = 11, ErrorMessage = "Please enter your correct phone number")]
        public string? phoneNumber { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string? gender { get; set; }

        public string? orderId { get; set; }
        public string? ivsEventId { get; set; }
        public string? ticketId { get; set; }
        public string? eventTimeId { get; set; }
        public string? ticketQuantity { get; set; }
        public string? ticketPrice { get; set; }
        public string? ticketServiceFee { get; set; }
        public string? totalTicketServiceFee { get; set; }
        public string? totalTicketFee { get; set; }
        public string? totalTicketFeeAndServiceFee { get; set; }
        public string? purchaseLink { get; set; }
        public string? qrCode { get; set; }
        public string? code { get; set; }
        public string? qrImage { get; set; }
    }
}
