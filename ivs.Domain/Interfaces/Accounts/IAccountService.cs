using ivs.Domain.Constants;
using ivs.Domain.Models.ViewModels.Accounts;

namespace ivs.Domain.Interfaces.Accounts;

public interface IAccountService
{
    Task<ResponseObject> CreateUser(SignUpVM model);
    Task<ResponseObject> Login(LoginVM model);
    Task<ResponseObject> ResendVerificationCode(string userId);
    Task<ResponseObject> ResetPassword(string id, ForgotPasswordVM model);
    Task<ResponseObject> SendForgotPasswordToken(string email);
    Task<ResponseObject> VerifyAccount(string userId, ActivateAccountVM model);
    Task<ResponseObject> GetUserById(string userId);
}