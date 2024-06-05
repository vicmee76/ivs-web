using Blazored.SessionStorage;
using ivs_ui.Components.Data.Services.General;
using ivs_ui.Domain.Constants;
using ivs_ui.Domain.Interfaces.Events;
using ivs_ui.Domain.Interfaces.General;
using ivs_ui.Domain.Models.ViewModels.Events;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection;

namespace ivs_ui.Components.Data.Services.Events
{
    public class EventService(IWebService webService, ISessionStorageService sessionStorageService) : IEventService
    {
        private readonly IWebService _webService = webService;
        private readonly ISessionStorageService _sessionStorageService = sessionStorageService;
        private readonly string apiUrl = "/api/v1/ivs-event/";

        public async Task<ResponseObject> CreateEvent(CreateEventVM model)
        {
            try
            {
                var token = await _sessionStorageService.GetItemAsync<string>(Tokens.TokenName);
                var headers = new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } };

                var response = await _webService.Call(apiUrl, "create-event", Method.Post, model, headers);
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
                        message = "Error! Something went wrong, please try agian later",
                    }
                };
            }
        }
    }
}
