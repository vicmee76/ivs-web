namespace ivs.Domain.Models.Dtos.Orders
{

    public class GetAttendanceDto
    {
        public int totalCount { get; set; }
        public int addmittedUsersCount { get; set; }
        public int notAddmittedUsersCount { get; set; }
        public int totalTicketQuantity { get; set; }
        public List<AttendanceDto> paginatedResults { get; set; }
    }

    public class AttendanceDto
    {
        public string _id { get; set; }
        public string orderId { get; set; }
        public string ivsEventId { get; set; }
        public string ticketId { get; set; }
        public string eventTimeId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public string gender { get; set; }
        public string ticketQuantity { get; set; }
        public string ticketPrice { get; set; }
        public string ticketServiceFee { get; set; }
        public string totalTicketServiceFee { get; set; }
        public string totalTicketFee { get; set; }
        public string totalTicketFeeAndServiceFee { get; set; }
        public bool isActive { get; set; }
        public bool hasPaid { get; set; }
        public bool emailSent { get; set; }
        public DateTime createdAt { get; set; }
        public string code { get; set; }
       // public string qrCode { get; set; }
        public string purchaseLink { get; set; }
        public DateTime emailSentAt { get; set; }
        public Ticketdetail[] ticketDetails { get; set; }
    }

    public class Ticketdetail
    {
        public string ticketName { get; set; }
        public string ticketKind { get; set; }
        public string startDateAndTime { get; set; }
    }
}
