using System.ComponentModel.DataAnnotations;

namespace ivs.Domain.Models.ViewModels.Accounts;

public class LoginVM
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string? email { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    public string? password { get; set; }
}