using ivs.Domain.Constants;

namespace ivs.Domain.Interfaces.Payment;

public interface IPaymentOptionService
{
    public Task<ResponseObject> GetAllPaymentOptions();
}