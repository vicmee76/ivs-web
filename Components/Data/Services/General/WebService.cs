using ivs.Domain.Interfaces.General;
using ivs.Domain.Models.ViewModels.Events;
using Newtonsoft.Json;
using RestSharp;

namespace ivs_ui.Components.Data.Services.General
{
    public class WebService(IConfiguration config) : IWebService
    {
        private readonly IConfiguration _config = config;

        public async Task<RestResponse> Call(string apiPathUrl, string absoluteUrl, Method method, dynamic? body, Dictionary<string, string>? headers = null, Dictionary<string, string>? queryParameter = null, UploadFileVM? file = null)
        {
            var options = new RestClientOptions(_config.GetValue<string>("IvsApi:BaseUri") ?? "");
            var client = new RestClient(options);
            var request = new RestRequest(string.Concat(apiPathUrl, absoluteUrl), method);

            if (file is not null)
            {
                request.AddFile("ivsEventPhoto", file.fileData!, file.fileName!);
                request.AddParameter("imageFileData", file.imageFileData);
                request.AddHeader("Content-Type", "multipart/form-data");
            }
            else
            {
                request.AddHeader("Content-Type", "application/json");
            }

            if (headers is not null)
                foreach (var header in headers) { request.AddHeader(header.Key, header.Value); }

            if (queryParameter is not null)
                foreach (var query in queryParameter) { request.AddQueryParameter(query.Key, query.Value.ToString()); }

            if (body is not null)
            {
                string serilizedBody = JsonConvert.SerializeObject(body);
                request.AddJsonBody(serilizedBody);
            }

            var response = await client.ExecuteAsync(request);
            return response;
        }

    }
}
