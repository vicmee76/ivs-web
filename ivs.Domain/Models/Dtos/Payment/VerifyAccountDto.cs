using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.Dtos.Payment
{
    public class VerifyAccountDto
    {
        public string account_number { get; set; }
        public string account_name { get; set; }
    }
}
