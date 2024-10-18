using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.Dtos.Payment
{
    public class GetBanksDto
    {
        public string id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
    }
}
