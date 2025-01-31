using ivs.Domain.Constants;
using ivs.Domain.Models.Dtos.Organisations;

namespace ivs.Domain.Interfaces.Organisations;

public interface IOrganizationService
{
    public Task<ResponseObject> GetOrganizations();
    public Task<ResponseObject> CreateOrganizations(CreateOrganizationDto model);
    public Task<ResponseObject> GetOrganizationsById(string id);
    public Task<ResponseObject> UpdateOrganizations(string id, CreateOrganizationDto model);
}