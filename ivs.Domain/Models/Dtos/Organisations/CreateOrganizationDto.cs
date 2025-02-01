using System.ComponentModel.DataAnnotations;

namespace ivs.Domain.Models.Dtos.Organisations
{
    public class CreateOrganizationDto
    {
        [Required(ErrorMessage = "Organisation name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Organisation name must be at least 3 characters long")]
        public string? name { get; set; }

        [Required(ErrorMessage = "Organisation description is required")]
        public string? description { get; set; }
    }
}
