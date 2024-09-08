using ivs.Domain.Constants;
using ivs.Domain.Models.ViewModels.Orders;

namespace ivs.Domain.Interfaces.Orders;

public interface IOrdersAndAttendanceService
{
    public Task<ResponseObject> GenerateCost(List<GenerateCostVM> model);
    public Task<ResponseObject> SaveOrder(OrdersVM model);
    public Task<ResponseObject> GetOrderById(string id);
    public Task<ResponseObject> GetAttendanceByOrderId(string orderId);
}