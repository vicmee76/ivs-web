using Blazored.LocalStorage;
using ivs_ui.Components.Pages.Accounts;
using ivs_ui.Domain.Constants;
using ivs_ui.Domain.Interfaces.Accounts;
using ivs_ui.Domain.Interfaces.General;
using ivs_ui.Domain.Models.Dtos.Accounts;
using ivs_ui.Domain.Models.Dtos.Organisations;
using ivs_ui.Domain.Models.ViewModels.Accounts;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection;

namespace ivs_ui.Components.Data.Services.Accounts
{
    public class AccountService(IWebService webService) : IAccountService
    {
        private readonly IWebService _webService = webService;
        private readonly string apiUsersUrl = "/api/v1/users";
        private readonly string apiLoginUrl = "/api/v1/accounts";

        public async Task<ResponseObject> CreateUser(SignUpVM model)
        {
            try
            {
                var response = await _webService.Call(apiUsersUrl, "/sign-up/create-user", Method.Post, model);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCode_Created)
                    return res;
                return res;
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
                var response = await _webService.Call(apiLoginUrl, $"/login-user", Method.Post, model);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCode_Ok)
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
                        message = "Error! Something went wrong trying to login, please try agian later",
                    }
                };
            }
        }



        public async Task<ResponseObject> ResendVerificationCode(string userId)
        {
            try
            {
                var response = await _webService.Call(apiUsersUrl, $"/resend-verification-code/{userId}", Method.Put, null);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCode_Ok)
                    return res;
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to resend verification code, please try agian later",
                    }
                };
            }
        }

        public async Task<ResponseObject> ResetPassword(string id, ForgotPasswordVM model)
        {
            try
            {
                var response = await _webService.Call(apiUsersUrl, $"/forgot-password/{id}", Method.Put, model);
                    var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCode_Ok)
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
                        message = "Error! Something went wrong trying to reset password, please try agian later"
                    }
                };
            }
        }



        public async Task<ResponseObject> SendForgotPasswordToken(string email)
        {
            try
            {
                var response = await _webService.Call(apiUsersUrl, $"/send-forgot-password-token/{email}", Method.Put, null);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCode_Ok)
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
                        message = "Error! Something went wrong trying to send forgot password token, please try agian later"
                    }
                };
            }
        }




        public async Task<ResponseObject> VerifyAccount(string userId, ActivateAccountVM model)
        {
            try
            {
                var response = await _webService.Call(apiUsersUrl, $"/verify-account/{userId}", Method.Put, model);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCode_Ok)
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
                        message = "Error! Something went wrong trying to verify account, please try agian later"
                    }
                };
            }
        }



    }
}
