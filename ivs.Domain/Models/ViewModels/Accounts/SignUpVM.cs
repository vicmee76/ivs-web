using System.ComponentModel.DataAnnotations;

namespace ivs.Domain.Models.ViewModels.Accounts;

public class SignUpVM
{
    [Required(ErrorMessage = "Full Name is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Fullname and must be at least 3 characters long")]
    public string? fullname { get; set; }

    [Required(ErrorMessage = "Email Address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string? email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 20 characters")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$", ErrorMessage = "Password must include uppercase, lowercase, numbers, and special characters")]
    public string? password { get; set; }

    [Compare("password", ErrorMessage = "The password and confirmation password do not match")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "Organisation is required")]
    public string? organisation_id { get; set; }

    public string? role { get; set; } = "User";

    [Range(typeof(bool), "true", "true", ErrorMessage = "You must agree to the terms and conditions")]
    public bool hasAgreed { get; set; }
}