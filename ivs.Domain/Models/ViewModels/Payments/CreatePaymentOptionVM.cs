
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.ViewModels.Payments
{
    public class CreatePaymentOptionVM
    {
        public string name { get; set; }

        public string description { get; set; }
        public string amount { get; set; }

        public string metaAmountPercentage { get; set; }

        public int? maxUsers { get; set; }
        public int? capAmount { get; set; }
        public bool isSpecial { get; set; }
    }
}
