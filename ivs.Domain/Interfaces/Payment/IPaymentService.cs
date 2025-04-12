using ivs.Domain.Constants;
using ivs.Domain.Models.Dtos.Payment;
using ivs.Domain.Models.ViewModels.Payments;

namespace ivs.Domain.Interfaces.Payment
{
    public interface IPaymentService
    {
        public Task<ResponseObject> GeneratePaymentLink(MakePaymentVM model);
        public Task<ResponseObject> VerifyPayment(Dictionary<string, string> model);
        public Task<ResponseObject> ProcessFreePayment(string orderId);
        public Task<ResponseObject> GetSales(Dictionary<string, string> queryParam);
        public Task<ResponseObject> GetUserSales(Dictionary<string, string> queryParam);
        public Task<ResponseObject> GetRevenue(Dictionary<string, string> queryParam);
        public Task<ResponseObject> GetBanks(string country = "NG");
        public Task<ResponseObject> VerifyAccountNumber(string bankCode, string accountNumber);
        public Task<ResponseObject> GetTransferFee(decimal settlementAmount, string eventId);
        public Task<ResponseObject> PostSettlement(PostSettlementDto model);
        public Task<ResponseObject> GetSettlementByUserId(string userId, Dictionary<string, string> queryParam);
        public Task<ResponseObject> GetAllSettlements(Dictionary<string, string> queryParam);
        public Task<ResponseObject> GetTotalSettlement();
        public Task<ResponseObject> GetSettlementByEventId(string eventId, Dictionary<string, string> queryParam);
    }
}
