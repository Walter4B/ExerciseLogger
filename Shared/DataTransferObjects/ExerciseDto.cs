using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ExerciseDto(Guid Id, string Type, DateTime StartTime, DateTime EndTime, TimeSpan Duration, string Comments);
}
