using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Gym
    {
        [Column("GymId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Gym name is required.")]
        [MaxLength(40, ErrorMessage = "Maximum lenght for the name is 40 characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [MaxLength(50, ErrorMessage = "Maximum lenght for the address is 50 characters")]
        public string? Address { get; set; }

        public ICollection<Exercise>? Exercises { get; set; }
    }
}
