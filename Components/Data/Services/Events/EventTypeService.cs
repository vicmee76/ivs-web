using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Newtonsoft.Json;
using RestSharp;
using ivs.Domain.Constants;
using ivs.Domain.Interfaces.Events;
using ivs.Domain.Interfaces.General;
using ivs.Domain.Models.Dtos.Events;
using ivs.Domain.Models.Dtos.Organisations;
using System.Reflection;

namespace ivs_ui.Components.Data.Services.Events
{
    public class EventTypeService(IWebService webService) : IEventTypeService
    {
        private readonly IWebService _webService = webService;
        private const string ApiUrl = "/api/v1/event-types/";


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


            
        public async Task<ResponseObject> CreateEventTypes(CreateEentTypesDto model)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, $"create-event-type", Method.Post, model, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeCreated)
                    return res;
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to create event type, please try again later.",
                    }
                };
            }
        }



        public async Task<ResponseObject> UpdateEventTypes(string id, CreateEentTypesDto model)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, $"update-event-type/{id}", Method.Put, model, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
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
                        message = "Error! Something went wrong trying to update event type, please try again later.",
                    }
                };
            }
        }



        public async Task<ResponseObject> SwitchEventTypes(string id, SwitchEventTypeDto model)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, $"switch-event-type/{id}", Method.Put, model, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
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
                        message = "Error! Something went wrong trying to switch event type, please try again later.",
                    }
                };
            }
        }

        public async Task<ResponseObject> RemoveEventTypes(string id)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, $"remove-event-type/{id}", Method.Delete, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
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
                        message = "Error! Something went wrong trying to switch event type, please try again later.",
                    }
                };
            }
        }
    }
}
