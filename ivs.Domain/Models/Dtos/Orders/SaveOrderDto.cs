using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.Dtos.Orders
{
    public class SaveOrderDto
    {
        public string _Id { get; set; }
        public decimal totalOrderQuantity { get; set; }
        public decimal totalServiceFee { get; set; }
        public decimal totalTicketFee { get; set; }
        public decimal totalFee { get; set; }
        public string isActive { get; set; }
        public string orderEndTime { get; set; }
        public string createdAt { get; set; }
    }
}
