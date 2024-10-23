using ivs.Domain.Constants;
using ivs.Domain.Models.ViewModels.Payments;

namespace ivs.Domain.Interfaces.Payment
{
    public interface IPaymentService
    {
        public Task<ResponseObject> GeneratePaymentLink(MakePaymentVM model);
        public Task<ResponseObject> VerifyPayment(Dictionary<string, string> model);
        public Task<ResponseObject> ProcessFreePayment(string orderId);
        public Task<ResponseObject> GetSales(Dictionary<string, string> queryParam);
        public Task<ResponseObject> GetBanks(string country = "NG");
        public Task<ResponseObject> VerifyAccountNumber(string bankCode, string accountNumber);
    }
}
