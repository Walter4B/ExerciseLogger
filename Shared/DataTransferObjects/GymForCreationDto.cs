using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record GymForCreationDto
    {
        [Required(ErrorMessage = "Gym name is required.")]
        [MaxLength(40, ErrorMessage = "Maximum lenght for the name is 40 characters.")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Address is required.")]
        [MaxLength(50, ErrorMessage = "Maximum lenght for the address is 50 characters")]
        public string? Address { get; init; }
    };
}
