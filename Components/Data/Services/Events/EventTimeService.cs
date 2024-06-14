using Blazored.SessionStorage;
using ivs_ui.Domain.Constants;
using ivs_ui.Domain.Interfaces.Events;
using ivs_ui.Domain.Interfaces.General;
using ivs_ui.Domain.Models.Dtos.Events;
using ivs_ui.Domain.Models.ViewModels.Events;
using Newtonsoft.Json;
using RestSharp;

namespace ivs_ui.Components.Data.Services.Events
{
    public class EventTimeService(IWebService webService, ISessionStorageService sessionStorageService) : IEventTimeService
    {
        private readonly IWebService _webService = webService;
        private readonly ISessionStorageService _sessionStorageService = sessionStorageService;
        private readonly string apiUrl = "/api/v1/ivs-events-time/";

        public async Task<ResponseObject> CreateEventTime(List<EventTimeVM> model)
        {
            try
            {
                var token = await _sessionStorageService.GetItemAsync<string>(Tokens.TokenName);
                var headers = new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } };

                var response = await _webService.Call(apiUrl, $"create-event-time", Method.Post, model, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCode_Created)
                    return res;

                var myJsonResponse = content.data.ToString().Trim().TrimStart('{').TrimEnd('}');
                res.result.data = JsonConvert.DeserializeObject<List<CreateEventTimeDto>>(myJsonResponse);
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to create event time, please try agian later",
                    }
                };
            }
        }
    }
}
