namespace ivs.Domain.Models.Dtos.Accounts;

public class GetAllUsersDto
{
    public string _id { get; set; }
    public string fullname { get; set; }
    public string organisation_id { get; set; }
    public string email { get; set; }
    public bool isVerified { get; set; }
    public bool isActive { get; set; }
    public string createdAt { get; set; }
    public string UpdatedAt { get; set; }
    public string activatedOn { get; set; }
    public string passwordUpdatedOn { get; set; }
    public string role { get; set; }
}