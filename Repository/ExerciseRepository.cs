using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Contracts;

namespace Repository
{
    public class ExerciseRepository : RepositoryBase<Exercise>, IExerciseRepository
    {
        public ExerciseRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<Exercise> GetExercises(Guid gymId, bool trackChanges) =>
            FindByCondition(e => e.GymId.Equals(gymId), trackChanges)
            .OrderBy(e => e.StartTime)
            .ToList();

        public Exercise GetExercise(Guid gymId, Guid id, bool trackChanges) =>
            FindByCondition(e => e.GymId.Equals(gymId) && e.Id.Equals(id), trackChanges)
            .SingleOrDefault();

        public void CreateExerciseForGym(Guid gymId, Exercise exercise)
        { 
            exercise.GymId = gymId;
            Create(exercise);
        }

        public void DeleteExercise(Exercise exercise) => Delete(exercise);
        
    }
}
