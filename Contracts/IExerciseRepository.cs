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
        Task<IEnumerable<Exercise>> GetExercisesAsync(Guid gymId, bool trackChanges);
        Task<Exercise> GetExerciseAsync(Guid gymId, Guid id, bool trackChanges);
        void CreateExerciseForGym(Guid gymId, Exercise exercise);
        void DeleteExercise(Exercise exercise);
    }
}
