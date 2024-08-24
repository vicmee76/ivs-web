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
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string? Gender { get; set; }

    }
}
