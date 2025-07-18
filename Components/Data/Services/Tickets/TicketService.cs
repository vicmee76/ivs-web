﻿using Blazored.LocalStorage;
using Blazored.SessionStorage;
using ivs.Domain.Constants;
using ivs.Domain.Interfaces.General;
using ivs.Domain.Interfaces.Tickets;
using ivs.Domain.Models.Dtos.Tickets;
using ivs.Domain.Models.ViewModels.Tickets;
using Newtonsoft.Json;
using RestSharp;

namespace ivs_ui.Components.Data.Services.Tickets
{
    public class TicketService(IWebService webService, ILocalStorageService sessionStorageService) : ITicketService
    {
        private const string ApiUrl = "/api/v1/tickets/";

        public async Task<ResponseObject> CreateTicket(CreateTicketVM model)
        {
            try
            {
                var headers = await webService.GetAuthorizationHeaders();
                var response = await webService.Call(ApiUrl, "create-event-tickets", Method.Post, model, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to create ticket, please try again later",
                    }
                };
            }
        }


        public async Task<ResponseObject> DeleteTicketById(string ticketId)
        {
            try
            {
                var headers = await webService.GetAuthorizationHeaders();
                var response = await webService.Call(ApiUrl, $"delete-event-with-tickets/{ticketId}", Method.Delete, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to delete ticket, please try again later",
                    }
                };
            }
        }



        public async Task<ResponseObject> GetTicketByEventId(string eventId)
        {
            try
            {
                var response = await webService.Call(ApiUrl, $"get-all-event-with-tickets-by-event-id/{eventId}", Method.Get, null);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<List<TicketDto>>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to get ticket by event id, please try again later",
                    }
                };
            }
        }

        public async Task<ResponseObject> UpdateTicket(string ticketIdd, CreateTicketVM model)
        {
            try
            {
                var headers = await webService.GetAuthorizationHeaders();
                var response = await webService.Call(ApiUrl, $"update-event-with-tickets/{ticketIdd}", Method.Put, model, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to update tickets, please try again later",
                    }
                };
            }
        }
    }
}
