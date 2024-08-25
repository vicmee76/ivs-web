using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.Dtos.Orders
{
    public class SaveOrderDto
    {
        public string _id { get; set; }
        public string ivsEventId { get; set; }
        public int totalOrderQuantity { get; set; }
        public TotalServiceFee totalServiceFee { get; set; }
        public TotalTicketFee totalTicketFee { get; set; }
        public TotalFee totalFee { get; set; }
        public bool isActive { get; set; }
        public string orderEndTime { get; set; }
        public string createdAt { get; set; }
        public int __v { get; set; }
    }


    public class TotalOrderQuantity
    {
        [JsonProperty("$numberDecimal")]
        public int numberDecimal { get; set; }
    }

    public class TotalServiceFee
    {
        [JsonProperty("$numberDecimal")]
        public decimal numberDecimal { get; set; }
    }

    public class TotalTicketFee
    {
        [JsonProperty("$numberDecimal")]
        public decimal numberDecimal { get; set; }
    }

    public class TotalFee
    {
        [JsonProperty("$numberDecimal")]
        public decimal numberDecimal { get; set; }
    }
}
