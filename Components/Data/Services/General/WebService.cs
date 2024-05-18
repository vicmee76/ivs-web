using ivs_ui.Domain.Interfaces.General;
using Newtonsoft.Json;
using RestSharp;

namespace ivs_ui.Components.Data.Services.General
{
    public class WebService(IConfiguration config) : IWebService
    {
        private readonly IConfiguration _config = config;

        public async Task<RestResponse> Call(string apiPathUrl, string absoluteUrl, Method method, dynamic body, Dictionary<string, string>? headers = null, Dictionary<string, string>? queryParameter = null)
        {
            var options = new RestClientOptions(_config.GetValue<string>("IvsApi:BaseUri") ?? "") { MaxTimeout = -1, };
            var client = new RestClient(options);
            var request = new RestRequest(string.Concat(apiPathUrl, absoluteUrl), method);

            if (headers != null)
                foreach (var header in headers) { request.AddHeader(header.Key, header.Value); }

            if (queryParameter != null)
                foreach (var query in queryParameter) { request.AddQueryParameter(query.Key, query.Value); }

            request.AddHeader("Content-Type", "application/json");

            if (body != null)
            {
                string serilizedBody = JsonConvert.SerializeObject(body);
                request.AddJsonBody(serilizedBody);
            }

            RestResponse response = await client.ExecuteAsync(request);
            return response;
        }
    }
}
