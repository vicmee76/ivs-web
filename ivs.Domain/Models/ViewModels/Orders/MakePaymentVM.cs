using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.ViewModels.Orders
{
    public class MakePaymentVM
    {
        public string orderId { get; set; }
        public string paymentGateWay { get; set; }
    }
}
