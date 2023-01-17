using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercise> GetExercises(Guid gymId, bool trackChanges);
        Exercise GetExercise(Guid gymId, Guid id, bool trackChanges);
        void CreateExerciseForGym(Guid gymId, Exercise exercise);
        void DeleteExercise(Exercise exercise);
    }
}
