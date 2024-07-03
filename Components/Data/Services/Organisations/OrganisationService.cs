using ivs.Domain.Constants;
using ivs.Domain.Interfaces.General;
using ivs.Domain.Interfaces.Organisations;
using ivs.Domain.Models.Dtos.Organisations;
using Newtonsoft.Json;
using RestSharp;

namespace ivs_ui.Components.Data.Services.Organisations
{
    public class OrganisationService(IWebService webService) : IOrganisationService
    {
        private readonly IWebService _webService = webService;
        private const string ApiUrl = "/api/v1/organisations/";

        public async Task<ResponseObject> GetOrganisations()
        {
            try
            {
                var response = await _webService.Call(ApiUrl, "", Method.Get, null, null, null, null);
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
    }
}
