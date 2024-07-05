using System.ComponentModel.DataAnnotations;

namespace ivs.Domain.Models.ViewModels.Accounts;

public class ForgotPasswordVM
{
    [Required(ErrorMessage = "Token is required")]
    public string? token { get; set; }

    [Required(ErrorMessage = "New Password is required")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
    public string? newPassword { get; set; }

    [Required(ErrorMessage = "Confirmation of New Password is required")]
    [Compare("newPassword", ErrorMessage = "The new password and confirmation password do not match")]
    public string ConfirmNewPassword { get; set; }
}