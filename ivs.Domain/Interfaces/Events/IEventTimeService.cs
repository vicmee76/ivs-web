using ivs.Domain.Constants;
using ivs.Domain.Models.ViewModels.Events;

namespace ivs.Domain.Interfaces.Events;

public interface IEventTimeService
{
    public Task<ResponseObject> CreateEventTime(EventTimeVM model);
    public Task<ResponseObject> GetTimeByEventId(string eventId);
    public Task<ResponseObject> GetUpCommingEventsByUserId(string userId);
    public Task<ResponseObject> DeleteEventTime(string id);
    public Task<ResponseObject> UpdateEventTime(string id, EventTimeVM model);
}