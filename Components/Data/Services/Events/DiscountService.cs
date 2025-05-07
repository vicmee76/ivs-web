using ivs.Domain.Constants;
using ivs.Domain.Interfaces.Events;
using ivs.Domain.Interfaces.General;
using ivs.Domain.Models.Dtos.Events;
using ivs.Domain.Models.ViewModels.Events;
using Newtonsoft.Json;
using RestSharp;

namespace ivs_ui.Components.Data.Services.Events;

public class DiscountService(IWebService webService) : IDiscountService
{
    private const string ApiUrl = "/api/v1/discount/";
    
    public async Task<ResponseObject> CreateDiscount(CreateDiscountVM model)
    {
        try
        {
            var headers = await webService.GetAuthorizationHeaders();
            var response = await webService.Call(ApiUrl, "create-discount", Method.Post, model, headers);
            var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
            return res;
        }
        catch (Exception ex)
        {
            return new ResponseObject()
            {
                result = new ResponseContents()
                {
                    message = "Error! Something went wrong trying to create a discount, please try again later",
                }
            };
        }
    }

    public async Task<ResponseObject> GetDiscountByEventId(string id)
    {
        try
        {
            var headers = await webService.GetAuthorizationHeaders();
            var response = await webService.Call(ApiUrl, $"get-by-event-id/{id}", Method.Get, null, headers);
            var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
            var content = res.result;
            if (content?.code != ResponseCodes.ResponseCodeOk)
                return res;

            res.result.data = JsonConvert.DeserializeObject<List<DiscountResponseDto>>(content.data.ToString());
            return res;
        }
        catch (Exception ex)
        {
            return new ResponseObject()
            {
                result = new ResponseContents()
                {
                    message = "Error! Something went wrong trying to get all discount codes for this event, please try again later",
                }
            };
        }
    }

    public async Task<ResponseObject> DeleteDiscountById(string id)
    {
        try
        {
            var headers = await webService.GetAuthorizationHeaders();
            var response = await webService.Call(ApiUrl, $"remove-discount/{id}", Method.Delete, null, headers);
            var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
            return res;
        }
        catch (Exception ex)
        {
            return new ResponseObject()
            {
                result = new ResponseContents()
                {
                    message = "Error! Something went wrong trying to remove this discount, please try again later",
                }
            };
        }
    }
    
    

    public async Task<ResponseObject> GetDiscountByCode(string code)
    {
        try
        {
            var response = await webService.Call(ApiUrl, $"get-by-code/{code}", Method.Get, null, null);
            var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
            var content = res.result;
            if (content?.code != ResponseCodes.ResponseCodeOk)
                return res;

            res.result.data = JsonConvert.DeserializeObject<List<DiscountResponseDto>>(content.data.ToString());
            return res;
        }
        catch (Exception ex)
        {
            return new ResponseObject()
            {
                result = new ResponseContents()
                {
                    message = "Error! Something went wrong trying to get this discount, please try again later",
                }
            };
        }
    }

    
    public async Task<ResponseObject> UpdateDiscount(string id, CreateDiscountVM model)
    {
        try
        {
            var headers = await webService.GetAuthorizationHeaders();
            var response = await webService.Call(ApiUrl, $"update-discount/{id}", Method.Put, model, headers);
            var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
            return res;
        }
        catch (Exception ex)
        {
            return new ResponseObject()
            {
                result = new ResponseContents()
                {
                    message = "Error! Something went wrong trying to update this discount, please try again later",
                }
            };
        }
    }
}