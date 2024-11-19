using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Newtonsoft.Json;
using RestSharp;
using ivs.Domain.Constants;
using ivs.Domain.Interfaces.Events;
using ivs.Domain.Interfaces.General;
using ivs.Domain.Models.Dtos.Events;

namespace ivs_ui.Components.Data.Services.Events
{
    public class EventTypeService(IWebService webService) : IEventTypeService
    {
        private readonly IWebService _webService = webService;
        private const string ApiUrl = "/api/v1/event-types";


        public async Task<ResponseObject> GetEventTypes()
        {
            try
            {
                var response = await _webService.Call(ApiUrl, "/", Method.Get, null);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res!;

                res.result.data = JsonConvert.DeserializeObject<List<GetEventTypesDto>>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to get all event types, please try again later",
                    }
                };
            }
        }
    }
}
