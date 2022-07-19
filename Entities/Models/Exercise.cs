using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Exercise
    {
        [Column("ExerciseId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Exercise type is required.")]
        [MaxLength(40, ErrorMessage = "Maximum lenght for the exercise type is 40 characters.")]
        public string? Type { get; set; }

        [Required(ErrorMessage = "Exercise start time is required")]
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public TimeSpan Duration { get; set; }

        [MaxLength(300, ErrorMessage = "Maximum lenght for the comment is 300 characters")]
        public string? Comments { get; set; }

        [ForeignKey(nameof(Gym))]
        public Guid GymId { get; set; }
        public Gym? Gym { get; set; }
    }
}
