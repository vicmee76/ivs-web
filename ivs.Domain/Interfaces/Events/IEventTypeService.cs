using ivs.Domain.Constants;

namespace ivs.Domain.Interfaces.Events;

public interface IEventTypeService
{
    public Task<ResponseObject> GetEventTypes();
}