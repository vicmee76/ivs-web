using Blazored.LocalStorage;
using Blazored.SessionStorage;
using ivs.Domain.Constants;
using ivs.Domain.Interfaces.General;
using ivs.Domain.Interfaces.Payment;
using ivs.Domain.Models.Dtos.Orders;
using ivs.Domain.Models.Dtos.Payment;
using ivs.Domain.Models.ViewModels.Payments;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection;

namespace ivs_ui.Components.Data.Services.Payment
{
    public class PaymentService(IWebService _webService, ILocalStorageService sessionStorageService) : IPaymentService
    {
        private const string ApiUrl = "/api/v1/payments/";

        private readonly ILocalStorageService _sessionStorageService = sessionStorageService;

        public async Task<ResponseObject> GeneratePaymentLink(MakePaymentVM model)
        {
            try
            {
                var response = await _webService.Call(ApiUrl, $"generate-flutterwave-payment-link", Method.Post, model, null, null, null);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return new ResponseObject();

                res.result.data = JsonConvert.DeserializeObject<List<PaymentDto>>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to connect to payment gateway, please try again later.",
                    }
                };
            }
        }


        public async Task<ResponseObject> GetBanks(string country = "NG")
        {
            try
            {
                var queryParam = new Dictionary<string, string> { { "country", country } };

                var headers = await _webService.GetAuthorizationHeaders();

                var response = await _webService.Call(ApiUrl, $"flutterwave-get-banks/", Method.Get, null, headers, queryParam, null);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return new ResponseObject();

                res.result.data = JsonConvert.DeserializeObject<List<GetBanksDto>>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject() { result = new ResponseContents() { message = "Error! Something went wrong trying to get all banks record, please try again later" } };
            }
        }



        public async Task<ResponseObject> GetSales(Dictionary<string, string> queryParam)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, $"get-sales/", Method.Get, null, headers, queryParam, null);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return new ResponseObject();

                res.result.data = JsonConvert.DeserializeObject<GetSalesDto>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject() { result = new ResponseContents() { message = "Error! Something went wrong trying to get sales record, please try again later" } };
            }
        }




        public async Task<ResponseObject> ProcessFreePayment(string orderId)
        {
            try
            {
                var response = await _webService.Call(ApiUrl, $"process-free-payment/{orderId}", Method.Post, null, null, null, null);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return new ResponseObject();

                res.result.data = JsonConvert.DeserializeObject<List<VerifyPaymentDto>>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to connect to payment gateway, please try again later.",
                    }
                };
            }
        }

        public async Task<ResponseObject> VerifyPayment(Dictionary<string, string> model)
        {
            try
            {
                var response = await _webService.Call(ApiUrl, $"verify-flutterwave-payment", Method.Post, null, null, model, null);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return new ResponseObject();

                res.result.data = JsonConvert.DeserializeObject<List<VerifyPaymentDto>>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to connect to payment gateway, please try again later.",
                    }
                };
            }
        }
    }
}
