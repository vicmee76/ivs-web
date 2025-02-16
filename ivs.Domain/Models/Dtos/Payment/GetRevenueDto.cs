using ivs.Domain.Models.Dtos.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.Dtos.Payment
{

    public class GetRevenueDataDto
    {
        public int totalCount { get; set; }
        public List<GetRevenueDto> result { get; set; }
    }


    public class GetRevenueDto
    {
        public int totalOrderQuantitySum { get; set; }
        public decimal totalServiceFeeSum { get; set; }
        public decimal totalTicketFeeSum { get; set; }
        public decimal totalFeeSum { get; set; }
        public decimal gatewayFeeSum { get; set; }
        public decimal totalServiceFeeAfterDeductionSum { get; set; }
        public decimal ivsNetRevenueSum { get; set; }
        public decimal ivsVatSum { get; set; }
        public List<Order> orders { get; set; }
    }

    public class Order
    {
        public string orderId { get; set; }
        public string paymentGateWayTransactionRef { get; set; }
        public string paymentGateWayTransactionId { get; set; }
        public string paymentGateWayTransactionStatus { get; set; }
        public string paymentGateWayTransactionDate { get; set; }
        public int totalOrderQuantity { get; set; }
        public decimal totalServiceFee { get; set; }
        public decimal totalTicketFee { get; set; }
        public decimal totalFee { get; set; }
        public decimal gatewayFee { get; set; }
        public decimal totalServiceFeeAfterDeduction { get; set; }
        public decimal? ivsNetRevenue { get; set; }
        public decimal? ivsVat { get; set; }
        public bool isActive { get; set; }
        public bool open { get; set; } = false;
        public List<Attendee>? attendees { get; set; }
    }

    public class Attendee
    {
        public string _id { get; set; }
        public string orderId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public bool hasPaid { get; set; }
        public string code { get; set; }
        public int ticketQuantity { get; set; }
        public decimal ticketPrice { get; set; }
        public decimal ticketServiceFee { get; set; }
        public decimal totalTicketServiceFee { get; set; }
        public decimal totalTicketFee { get; set; }
        public decimal totalTicketFeeAndServiceFee { get; set; }
        public string ticketId { get; set; }
        public string eventTimeId { get; set; }
        public string ivsEventId { get; set; }
        public TicketDetails ticketDetails { get; set; }
        public TimeDetails timeDetails { get; set; }
        public EventDetailsData eventDetails { get; set; }
    }

    public class EventDetailsData
    {
        public string eventName { get; set; }
    }

    public class TicketDetails
    {
        public string ticketKind { get; set; }
        public string ticketName { get; set; }
    }

    public class TimeDetails
    {
        public string startDateAndTime { get; set; }
    }

}
