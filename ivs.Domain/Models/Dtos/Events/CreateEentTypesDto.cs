using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ivs.Domain.Models.Dtos.Events
{
    public class CreateEentTypesDto
    {
        [Required(ErrorMessage = "Event type name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Event type name must be at least 3 characters long")]
        public string? name { get; set; }
    }
}
