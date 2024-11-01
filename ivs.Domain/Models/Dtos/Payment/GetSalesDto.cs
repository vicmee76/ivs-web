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
        public double totalTicketSum { get; set; }
        public int totalCount { get; set; }
        public int totalTicketQuantity { get; set; }
        public decimal totalAmountSettled { get; set; }
        public List<GetSalesDataDto>? paginatedResults { get; set; }
        public List<TicketNameGroupingTotalResult>? TicketNameGroupingTotal { get; set; }
    }

    public class GetSalesDataDto
    {
        public string? _id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? phoneNumber { get; set; }
        public int ticketQuantity { get; set; }
        public string? code { get; set; }
        public bool isActive { get; set; }
        public double totalTicketFee { get; set; }
        public Ticketdetail[]? ticketDetails { get; set; }
        public GetSalesPaymentDetails? paymentDetails { get; set; }
    }

    public class GetSalesPaymentDetails
    {
        public string? paymentGateWayTransactionRef { get; set; }
        public string? paymentGateWayTransactionStatus { get; set; }
        public string? paymentGateWayTransactionDate { get; set; }
    }

    public class TicketNameGroupingTotalResult
    {
        public string _id { get; set; }
        public decimal totalTicketFeeSum { get; set; }
        public int totalTicketQuantity { get; set; }
    }
}
