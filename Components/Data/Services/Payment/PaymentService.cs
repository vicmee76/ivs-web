using Blazored.LocalStorage;
using Blazored.SessionStorage;
using ivs.Domain.Constants;
using ivs.Domain.Interfaces.General;
using ivs.Domain.Interfaces.Payment;
using ivs.Domain.Models.Dtos.Accounts;
using ivs.Domain.Models.Dtos.Orders;
using ivs.Domain.Models.Dtos.Payment;
using ivs.Domain.Models.ViewModels.Payments;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection;

namespace ivs_ui.Components.Data.Services.Payment
{
    public class PaymentService(IWebService _webService) : IPaymentService
    {
        private const string ApiUrl = "/api/v1/payments/";
        private const string SettlementUrl = "/api/v1/users/settlement/settlement-transfer/";

        public async Task<ResponseObject> GeneratePaymentLink(MakePaymentVM model)
        {
            try
            {
                var response = await _webService.Call(ApiUrl, $"generate-flutterwave-payment-link", Method.Post, model);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

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
                var response = await _webService.Call(ApiUrl, $"flutterwave-get-banks/", Method.Get, null, headers, queryParam);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<List<GetBanksDto>>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject() { result = new ResponseContents() { message = "Error! Something went wrong trying to get all banks record, please try again later" } };
            }
        }


        public async Task<ResponseObject> GetRevenue(Dictionary<string, string> queryParam)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, $"get-revenue/", Method.Get, null, headers, queryParam);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<GetRevenueDataDto>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject() { result = new ResponseContents() { message = "Error! Something went wrong trying to get revenue record, please try again later" } };
            }
        }



        public async Task<ResponseObject> GetSales(Dictionary<string, string> queryParam)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, $"get-sales/", Method.Get, null, headers, queryParam);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<GetSalesDto>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject() { result = new ResponseContents() { message = "Error! Something went wrong trying to get sales record, please try again later" } };
            }
        }


        public async Task<ResponseObject> GetTotalSettlement()
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(SettlementUrl, $"get-total-settlement", Method.Get, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<GetTotalSettlementModel>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject() { result = new ResponseContents() { message = "Error! Something went wrong trying to get total settlement, please try again later" } };
            }
        }

        public async Task<ResponseObject> GetSettlementByEventId(string eventId, Dictionary<string, string> queryParam)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(SettlementUrl, $"get-settlement-by-event-id/{eventId}", Method.Get, null, headers, queryParam);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<List<GetSettlementResponseModel>>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject() { result = new ResponseContents() { message = "Error! Something went wrong trying to get settlement by event id, please try again later" } };
            }
        }




        public async Task<ResponseObject> GetSettlementByUserId(string userId, Dictionary<string, string> queryParam)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(SettlementUrl, $"get-settlement-by-user-id/{userId}", Method.Get, null, headers, queryParam);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<List<GetSettlementResponseModel>>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject() { result = new ResponseContents() { message = "Error! Something went wrong trying to get settlement by user id, please try again later" } };
            }
        }




        public async Task<ResponseObject> GetTransferFee(decimal settlementAmount, string eventId)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(SettlementUrl, $"get-transfer-fee/{settlementAmount}/{eventId}", Method.Get, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<GetTransferFeeDto>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to get transfer settlement fees, please try again later.",
                    }
                };
            }
        }

        public async Task<ResponseObject> GetUserSales(Dictionary<string, string> queryParam)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, $"get-user-sales/", Method.Get, null, headers, queryParam);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<GetSalesDto>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject() { result = new ResponseContents() { message = "Error! Something went wrong trying to get user sales record, please try again later" } };
            }
        }



        public async Task<ResponseObject> PostSettlement(PostSettlementDto model)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(SettlementUrl, $"post-settlement", Method.Post, model, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                var myJsonResponse = content.data.ToString().Trim().TrimStart('{').TrimEnd('}');
                res.result.data = JsonConvert.DeserializeObject<List<PostSettlementResponseDto>>(content.data.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to post settlement transfers, please try again later.",
                    }
                };
            }
        }
        


        public async Task<ResponseObject> ProcessFreePayment(string orderId)
        {
            try
            {
                var response = await _webService.Call(ApiUrl, $"process-free-payment/{orderId}", Method.Post, null);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

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



        public async Task<ResponseObject> VerifyAccountNumber(string bankCode, string accountNumber)
        {
            try
            {
                var req = new { account_number = accountNumber, account_bank = bankCode };
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, $"flutterwave-verify-account-number/", Method.Post, req, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<VerifyAccountDto>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject() { result = new ResponseContents() { message = "Error! Something went wrong trying to verify your account details, please try again later" } };
            }
        }




        public async Task<ResponseObject> VerifyPayment(Dictionary<string, string> model)
        {
            try
            {
                var response = await _webService.Call(ApiUrl, $"verify-flutterwave-payment", Method.Post, null, null, model);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

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
