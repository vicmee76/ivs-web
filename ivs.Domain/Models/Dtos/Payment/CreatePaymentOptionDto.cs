using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.Dtos.Payment
{
    public class CreatePaymentOptionDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Payment option must be at least 3 characters long")]
        public string name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Description must be at least 3 characters long")]
        public string description { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        public decimal amount { get; set; }

        [Required(ErrorMessage = "Amount percentage is required.")]
        [Range(0, 20, ErrorMessage = "percentage must be between 0 and 20 %.")]
        public decimal metaAmountPercentage { get; set; } = 1;

        [Required(ErrorMessage = "Max user is required.")]
        public int maxUsers { get; set; } = 50000;
        
        public bool isSpecial { get; set; } = false;

        [Required(ErrorMessage = "Cap amount is required.")]
        public int capAmount { get; set; } = 2000;
    }
}
