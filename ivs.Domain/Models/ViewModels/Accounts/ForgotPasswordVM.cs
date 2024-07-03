namespace ivs.Domain.Models.ViewModels.Accounts;

public class ForgotPasswordVM
{
    public string? token { get; set; }
    public string? newPassword { get; set; }
    public string ConfirmNewPassword { get; set; }
}