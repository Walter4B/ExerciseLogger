using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public record ExerciseForCreationDto(string Type, DateTime StartTime, DateTime EndTime, TimeSpan Duration, string Comments); //string Type and DateTime StartTime; needed to start exercise session 
}
