using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class ExerciseNotFoundException : NotFoundException
    {
        public ExerciseNotFoundException(Guid exerciseId) : base($"Exercise with id {exerciseId} does not exist in the database.") { }
    }
}
