namespace ivs.Domain.Models.ViewModels.Accounts;

public class SignUpVM
{
    public string ConfirmPassword;
    public string? fullname { get; set; }
    public string? email { get; set; }
    public string? password { get; set; }
    public string? organisation_id { get; set; }
    public string? role { get; set; }
    public bool hasAgreed { get; set; }
}