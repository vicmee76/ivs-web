using System.ComponentModel.DataAnnotations;

namespace ivs.Domain.Models.ViewModels.Accounts;

public class SendForgotPasswordVM
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string email { get; set; }
}