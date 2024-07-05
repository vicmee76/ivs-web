using ivs.Domain.Constants;

namespace ivs.Domain.Interfaces.Organisations;

public interface IOrganisationService
{
    public Task<ResponseObject> GetOrganisations();
}