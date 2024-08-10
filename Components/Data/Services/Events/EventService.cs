using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Newtonsoft.Json;
using RestSharp;
using ivs.Domain.Constants;
using ivs.Domain.Interfaces.Events;
using ivs.Domain.Interfaces.General;
using ivs.Domain.Models.Dtos.Events;
using ivs.Domain.Models.ViewModels.Events;

namespace ivs_ui.Components.Data.Services.Events
{
    public class EventService(IWebService webService, ILocalStorageService sessionStorageService) : IEventService
    {
        private readonly IWebService _webService = webService;
        private readonly ILocalStorageService _sessionStorageService = sessionStorageService;
        private const string ApiUrl = "/api/v1/ivs-events/";

        public async Task<ResponseObject> ActivateEvent(string id)
        {
            try
            {
                var token = await _sessionStorageService.GetItemAsync<string>(Tokens.TokenName);
                var headers = new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } };

                var response = await _webService.Call(ApiUrl, $"activate-event/{id}", Method.Put, null, headers, null, null);
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
                        message = "Error! Something went wrong trying to publish this event, please try again later",
                    }
                };
            }
        }

        
        public async Task<ResponseObject> DeleteEvent(string id)
        {
            try
            {
                var token = await _sessionStorageService.GetItemAsync<string>(Tokens.TokenName);
                var headers = new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } };
                var response = await _webService.Call(ApiUrl, $"delete-ivs-event/{id}", Method.Delete, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to create an event, please try again later",
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

                var response = await _webService.Call(ApiUrl, "create-event", Method.Post, model, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCodeCreated)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<CreateEventResponseDto>(content?.data.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to create an event, please try again later",
                    }
                };
            }
        }

        
        public async Task<ResponseObject> FetchEvent(Dictionary<string, string>? queryParameter = null)
        {
            try
            {
                var response = await _webService.Call(ApiUrl, $"fetch-event", Method.Get, null, null, queryParameter);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;
                res.result.data = JsonConvert.DeserializeObject<List<FetchEventDto>>(content.data.ToString());
                return res;
            }
            catch (Exception e)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to fetch event, please try again later",
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

                var response = await _webService.Call(ApiUrl, $"get-ivs-event-by-userid/{userid}", Method.Get, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<List<GetEventByUserDto>>(content.data.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to get all events for a user, please try again later",
                    }
                };
            }
        }


        public async Task<ResponseObject> GetEventDetails(string id)
        {
            try
            {
                var response = await _webService.Call(ApiUrl, $"get-ivs-event-by-id/{id}", Method.Get, null, null);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<GetEventDetailsDto>(content.data.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to get event details data, please try again later",
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

                var response = await _webService.Call(ApiUrl, $"get-ivs-event-meta-data-by-id/{id}", Method.Get, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<GetEventMetaDataDto>(content.data.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to get event meta data, please try again later",
                    }
                };
            }
        }



        public async Task<ResponseObject> UpdateEvent(string id, CreateEventVM model)
        {
            try
            {
                var token = await _sessionStorageService.GetItemAsync<string>(Tokens.TokenName);
                var headers = new Dictionary<string, string> { { "Authorization", $"Bearer {token}" } };

                var response = await _webService.Call(ApiUrl, $"update-event/{id}", Method.Put, model, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<CreateEventResponseDto>(content.data.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to update an event, please try again later",
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

                var response = await _webService.Call(ApiUrl, $"upload-event-photo/{model.ivsEventId}", Method.Put, model, headers, null, file);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;
                res.result.data = JsonConvert.DeserializeObject<CreateEventResponseDto>(content.data.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to upload event banner, please try again later",
                    }
                };
            }
        }

    }
}
