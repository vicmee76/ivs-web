using ivs.Domain.Constants;
using ivs.Domain.Models.ViewModels.Orders;

namespace ivs.Domain.Interfaces.Orders;

public interface IOrdersService
{
    public Task<ResponseObject> GenerateCost(List<GenerateCostVM> model);
}