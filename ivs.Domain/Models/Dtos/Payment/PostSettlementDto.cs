using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.Dtos.Payment
{
    public class PostSettlementDto
    {
        public string userId { get; set; }
        public string eventId { get; set; }
        public string amountSettled { get; set; }
    }
}