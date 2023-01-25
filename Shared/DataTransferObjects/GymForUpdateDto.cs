using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record GymForUpdateDto : GymForManipulationDto
    {
        public IEnumerable<ExerciseForCreationDto>? Exercises { get; set; }
    }
}
