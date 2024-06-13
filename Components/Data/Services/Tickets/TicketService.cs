using Blazored.SessionStorage;
using ivs_ui.Domain.Constants;
using ivs_ui.Domain.Interfaces.General;
using ivs_ui.Domain.Interfaces.Tickets;
using ivs_ui.Domain.Models.Dtos.Events;
using ivs_ui.Domain.Models.Dtos.Tickets;
using ivs_ui.Domain.Models.ViewModels.Tickets;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection;

namespace ivs_ui.Components.Data.Services.Tickets
{
    public class TicketService(IWebService webService, ISessionStorageService sessionStorageService) : ITicketService
    {
        private readonly IWebService _webService = webService;
        private readonly ISessionStorageService _sessionStorageService = sessionStorageService;
        private readonly string apiUrl = "/api/v1/tickets/";

        public async Task<ResponseObject> CreateTicket(CreateTicketVM model)
        {
            try
            {
                var token = await _sessionStorageService.GetItemAsync<string>(Tokens.TokenName);
                var headers = new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } };

                var response = await _webService.Call(apiUrl, "create-event-tickets", Method.Post, model, headers);
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

        public async Task<ResponseObject> GetTicketByEventId(string eventId)
        {
            try
            {
                var token = await _sessionStorageService.GetItemAsync<string>(Tokens.TokenName);
                var headers = new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } };

                var response = await _webService.Call(apiUrl, $"get-all-event-with-tickets-by-event-id/{eventId}", Method.Get, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCode_Ok)
                    return res;

                var myJsonResponse = content.data.ToString().Trim().TrimStart('{').TrimEnd('}');
                res.result.data = JsonConvert.DeserializeObject<List<TicketDto>>(content.data.ToString());
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
