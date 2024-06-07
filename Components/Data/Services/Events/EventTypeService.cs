using Blazored.SessionStorage;
using ivs_ui.Components.Data.Services.General;
using ivs_ui.Domain.Constants;
using ivs_ui.Domain.Interfaces.Events;
using ivs_ui.Domain.Interfaces.General;
using ivs_ui.Domain.Models.Dtos.Accounts;
using ivs_ui.Domain.Models.Dtos.Events.EventTypes;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection;

namespace ivs_ui.Components.Data.Services.Events
{
    public class EventTypeService(IWebService webService, ISessionStorageService sessionStorageService) : IEventTypeService
    {
        private readonly IWebService _webService = webService;
        private readonly ISessionStorageService _sessionStorageService = sessionStorageService;
        private readonly string apiUrl = "/api/v1/event-types";


        public async Task<ResponseObject> GetEventTypes()
        {
            try
            {
                var token = await _sessionStorageService.GetItemAsync<string>(Tokens.TokenName);
                var headers = new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } };

                var response = await _webService.Call(apiUrl, "/", Method.Get, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCode_Ok)
                    return res;

                var myJsonResponse = content.data.ToString().Trim().TrimStart('{').TrimEnd('}');
                res.result.data = JsonConvert.DeserializeObject<List<GetEventTypesDto>>(content.data.ToString());
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
