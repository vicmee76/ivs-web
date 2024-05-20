using ivs_ui.Components.Pages.Accounts;
using ivs_ui.Domain.Constants;
using ivs_ui.Domain.Interfaces.Accounts;
using ivs_ui.Domain.Interfaces.General;
using ivs_ui.Domain.Models.Dtos.Organisations;
using ivs_ui.Domain.Models.ViewModels.Accounts;
using Newtonsoft.Json;
using RestSharp;

namespace ivs_ui.Components.Data.Services.Accounts
{
    public class UserService(IWebService webService) : IUserService
    {
        private readonly IWebService _webService = webService;
        private readonly string apiUrl = "/api/v1/users";

        public async Task<ResponseObject> CreateUser(SignUpVM signUpVM)
        {
            var response = await _webService.Call(apiUrl, "/sign-up/create-user", Method.Post, signUpVM);
            var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
            var content = res.result;
            if (content?.code != ResponseCodes.ResponseCode_Created)
                return res;
            return res;
        }


        public async Task<ResponseObject> ResendVerificationCode(string userId)
        {
            var response = await _webService.Call(apiUrl, $"/resend-verification-code/{userId}", Method.Put, null);
            var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
            var content = res.result;
            if (content?.code != ResponseCodes.ResponseCode_Successful)
                return res;
            return res;
        }
    }
}
