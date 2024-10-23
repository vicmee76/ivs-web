using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.Dtos.Accounts
{
    public class CreateSettlementAccountDto
    {
        public string userId { get; set; }
        public string accountName { get; set; }
        public string accountNumber { get; set; }
        public string bankCode { get; set; }
        public string bankName { get; set; }
    }
}
