﻿using Blazored.LocalStorage;
using Blazored.SessionStorage;
using ivs.Domain.Constants;
using ivs.Domain.Interfaces.Events;
using ivs.Domain.Interfaces.General;
using ivs.Domain.Models.Dtos.Events;
using ivs.Domain.Models.ViewModels.Events;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection;

namespace ivs_ui.Components.Data.Services.Events
{
    public class EventTimeService(IWebService webService) : IEventTimeService
    {
        private readonly IWebService _webService = webService;
        private const string ApiUrl = "/api/v1/ivs-events-time/";

        public async Task<ResponseObject> CreateEventTime(EventTimeVM model)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, $"create-event-time", Method.Post, model, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to create event time, please try again later",
                    }
                };
            }
        }
        

        public async Task<ResponseObject> GetTimeByEventId(string eventId)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, $"get-ivs-event-time-by-eventId/{eventId}", Method.Get, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                var myJsonResponse = content?.data?.ToString().Trim().TrimStart('{').TrimEnd('}');
                res.result.data = JsonConvert.DeserializeObject<List<EventTimeDto>>(myJsonResponse);
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to get event time, please try again later",
                    }
                };
            }
        }

        public async Task<ResponseObject> DeleteEventTime(string id)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, $"remove-ivs-event-time/{id}", Method.Delete, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to delete event time, please try again later",
                    }
                };
            }
        }

        public async Task<ResponseObject> UpdateEventTime(string id, EventTimeVM model)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders(); 
                var response = await _webService.Call(ApiUrl, $"update-event-time/{id}", Method.Put, model, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                return res;
            }
            catch (Exception)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to update event time, please try again later",
                    }
                };
            }
        }

        public async Task<ResponseObject> GetUpCommingEventsByUserId(string userId)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders(); 
                var response = await _webService.Call(ApiUrl, $"get-upcoming-events-by-user-id/{userId}", Method.Get, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                //var myJsonResponse = content?.data?.ToString().Trim().TrimStart('{').TrimEnd('}');
                res.result.data = JsonConvert.DeserializeObject<List<UpcomingEventsDto>>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to update event time, please try again later",
                    }
                };
            }
        }
    }
}
