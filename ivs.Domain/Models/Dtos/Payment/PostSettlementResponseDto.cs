using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.Dtos.Payment
{
    public class PostSettlementResponseDto
    {
        public string transactionId { get; set; }
        public string settlementTransferId { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string amount { get; set; }
    }
}
