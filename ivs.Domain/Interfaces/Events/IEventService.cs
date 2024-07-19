using ivs.Domain.Constants;
using ivs.Domain.Models.ViewModels.Events;

namespace ivs.Domain.Interfaces.Events;

public interface IEventService
{
    public Task<ResponseObject> ActivateEvent(string id);
    public Task<ResponseObject> DeleteEvent(string id);
    public Task<ResponseObject> CreateEvent(CreateEventVM model);
    public Task<ResponseObject> FetchEvent(Dictionary<string, int>? queryParameter = null);
    public Task<ResponseObject> GetEventByUser(string userid);
    public Task<ResponseObject> GetEventDetails(string id);
    public Task<ResponseObject> GetEventMetaData(string id);
    public Task<ResponseObject> UpdateEvent(string id, CreateEventVM model);
    public Task<ResponseObject> UploadEventBanner(UploadBodyVM model, UploadFileVM file);
}