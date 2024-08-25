using ivs.Domain.Constants;
using ivs.Domain.Models.ViewModels.Payments;

namespace ivs.Domain.Interfaces.Payment
{
    public interface IPaymentService
    {
        public Task<ResponseObject> GeneratePaymentLink(MakePaymentVM model);
    }
}
