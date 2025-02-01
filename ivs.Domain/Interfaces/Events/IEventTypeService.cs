using ivs.Domain.Constants;
using ivs.Domain.Models.Dtos.Events;

namespace ivs.Domain.Interfaces.Events;

public interface IEventTypeService
{
    public Task<ResponseObject> GetEventTypes();
    public Task<ResponseObject> CreateEventTypes(CreateEentTypesDto model);
    public Task<ResponseObject> UpdateEventTypes(string id, CreateEentTypesDto model);
    public Task<ResponseObject> SwitchEventTypes(string id, SwitchEventTypeDto model);
    public Task<ResponseObject> RemoveEventTypes(string id);
}