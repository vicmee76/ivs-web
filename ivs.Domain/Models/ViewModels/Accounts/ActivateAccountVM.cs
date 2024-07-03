using System.ComponentModel.DataAnnotations;

namespace ivs.Domain.Models.ViewModels.Accounts;

public class ActivateAccountVM
{
    [Required]
    public int verificationToken { get; set; }
}