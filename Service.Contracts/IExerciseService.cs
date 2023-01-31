using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IExerciseService
    {
        Task<IEnumerable<ExerciseDto>> GetExercisesAsync(Guid gymid, bool trackChanges);
        Task<ExerciseDto> GetExerciseAsync(Guid gymId, Guid id, bool trackChanges);
        Task<ExerciseDto> CreateExerciseForGymAsync(Guid gymId, ExerciseForCreationDto exerciseForCreationDto, bool trackingChanges);
        Task DeleteExerciseForGymAsync(Guid gymId, Guid id, bool trackChanges);
        Task UpdateExerciseForGymAsync(Guid gymId, Guid id, ExerciseForUpdateDto exerciseForUpdate, bool gymTrackChanges, bool exerTrackChanges);
        Task<(ExerciseForUpdateDto exerciseToPatch, Exercise exerciseEntity)> GetExerciseForPatchAsync(Guid gymId, Guid id, bool gymTrackChanges, bool exerTrackChanges);
        Task SaveChangesForPatchAsync(ExerciseForUpdateDto exerciseToPatch, Exercise exerciseEntity);
    }
}
