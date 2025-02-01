using Blazored.LocalStorage;
using Blazored.SessionStorage;
using ivs.Domain.Constants;
using ivs.Domain.Interfaces.General;
using ivs.Domain.Interfaces.Payment;
using ivs.Domain.Models.Dtos.Payment;
using ivs.Domain.Models.ViewModels.Payments;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection;

namespace ivs_ui.Components.Data.Services.Payment
{
    public class PaymentOptionService(IWebService webService, ILocalStorageService sessionStorageService) : IPaymentOptionService
    {
        private readonly IWebService _webService = webService;
        private readonly ILocalStorageService _sessionStorageService = sessionStorageService;
        private const string ApiUrl = "/api/v1/payments-options/";

        public async Task<ResponseObject> GetAllPaymentOptions()
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, "get-all-payment-options", Method.Get, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                var myJsonResponse = content?.data?.ToString().Trim().TrimStart('{').TrimEnd('}');
                res.result.data = JsonConvert.DeserializeObject<List<GetPaymentOptionsDto>>(myJsonResponse);
                return res;
            }
            catch (Exception)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to get all payment options, please try again later",
                    }
                };
            }
        }

        public async Task<ResponseObject> CreatePaymentOptions(CreatePaymentOptionDto model)
        {
            try
            {
                var create = new CreatePaymentOptionVM()
                {
                    name = model.name,
                    description = model.description,
                    maxUsers = model.maxUsers,
                    metaAmountPercentage = model.metaAmountPercentage.ToString(),
                    amount = model.amount.ToString(),
                    capAmount = model.capAmount
                };

                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, "create-payment-option", Method.Post, create, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                return res;
            }
            catch (Exception)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to create a payment options, please try again later",
                    }
                };
            }       
        }

        public async Task<ResponseObject> UpdatePaymentOptions(string id, CreatePaymentOptionDto model)
        {
            try
            {
                var update = new CreatePaymentOptionVM()
                {
                    name = model.name,
                    description = model.description,
                    maxUsers = model.maxUsers,
                    metaAmountPercentage = model.metaAmountPercentage.ToString(),
                    amount = model.amount.ToString(),
                    capAmount = model.capAmount
                };

                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, $"update-payment-options/{id}", Method.Put, update, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                return res;
            }
            catch (Exception)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to update a payment options, please try again later",
                    }
                };
            }
        }


        public async Task<ResponseObject> RemovePaymentOptions(string id)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, $"remove-payment-options/{id}", Method.Delete, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                return res;
            }
            catch (Exception)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to rremove this payment options, please try again later",
                    }
                };
            }
        }
    }
}
