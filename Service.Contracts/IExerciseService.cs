using Entities.Models;
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
        (ExerciseForUpdateDto exerciseToPatch, Exercise exerciseEntity) GetExerciseForPatch(Guid gymId, Guid id, bool gymTrackChanges, bool exerTrackChanges);
        void SaveChangesForPatch(ExerciseForUpdateDto exerciseToPatch, Exercise exerciseEntity);
    }
}
