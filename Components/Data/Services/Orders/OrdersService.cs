using ivs.Domain.Constants;
using ivs.Domain.Interfaces.General;
using ivs.Domain.Interfaces.Orders;
using ivs.Domain.Models.Dtos.Orders;
using ivs.Domain.Models.Dtos.Organisations;
using ivs.Domain.Models.ViewModels.Orders;
using Newtonsoft.Json;
using RestSharp;

namespace ivs_ui.Components.Data.Services.Orders;

public class OrdersService(IWebService _webService) : IOrdersService
{
    private const string ApiUrl = "/api/v1/orders/";
    
    public async Task<ResponseObject> GenerateCost(List<GenerateCostVM> model)
    {
        try
        {
            var response = await _webService.Call(ApiUrl, "generate-cost", Method.Post, model, null, null, null);
            var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
            var content = res?.result;
            if (content?.code != ResponseCodes.ResponseCodeOk)
                return new ResponseObject();

            var myJsonResponse = content?.data?.ToString().Trim().TrimStart('{').TrimEnd('}');
            res.result.data = JsonConvert.DeserializeObject<List<GenerateCostDto>>(content?.data?.ToString());
            return res;
        }
        catch (Exception ex)
        {
            return new ResponseObject()
            {
                result = new ResponseContents()
                {
                    message = "Error! Something went wrong trying to get organisations, please try again later",
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
                
            var myJsonResponse = content?.data?.ToString().Trim().TrimStart('{').TrimEnd('}');
            res.result.data = JsonConvert.DeserializeObject<List<SaveOrderDto>>(content?.data?.ToString());
            return res;
        }
        catch (Exception ex)
        {
            return new ResponseObject()
            {
                result = new ResponseContents()
                {
                    message = "Error! Something went wrong trying to get organisations, please try again later",
                }
            };
        }
    }
}