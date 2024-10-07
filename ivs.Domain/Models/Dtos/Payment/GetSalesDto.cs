using ivs.Domain.Models.Dtos.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.Dtos.Payment
{
    public class GetSalesDto
    {
        public int totalTicketSum { get; set; }
        public int totalCount { get; set; }
        public List<GetSalesDataDto> paginatedResults { get; set; }
    }

    public class GetSalesDataDto
    {
        public string? _id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
        public string? ticketQuantity { get; set; }
        public string? code { get; set; }
        public bool isActive { get; set; }
        public int totalTicketFee { get; set; }
        public Ticketdetail[] ticketDetails { get; set; }
        public GetSalesPaymentDetails paymentDetails { get; set; }
    }

    public class GetSalesPaymentDetails
    {
        public string? paymentGateWayTransactionRef { get; set; }
        public string? paymentGateWayTransactionStatus { get; set; }
        public string? paymentGateWayTransactionDate { get; set; }
    }
}
