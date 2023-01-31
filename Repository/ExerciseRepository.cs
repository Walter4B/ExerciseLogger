using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Contracts;

namespace Repository
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<IEnumerable<Exercise>> GetExercisesAsync(Guid gymId, bool trackChanges) =>
            await FindByCondition(e => e.GymId.Equals(gymId), trackChanges)
            .OrderBy(e => e.StartTime)
            .ToListAsync();
        // We used await instead of .Result(), .Result() can potentially cause a deadlock which we are traying to avoid with async

        public async Task<Exercise> GetExerciseAsync(Guid gymId, Guid id, bool trackChanges) =>
            await FindByCondition(e => e.GymId.Equals(gymId) && e.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

        public void CreateExerciseForGym(Guid gymId, Exercise exercise)
        { 
            exercise.GymId = gymId;
            Create(exercise);
        }

        public void DeleteExercise(Exercise exercise) => Delete(exercise);
        
    }
}
