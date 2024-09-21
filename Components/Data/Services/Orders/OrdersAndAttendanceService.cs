using Blazored.LocalStorage;
using Blazored.SessionStorage;
using ivs.Domain.Constants;
using ivs.Domain.Interfaces.General;
using ivs.Domain.Interfaces.Orders;
using ivs.Domain.Models.Dtos.Orders;
using ivs.Domain.Models.ViewModels.Orders;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection;

namespace ivs_ui.Components.Data.Services.Orders;

public class OrdersAndAttendanceService(IWebService _webService, ILocalStorageService sessionStorageService) : IOrdersAndAttendanceService
{
    private const string ApiUrl = "/api/v1/orders/";

    private readonly ILocalStorageService _sessionStorageService = sessionStorageService;

    public async Task<ResponseObject> GetOrderById(string id)
    {
        try
        {
            var response = await _webService.Call(ApiUrl, $"get-order-by-id/{id}", Method.Get, null, null, null, null);
            var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
            var content = res?.result;
            if (content?.code != ResponseCodes.ResponseCodeOk)
                return new ResponseObject();

            res.result.data = JsonConvert.DeserializeObject<List<OrderDto>>(content?.data?.ToString());
            return res;
        }
        catch (Exception ex)
        {
            return new ResponseObject()
            {
                result = new ResponseContents()
                {
                    message = "Error! Something went wrong trying to get your order, please try again later",
                }
            };
        }
    }



    public async Task<ResponseObject> GenerateCost(List<GenerateCostVM> model)
    {
        try
        {
            var response = await _webService.Call(ApiUrl, "generate-cost", Method.Post, model, null, null, null);
            var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
            var content = res?.result;
            if (content?.code != ResponseCodes.ResponseCodeOk)
                return new ResponseObject();

            res.result.data = JsonConvert.DeserializeObject<List<GenerateCostDto>>(content?.data?.ToString());
            return res;
        }
        catch (Exception ex)
        {
            return new ResponseObject()
            {
                result = new ResponseContents()
                {
                    message = "Error! Something went wrong trying to generate cost, please try again later",
                }
            };
        }
    }

    public async Task<ResponseObject> SaveOrder(OrdersVM model)
    {
        try
        {
            var response = await _webService.Call(ApiUrl, "save-order", Method.Post, model, null, null, null);
            var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
            var content = res?.result;
            if (content?.code != ResponseCodes.ResponseCodeOk)
                return new ResponseObject();
                
            res.result.data = JsonConvert.DeserializeObject<OrderDto>(content?.data?.ToString());
            return res;
        }
        catch (Exception ex)
        {
            return new ResponseObject()
            {
                result = new ResponseContents()
                {
                    message = "Error! Something went wrong trying to save order, please try again later",
                }
            };
        }
    }

    public async Task<ResponseObject> GetAttendanceByOrderId(string orderId)
    {
        try
        {
            var response = await _webService.Call(ApiUrl, $"get-attendance-by-order-id/{orderId}", Method.Get, null, null, null, null);
            var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
            var content = res?.result;
            if (content?.code != ResponseCodes.ResponseCodeOk)
                return new ResponseObject();

            res.result.data = JsonConvert.DeserializeObject<List<AttendanceDto>>(content?.data?.ToString());
            return res;
        }
        catch (Exception ex)
        {
            return new ResponseObject()
            {
                result = new ResponseContents()
                {
                    message = "Error! Something went wrong trying to get attendace record by, please try again later",
                }
            };
        }
    }

    public async Task<ResponseObject> GetAttendanceByEventId(string eventId, Dictionary<string, string> queryParam)
    {
        try
        {
            var token = await _sessionStorageService.GetItemAsync<string>(Tokens.TokenName);
            var headers = new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } };

            var response = await _webService.Call(ApiUrl, $"get-attendance-by-event-id/{eventId}", Method.Get, null, headers, queryParam, null);
            var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
            var content = res?.result;
            if (content?.code != ResponseCodes.ResponseCodeOk)
                return new ResponseObject();

            res.result.data = JsonConvert.DeserializeObject<List<AttendanceDto>>(content?.data?.ToString());
            return res;
        }
        catch (Exception ex)
        {
            return new ResponseObject()
            {
                result = new ResponseContents()
                {
                    message = "Error! Something went wrong trying to get attendace record by, please try again later",
                }
            };
        }
    }



    public Task<ResponseObject> GetAttendanceByEventTimeId(string timeId, Dictionary<string, string> queryParam)
    {
        throw new NotImplementedException();
    }

    public Task<ResponseObject> GetAttendanceByTicketId(string ticketId, Dictionary<string, string> queryParam)
    {
        throw new NotImplementedException();
    }
}