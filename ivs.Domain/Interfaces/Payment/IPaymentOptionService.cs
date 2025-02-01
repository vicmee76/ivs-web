using ivs.Domain.Constants;
using ivs.Domain.Models.Dtos.Payment;

namespace ivs.Domain.Interfaces.Payment;

public interface IPaymentOptionService
{
    public Task<ResponseObject> GetAllPaymentOptions();
    public Task<ResponseObject> CreatePaymentOptions(CreatePaymentOptionDto model);
    public Task<ResponseObject> UpdatePaymentOptions(string id, CreatePaymentOptionDto model);
    public Task<ResponseObject> RemovePaymentOptions(string id);
}