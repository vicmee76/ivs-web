using System.ComponentModel.DataAnnotations;

namespace ivs.Domain.Models.ViewModels.Accounts;

public class ActivateAccountVM
{
    [Required(ErrorMessage = "Token is required")]
    public string verificationToken { get; set; }
}