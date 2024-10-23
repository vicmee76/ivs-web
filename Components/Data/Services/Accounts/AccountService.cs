using ivs.Domain.Constants;
using Newtonsoft.Json;
using RestSharp;
using ivs.Domain.Interfaces.Accounts;
using ivs.Domain.Interfaces.General;
using ivs.Domain.Models.Dtos.Accounts;
using ivs.Domain.Models.ViewModels.Accounts;

namespace ivs_ui.Components.Data.Services.Accounts
{
    public class AccountService(IWebService webService) : IAccountService
    {
        private readonly IWebService _webService = webService;
        private const string ApiUsersUrl = "/api/v1/users";
        private const string ApiLoginUrl = "/api/v1/accounts";

        public async Task<ResponseObject> CreateUser(SignUpVM model)
        {
            try
            {
                var response = await _webService.Call(ApiUsersUrl, "/sign-up/create-user", Method.Post, model);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeCreated)
                    return res!;
                return res!;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to create a user, please try agian later",
                    }
                };
            }
        }


        public async Task<ResponseObject> Login(LoginVM model)
        {
            try
            {
                var response = await _webService.Call(ApiLoginUrl, $"/login-user", Method.Post, model);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res!;

                var myJsonResponse = content.data?.ToString().Trim().TrimStart('{').TrimEnd('}');
                res.result.data = JsonConvert.DeserializeObject<UserDto>(content.data?.ToString());
                return res;
            }
            catch (Exception ex)    
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to login, please try again later",
                    }
                };
            }
        }



        public async Task<ResponseObject> ResendVerificationCode(string userId)
        {
            try
            {
                var response = await _webService.Call(ApiUsersUrl, $"/resend-verification-code/{userId}", Method.Put, null);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to resend verification code, please try again later",
                    }
                };
            }
        }

        public async Task<ResponseObject> ResetPassword(string id, ForgotPasswordVM model)
        {
            try
            {
                var response = await _webService.Call(ApiUsersUrl, $"/forgot-password/{id}", Method.Put, model);
                    var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res!;
                return res!;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        success = false,
                        code = 500,
                        message = "Error! Something went wrong trying to reset password, please try again later"
                    }
                };
            }
        }



        public async Task<ResponseObject> SendForgotPasswordToken(string email)
        {
            try
            {
                var response = await _webService.Call(ApiUsersUrl, $"/send-forgot-password-token/{email}", Method.Put, null);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        success = false,
                        code = 500,
                        message = "Error! Something went wrong trying to send forgot password token, please try again later"
                    }
                };
            }
        }




        public async Task<ResponseObject> VerifyAccount(string userId, ActivateAccountVM model)
        {
            try
            {
                var response = await _webService.Call(ApiUsersUrl, $"/verify-account/{userId}", Method.Put, model);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                var myJsonResponse = content.data.ToString().Trim().TrimStart('{').TrimEnd('}');
                res.result.data = JsonConvert.DeserializeObject<UserDto>(content.data.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        success = false,
                        code = 500,
                        message = "Error! Something went wrong trying to verify account, please try again later"
                    }
                };
            }
        }



        public async Task<ResponseObject> GetUserById(string userId)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();

                var response = await _webService.Call(ApiUsersUrl, $"/get-user-by-id/{userId}", Method.Get, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                var myJsonResponse = content.data.ToString().Trim().TrimStart('{').TrimEnd('}');
                res.result.data = JsonConvert.DeserializeObject<List<UserDetailsDto>>(myJsonResponse);
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to publish this event, please try again later",
                    }
                };
            }
        }



        public async Task<ResponseObject> CreateSettlementAccount(CreateSettlementAccountDto model)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUsersUrl, $"/settlement/create-settlement-account/", Method.Post, model, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to create this settlement account, please try again later",
                    }
                };
            }
        }
    }
}
