using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.ViewModels.Orders
{
    public class ContactInformationVM
    {

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Please enter your correct first name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Please enter your correct last name")]
        public string? LastName { get; set; }


        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [StringLength(15, MinimumLength = 11, ErrorMessage = "Please enter your correct phone number")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string? Gender { get; set; }

    }
}
