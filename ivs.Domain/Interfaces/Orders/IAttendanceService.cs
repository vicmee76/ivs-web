using ivs.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Interfaces.Orders
{
    public interface IAttendanceService
    {
        public Task<ResponseObject> AdmitAttendees(string attendanceId);
        public Task<ResponseObject> GetAttendanceByOrderId(string orderId);
        public Task<ResponseObject> GetAttendanceByEventId(string eventId, Dictionary<string, string> queryParam);
        public Task<ResponseObject> GetAttendanceByEventTimeId(string timeId, Dictionary<string, string> queryParam);
        public Task<ResponseObject> GetAttendanceByTicketId(string ticketId, Dictionary<string, string> queryParam);
    }
}
