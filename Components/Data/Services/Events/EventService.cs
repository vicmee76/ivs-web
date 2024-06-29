using Blazored.SessionStorage;
using ivs_ui.Domain.Constants;
using ivs_ui.Domain.Interfaces.Events;
using ivs_ui.Domain.Interfaces.General;
using ivs_ui.Domain.Models.Dtos.Events;
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
        private readonly string apiUrl = "/api/v1/ivs-events/";

        public async Task<ResponseObject> ActivateEvent(string id)
        {
            try
            {
                var token = await _sessionStorageService.GetItemAsync<string>(Tokens.TokenName);
                var headers = new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } };

                var response = await _webService.Call(apiUrl, $"activate-event/{id}", Method.Put, null, headers, null, null);
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
                        message = "Error! Something went wrong trying to publish this event, please try agian later",
                    }
                };
            }
        }

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

                var myJsonResponse = content.data.ToString().Trim().TrimStart('{').TrimEnd('}');
                res.result.data = JsonConvert.DeserializeObject<CreateEventResponseDto>(content.data.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to create an event, please try agian later",
                    }
                };
            }
        }


        public async Task<ResponseObject> GetEventByUser(string userid)
        {
            try
            {
                var token = await _sessionStorageService.GetItemAsync<string>(Tokens.TokenName);
                var headers = new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } };

                var response = await _webService.Call(apiUrl, $"get-ivs-event-by-userid/{userid}", Method.Get, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCode_Ok)
                    return res;

                var myJsonResponse = content.data.ToString().Trim().TrimStart('{').TrimEnd('}');
                res.result.data = JsonConvert.DeserializeObject<List<GetEventByUserDto>>(content.data.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to get all events for a user, please try agian later",
                    }
                };
            }
        }


        public async Task<ResponseObject> GetEventDetails(string id)
        {
            try
            {
                var token = await _sessionStorageService.GetItemAsync<string>(Tokens.TokenName);
                var headers = new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } };

                var response = await _webService.Call(apiUrl, $"get-ivs-event-by-id/{id}", Method.Get, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCode_Ok)
                    return res;

                var myJsonResponse = content.data.ToString().Trim().TrimStart('{').TrimEnd('}');
                res.result.data = JsonConvert.DeserializeObject<GetEventDetailsDto>(content.data.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to get event meta data, please try agian later",
                    }
                };
            }
        }


        public async Task<ResponseObject> GetEventMetaData(string id)
        {
            try
            {
                var token = await _sessionStorageService.GetItemAsync<string>(Tokens.TokenName);
                var headers = new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } };

                var response = await _webService.Call(apiUrl, $"get-ivs-event-meta-data-by-id/{id}", Method.Get, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCode_Ok)
                    return res;

                var myJsonResponse = content.data.ToString().Trim().TrimStart('{').TrimEnd('}');
                res.result.data = JsonConvert.DeserializeObject<CreateEventResponseDto>(content.data.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to get event meta data, please try agian later",
                    }
                };
            }
        }


        public async Task<ResponseObject> UploadEventBanner(UploadBodyVM model, UploadFileVM file)
        {
            try
            {
                var token = await _sessionStorageService.GetItemAsync<string>(Tokens.TokenName);
                var headers = new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } };

                var response = await _webService.Call(apiUrl, $"upload-event-photo/{model.ivsEventId}", Method.Put, model, headers, null, file);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCode_Ok)
                    return res;

                var myJsonResponse = content.data.ToString().Trim().TrimStart('{').TrimEnd('}');
                res.result.data = JsonConvert.DeserializeObject<CreateEventResponseDto>(content.data.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to upload event banner, please try agian later",
                    }
                };
            }
        }

    }
}
