using Blazored.SessionStorage;
using ivs.Domain.Constants;
using ivs.Domain.Interfaces.General;
using ivs.Domain.Interfaces.Payment;
using ivs.Domain.Models.Dtos.Payment;
using Newtonsoft.Json;
using RestSharp;

namespace ivs_ui.Components.Data.Services.Payment
{
    public class PaymentOptionService(IWebService webService, ISessionStorageService sessionStorageService) : IPaymentOptionService
    {
        private readonly IWebService _webService = webService;
        private readonly ISessionStorageService _sessionStorageService = sessionStorageService;
        private const string ApiUrl = "/api/v1/payments-options/";

        public async Task<ResponseObject> GetAllPaymentOptions()
        {
            try
            {
                var token = await _sessionStorageService.GetItemAsync<string>(Tokens.TokenName);
                var headers = new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } };

                var response = await _webService.Call(ApiUrl, "get-all-payment-options", Method.Get, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return new ResponseObject();

                var myJsonResponse = content?.data?.ToString().Trim().TrimStart('{').TrimEnd('}');
                res.result.data = JsonConvert.DeserializeObject<List<GetPaymentOptionsDto>>(myJsonResponse);
                return res;
            }
            catch (Exception ex)
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
    }
}
