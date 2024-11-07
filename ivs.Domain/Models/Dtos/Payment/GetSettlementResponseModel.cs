using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.Dtos.Payment
{
    public class GetSettlementResponseModel
    {
        public string _id { get; set; }
        public decimal totalAmountSettledSum { get; set; }
        public List<GetSettlementData> records { get; set; }
    }


    public class GetSettlementData
    {
        public string _id { get; set; }
        public string paymentGateWayTransactionStatus { get; set; }
        public string paymentGateWayTransactionMessage { get; set; }
        public DateTime createdAt { get; set; }
        public string paymentGateWayTransactionId { get; set; }
        public string bankName { get; set; }
        public string eventName { get; set; }
        public string accountNumber { get; set; }
        public string accountName { get; set; }
        public decimal amountSettled { get; set; }
        public decimal totalAmountSettled { get; set; }
        public decimal totalServiceFee { get; set; }

    }
}
