using Blazored.LocalStorage;
using Blazored.SessionStorage;
using ivs.Domain.Constants;
using ivs.Domain.Interfaces.General;
using ivs.Domain.Interfaces.Orders;
using ivs.Domain.Models.Dtos.Orders;
using ivs.Domain.Models.ViewModels.Orders;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection;

namespace ivs_ui.Components.Data.Services.Orders;

public class OrderService(IWebService _webService, ILocalStorageService sessionStorageService) : IOrderService
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

}