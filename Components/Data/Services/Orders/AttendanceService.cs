using Blazored.LocalStorage;
using Blazored.SessionStorage;
using ivs.Domain.Constants;
using ivs.Domain.Interfaces.General;
using ivs.Domain.Interfaces.Orders;
using ivs.Domain.Models.Dtos.Orders;
using Newtonsoft.Json;
using RestSharp;

namespace ivs_ui.Components.Data.Services.Orders
{
    public class AttendanceService(IWebService _webService) : IAttendanceService
    {
        private const string ApiUrl = "/api/v1/orders/attendance/";
        public async Task<ResponseObject> GetAttendanceByOrderId(string orderId)
        {
            try
            {
                var response = await _webService.Call(ApiUrl, $"get-attendance-by-order-id/{orderId}", Method.Get, null);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<GetAttendanceDto>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to get records, please try again later",
                    }
                };
            }
        }

        
        public async Task<ResponseObject> RetrieveTicketsByUserEmail(string email)
        {
            try
            {
                var response = await _webService.Call(ApiUrl, $"get-user-tickets/{email}", Method.Get, null);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<List<RetrieveTicketDto>>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to retrieve users tickets, please try again later",
                    }
                };
            }
        }

        
        public async Task<ResponseObject> GetAttendanceByUserCode(string eventId, string code)
        {
            try
            {
                var response = await _webService.Call(ApiUrl, $"get-attendance-by-code/{eventId}/{code}", Method.Get, null, null);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<GetAttendanceDto>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to get attendance record by user code, please try again later",
                    }
                };
            }
        }

        public async Task<ResponseObject> GetAttendanceByEventId(string eventId, Dictionary<string, string> queryParam)
        {
            try
            { 
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, $"get-attendance-by-event-id/{eventId}", Method.Get, null, headers, queryParam);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<GetAttendanceDto>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to get attendance record by event id, please try again later",
                    }
                };
            }
        }



        public async Task<ResponseObject> GetAttendanceByEventTimeId(string timeId, Dictionary<string, string> queryParam)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, $"get-attendance-by-event-time-id/{timeId}", Method.Get, null, headers, queryParam);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<GetAttendanceDto>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to get attendance record by event id, please try again later",
                    }
                };
            }
        }

        public Task<ResponseObject> GetAttendanceByTicketId(string ticketId, Dictionary<string, string> queryParam)
        {
            throw new NotImplementedException();
        }



        public async Task<ResponseObject> AdmitAttendees(string attendanceId)
        {
            try
            {
                var response = await _webService.Call(ApiUrl, $"admit-attendees/{attendanceId}", Method.Put, null, null);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to admit this user to the event, please try again later",
                    }
                };
            }
        }
    }
}
