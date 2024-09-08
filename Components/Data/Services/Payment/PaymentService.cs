using ivs.Domain.Constants;
using ivs.Domain.Interfaces.General;
using ivs.Domain.Interfaces.Payment;
using ivs.Domain.Models.Dtos.Payment;
using ivs.Domain.Models.ViewModels.Payments;
using Newtonsoft.Json;
using RestSharp;

namespace ivs_ui.Components.Data.Services.Payment
{
    public class PaymentService(IWebService _webService) : IPaymentService
    {
        private const string ApiUrl = "/api/v1/payments/";

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
