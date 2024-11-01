using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.Dtos.Payment
{
    public class GetTransferFeeDto
    {
        public decimal percentage { get; set; }
        public decimal transferFee { get; set; }
        public decimal serviceFee { get; set; }
        public decimal totalDeduction { get; set; }
        public decimal payoutAmount { get; set; }
    }
}
