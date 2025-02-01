using ivs.Domain.Constants;
using ivs.Domain.Interfaces.General;
using ivs.Domain.Interfaces.Organisations;
using ivs.Domain.Models.Dtos.Accounts;
using ivs.Domain.Models.Dtos.Organisations;
using ivs.Domain.Models.Dtos.Payment;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection;

namespace ivs_ui.Components.Data.Services.Organisations
{
    public class OrganizationService(IWebService webService) : IOrganizationService
    {
        private readonly IWebService _webService = webService;
        private const string ApiUrl = "/api/v1/organisations/";

        public async Task<ResponseObject> GetOrganizations()
        {
            try
            {
                var response = await _webService.Call(ApiUrl, "", Method.Get, null);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return new ResponseObject();

                var myJsonResponse = content?.data?.ToString().Trim().TrimStart('{').TrimEnd('}');
                res.result.data = JsonConvert.DeserializeObject<List<GetOrganisationsDto>>(myJsonResponse);
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to get organisations, please try again later",
                    }
                };
            }
        }

        public  async Task<ResponseObject> CreateOrganizations(CreateOrganizationDto model)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, $"create-organisation", Method.Post, model, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeCreated)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<GetOrganisationsDto>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to create an organisation, please try again later.",
                    }
                };
            }
        }

        public async Task<ResponseObject> GetOrganizationsById(string id)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, $"{id}", Method.Get, null, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<List<GetOrganisationsDto>>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to get a single organisation, please try again later.",
                    }
                };
            }
        }

        public async Task<ResponseObject> UpdateOrganizations(string id, CreateOrganizationDto model)
        {
            try
            {
                var headers = await _webService.GetAuthorizationHeaders();
                var response = await _webService.Call(ApiUrl, $"update-organisation/{id}", Method.Put, model, headers);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res?.result;
                if (content?.code != ResponseCodes.ResponseCodeOk)
                    return res;

                res.result.data = JsonConvert.DeserializeObject<GetOrganisationsDto>(content?.data?.ToString());
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to update a single organisation, please try again later.",
                    }
                };
            }
        }
    }
}
