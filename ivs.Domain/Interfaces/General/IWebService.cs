using ivs.Domain.Models.ViewModels.Events;

namespace ivs.Domain.Interfaces.General;
using RestSharp;

public interface IWebService
{
    Task<RestResponse> Call(string apiPathUrl, string absoluteUrl, Method method, dynamic? body, Dictionary<string, string>? headers = null, Dictionary<string, string>? queryParameter = null, UploadFileVM file = null);
    Task<Dictionary<string, string>> GetAuthorizationHeaders();
}