using System.ComponentModel.DataAnnotations;

namespace ivs.Domain.Models.ViewModels.Accounts;

public class ChangePasswordVM
{
    [Required(ErrorMessage = "Enter your old password")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
    public string? OldPassword { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long")]
    public string? NewPassword { get; set; }

    [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match")]
    public string ConfirmPassword { get; set; }
}