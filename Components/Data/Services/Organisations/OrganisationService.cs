using ivs_ui.Domain.Constants;
using ivs_ui.Domain.Interfaces.General;
using ivs_ui.Domain.Interfaces.Organisations;
using ivs_ui.Domain.Models.Dtos.Organisations;
using Newtonsoft.Json;
using RestSharp;

namespace ivs_ui.Components.Data.Services.Organisations
{
    public class OrganisationService(IWebService webService) : IOrganisationService
    {
        private readonly IWebService _webService = webService;
        private readonly string apiUrl = "/api/v1/organisations/";

        public async Task<ResponseObject> GetOrganisations()
        {
            try
            {
                var response = await _webService.Call(apiUrl, "", Method.Get, null, null);
                var res = JsonConvert.DeserializeObject<ResponseObject>(response.Content ?? "");
                var content = res.result;
                if (content?.code != ResponseCodes.ResponseCode_Ok)
                    return new ResponseObject();

                var myJsonResponse = content?.data.ToString().Trim().TrimStart('{').TrimEnd('}');
                res.result.data = JsonConvert.DeserializeObject<List<GetOrganisationsDto>>(myJsonResponse);
                return res;
            }
            catch (Exception ex)
            {
                return new ResponseObject()
                {
                    result = new ResponseContents()
                    {
                        message = "Error! Something went wrong trying to get organisations, please try agian later",
                    }
                };
            }
        }
    }
}
