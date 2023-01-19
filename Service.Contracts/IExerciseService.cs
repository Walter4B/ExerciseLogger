using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IExerciseService
    {
        IEnumerable<ExerciseDto> GetExercises(Guid gymid, bool trackChanges);
        ExerciseDto GetExercise(Guid gymId, Guid id, bool trackChanges);
        ExerciseDto CreateExerciseForGym(Guid gymId, ExerciseForCreationDto exerciseForCreationDto, bool trackingChanges);
        void DeleteExerciseForGym(Guid gymId, Guid id, bool trackChanges);
        void UpdateExerciseForGym(Guid gymId, Guid id, ExerciseForUpdateDto exerciseForUpdate, bool gymTrackChanges, bool exerTrackChanges);
    }
}
