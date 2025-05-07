using ivs.Domain.Constants;
using ivs.Domain.Models.ViewModels.Events;

namespace ivs.Domain.Interfaces.Events;

public interface IDiscountService
{
    public Task<ResponseObject> CreateDiscount(CreateDiscountVM model);
    public Task<ResponseObject> GetDiscountByEventId(string id);
    public Task<ResponseObject> DeleteDiscountById(string id);
    
    public Task<ResponseObject> GetDiscountByCode(string code);
    public Task<ResponseObject> UpdateDiscount(string id, CreateDiscountVM model);
}