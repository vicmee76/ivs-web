using ivs.Domain.Constants;
using ivs.Domain.Models.ViewModels.Events;

namespace ivs.Domain.Interfaces.Events;

public interface IEventTimeService
{
    public Task<ResponseObject> CreateEventTime(List<EventTimeVM> model);
}