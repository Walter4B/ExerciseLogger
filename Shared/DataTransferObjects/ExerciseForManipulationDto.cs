using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public abstract record ExerciseForManipulationDto
    {
        [Required(ErrorMessage = "Exercise type is required.")]
        [MaxLength(40, ErrorMessage = "Maximum lenght for the exercise type is 40 characters.")]
        public string? Type { get; init; }
        [Required(ErrorMessage = "Exercise start time is required")]
        public DateTime StartTime { get; init; }
        public DateTime EndTime { get; init; }
        public TimeSpan Duration { get; init; }
        [MaxLength(300, ErrorMessage = "Maximum lenght for the comment is 300 characters")]
        public string? Comments { get; init; }
    }; //string Type and DateTime StartTime; needed to start exercise session 
}
