using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.ViewModels.Payments
{
    public class MakePaymentVM
    {
        public string? orderId { get; set; }
        public string? paymentGateWay { get; set; }
    }
}
